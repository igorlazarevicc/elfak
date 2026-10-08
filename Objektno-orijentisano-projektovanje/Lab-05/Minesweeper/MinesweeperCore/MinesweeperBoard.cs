using System;

namespace MinesweeperCore
{
    public enum RevealOutcome
    {
        Opened,
        HitMine,
        AlreadyOpenedOrFlagged
    }
    
    public class MinesweeperBoard
    {
        public int Rows { get; private set; }
        public int Columns { get; private set; }
        public int MineCount { get; private set; }
        public Cell[,] Cells { get; private set; }
        public bool IsGameOver { get; private set; }
        public bool IsWon { get; private set; }

        private bool _minesPlaced;
        private readonly Random _random = new Random();

        public MinesweeperBoard(int rows, int columns, int mineCount)
        {
            Rows = rows;
            Columns = columns;
            MineCount = mineCount;
            InitializeEmptyBoard();
        }

        private void InitializeEmptyBoard()
        {
            Cells = new Cell[Rows, Columns];
            for (int r = 0; r < Rows; r++)
            {
                for (int c = 0; c < Columns; c++)
                {
                    Cells[r, c] = new Cell { Row = r, Col = c };
                }
            }

            _minesPlaced = false;
            IsGameOver = false;
            IsWon = false;
        }


        // Nasumicno postavlja mine, izbegavajuci prvo kliknuto polje
        // (prvi klik nikad ne sme da bude mina).

        public void PlaceMinesRandom(int safeRow, int safeCol)
        {
            int placed = 0;
            while (placed < MineCount)
            {
                int r = _random.Next(Rows);
                int c = _random.Next(Columns);
                if (r == safeRow && c == safeCol) continue;
                if (Cells[r, c].IsMine) continue;

                Cells[r, c].IsMine = true;
                placed++;
            }

            CalculateAdjacentMines();
            _minesPlaced = true;
        }

        
        /// Postavlja mine na osnovu rasporeda koji je administrator sacuvao u XML fajlu
        public void PlaceMinesFromLayout(BoardLayout layout)
        {
            Rows = layout.Rows;
            Columns = layout.Columns;
            MineCount = layout.Mines.Count;
            InitializeEmptyBoard();

            foreach (MinePosition pos in layout.Mines)
            {
                if (pos.Row >= 0 && pos.Row < Rows && pos.Col >= 0 && pos.Col < Columns)
                {
                    Cells[pos.Row, pos.Col].IsMine = true;
                }
            }

            CalculateAdjacentMines();
            _minesPlaced = true;
        }

        private void CalculateAdjacentMines()
        {
            for (int r = 0; r < Rows; r++)
            {
                for (int c = 0; c < Columns; c++)
                {
                    if (Cells[r, c].IsMine)
                    {
                        continue;
                    }
                    Cells[r, c].AdjacentMines = CountAdjacentMines(r, c);
                }
            }
        }

        private int CountAdjacentMines(int row, int col)
        {
            int count = 0;
            for (int dr = -1; dr <= 1; dr++)
            {
                for (int dc = -1; dc <= 1; dc++)
                {
                    if (dr == 0 && dc == 0) continue;
                    int nr = row + dr;
                    int nc = col + dc;
                    if (nr < 0 || nr >= Rows || nc < 0 || nc >= Columns) continue;
                    if (Cells[nr, nc].IsMine) count++;
                }
            }
            return count;
        }

        
        /// Otvara polje. Ako polje nema susednih mina, automatski se otvaraju
        /// i sva susedna polja (flood fill), kao u originalnoj igri
        
        public RevealOutcome RevealCell(int row, int col)
        {
            if (IsGameOver) return RevealOutcome.AlreadyOpenedOrFlagged;

            Cell cell = Cells[row, col];
            if (cell.IsRevealed || cell.IsFlagged) return RevealOutcome.AlreadyOpenedOrFlagged;

            if (!_minesPlaced)
            {
                PlaceMinesRandom(row, col);
            }

            cell.IsRevealed = true;

            if (cell.IsMine)
            {
                IsGameOver = true;
                IsWon = false;
                RevealAllMines();
                return RevealOutcome.HitMine;
            }

            if (cell.AdjacentMines == 0)
            {
                FloodFillOpen(row, col);
            }

            if (CheckWin())
            {
                IsGameOver = true;
                IsWon = true;
            }

            return RevealOutcome.Opened;
        }

