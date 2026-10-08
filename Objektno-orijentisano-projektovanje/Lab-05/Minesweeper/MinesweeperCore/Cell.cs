using System;

namespace MinesweeperCore
{   
    /// Predstavlja jedno polje na Minesweeper tabli.
    /// Cista podatkovna klasa (DTO) - koristi se za prikaz stanja igre i za XML serijalizaciju
    /// (i konfiguracije i sacuvane partije).

    [Serializable]
    public class Cell
    {
        public int Row { get; set; }
        public int Col { get; set; }
        public bool IsMine { get; set; }
        public bool IsRevealed { get; set; }
        public bool IsFlagged { get; set; }
        public int AdjacentMines { get; set; }

        public Cell()
        {
        }
    }
}