        private void FloodFillOpen(int row, int col)
        {
            for (int dr = -1; dr <= 1; dr++)
            {
                for (int dc = -1; dc <= 1; dc++)
                {
                    if (dr == 0 && dc == 0) continue;
                    int nr = row + dr;
                    int nc = col + dc;
                    if (nr < 0 || nr >= Rows || nc < 0 || nc >= Columns) continue;

                    Cell neighbor = Cells[nr, nc];
                    if (neighbor.IsRevealed || neighbor.IsFlagged || neighbor.IsMine) continue;

                    neighbor.IsRevealed = true;
                    if (neighbor.AdjacentMines == 0)
                    {
                        FloodFillOpen(nr, nc);
                    }
                }
            }
        }


        /// Postavlja ili skida oznaku (zastavicu) sa polja - obicno se poziva na desni klik.

        public bool ToggleFlag(int row, int col)
        {
            if (IsGameOver) return Cells[row, col].IsFlagged;

            Cell cell = Cells[row, col];
            if (cell.IsRevealed) return false;

            cell.IsFlagged = !cell.IsFlagged;
            return cell.IsFlagged;
        }

        public int CountFlags()
        {
            int count = 0;
            foreach (Cell cell in Cells)
            {
                if (cell.IsFlagged) count++;
            }
            return count;
        }

        private bool CheckWin()
        {
            foreach (Cell cell in Cells)
            {
                if (!cell.IsMine && !cell.IsRevealed) return false;
            }
            return true;
        }

        private void RevealAllMines()
        {
            foreach (Cell cell in Cells)
            {
                if (cell.IsMine) cell.IsRevealed = true;
            }
        }

        
        /// Prekida igru na zahtev korisnika (opcija "Zavrsi igru") i otkriva
        /// SVA neotvorena polja, kako je trazeno u zadatku 7.
        
        public void EndGame()
        {
            foreach (Cell cell in Cells)
            {
                cell.IsRevealed = true;
            }
            IsGameOver = true;
        }

        
        /// Pravi snimak trenutnog stanja partije, pogodan za XML serijalizaciju (zadatak 10).
        
        public GameState ToGameState(int elapsedSeconds)
        {
            var state = new GameState
            {
                Rows = Rows,
                Columns = Columns,
                MineCount = MineCount,
                ElapsedSeconds = elapsedSeconds,
                GameOver = IsGameOver,
                Won = IsWon
            };

            foreach (Cell cell in Cells)
            {
                state.Cells.Add(new Cell
                {
                    Row = cell.Row,
                    Col = cell.Col,
                    IsMine = cell.IsMine,
                    IsRevealed = cell.IsRevealed,
                    IsFlagged = cell.IsFlagged,
                    AdjacentMines = cell.AdjacentMines
                });
            }

            return state;
        }


        /// Rekonstruise tablu na osnovu sacuvanog stanja (ucitanog iz XML fajla).

        public static MinesweeperBoard FromGameState(GameState state)
        {
            var board = new MinesweeperBoard(state.Rows, state.Columns, state.MineCount)
            {
                _minesPlaced = true
            };

            foreach (Cell savedCell in state.Cells)
            {
                Cell cell = board.Cells[savedCell.Row, savedCell.Col];
                cell.IsMine = savedCell.IsMine;
                cell.IsRevealed = savedCell.IsRevealed;
                cell.IsFlagged = savedCell.IsFlagged;
                cell.AdjacentMines = savedCell.AdjacentMines;
            }

            board.IsGameOver = state.GameOver;
            board.IsWon = state.Won;
            return board;
        }
    }
}
