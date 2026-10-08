using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using MinesweeperCore;

namespace MinesweeperUI
{
    public class MainForm : Form
    {
        private const int ButtonSize = 32;
        private const int MenuHeightEstimate = 28;

        private MinesweeperBoard _board;
        private GameSettings _settings;
        private Button[,] _cellButtons;

        private readonly System.Windows.Forms.Timer _timer = new System.Windows.Forms.Timer();
        private int _elapsedSeconds;

        private MenuStrip _menuStrip;
        private TableLayoutPanel _boardPanel;
        private Panel _statusPanel;
        private Label _timeLabel;
        private Label _mineLabel;

        private readonly string _settingsFilePath;

        public MainForm()
        {
            string appDataFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),"MinesweeperOOP");
            Directory.CreateDirectory(appDataFolder);
            _settingsFilePath = Path.Combine(appDataFolder, "settings.xml");

            _settings = LoadOrCreateDefaultSettings();

            BuildUi();

            _timer.Interval = 1000;
            _timer.Tick += Timer_Tick;

            StartNewGame();
        }

        private GameSettings LoadOrCreateDefaultSettings()
        {
            if (File.Exists(_settingsFilePath))
            {
                try
                {
                    return XmlFileHelper.Load<GameSettings>(_settingsFilePath);
                }
                catch
                {
                    // Ako je fajl sa podesavanjima ostecen, vracamo se na podrazumevana podesavanja.
                }
            }

            GameSettings defaults = GameSettings.CreateDefault();
            XmlFileHelper.Save(defaults, _settingsFilePath);
            return defaults;
        }

        private void SaveSettings()
        {
            XmlFileHelper.Save(_settings, _settingsFilePath);
        }

        private void BuildUi()
        {
            Text = "Minesweeper";
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;

            BuildMenu();

            _statusPanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 36
            };

            _mineLabel = new Label
            {
                AutoSize = true,
                Font = new Font(Font.FontFamily, 11, FontStyle.Bold),
                Location = new Point(10, 8),
                Text = "Mine: 0"
            };

            _timeLabel = new Label
            {
                AutoSize = true,
                Font = new Font(Font.FontFamily, 11, FontStyle.Bold),
                Location = new Point(150, 8),
                Text = "Vreme: 00:00"
            };

            _statusPanel.Controls.Add(_mineLabel);
            _statusPanel.Controls.Add(_timeLabel);

            _boardPanel = new TableLayoutPanel
            {
                Dock = DockStyle.Fill
            };

            Controls.Add(_boardPanel);
            Controls.Add(_statusPanel);
            Controls.Add(_menuStrip);
            MainMenuStrip = _menuStrip;
        }

        private void BuildMenu()
        {
            _menuStrip = new MenuStrip
            {
                Dock = DockStyle.Top
            };

            var gameMenu = new ToolStripMenuItem("Igra");
            var newGameItem = new ToolStripMenuItem("Nova igra", null, (s, e) => StartNewGame());
            var saveGameItem = new ToolStripMenuItem("Sacuvaj igru...", null, SaveGame_Click);
            var loadGameItem = new ToolStripMenuItem("Ucitaj igru...", null, LoadGame_Click);
            var endGameItem = new ToolStripMenuItem("Zavrsi igru", null, EndGame_Click);
            var exitItem = new ToolStripMenuItem("Izlaz", null, (s, e) => Close());

            gameMenu.DropDownItems.Add(newGameItem);
            gameMenu.DropDownItems.Add(new ToolStripSeparator());
            gameMenu.DropDownItems.Add(saveGameItem);
            gameMenu.DropDownItems.Add(loadGameItem);
            gameMenu.DropDownItems.Add(new ToolStripSeparator());
            gameMenu.DropDownItems.Add(endGameItem);
            gameMenu.DropDownItems.Add(new ToolStripSeparator());
            gameMenu.DropDownItems.Add(exitItem);

            var settingsMenu = new ToolStripMenuItem("Podesavanja");
            var configureItem = new ToolStripMenuItem("Podesi tablu...", null, ConfigureBoard_Click);
            settingsMenu.DropDownItems.Add(configureItem);

            var adminMenu = new ToolStripMenuItem("Administracija");
            var designItem = new ToolStripMenuItem("Dizajniraj tablu...", null, DesignBoard_Click);
            var loadLayoutItem = new ToolStripMenuItem("Ucitaj raspored mina...", null, LoadLayout_Click);
            adminMenu.DropDownItems.Add(designItem);
            adminMenu.DropDownItems.Add(loadLayoutItem);

            _menuStrip.Items.Add(gameMenu);
            _menuStrip.Items.Add(settingsMenu);
            _menuStrip.Items.Add(adminMenu);
        }

        private void StartNewGame(BoardLayout layout = null)
        {
            _timer.Stop();
            _elapsedSeconds = 0;
            UpdateTimeLabel();

            if (layout != null)
            {
                _board = new MinesweeperBoard(layout.Rows, layout.Columns, Math.Max(layout.Mines.Count, 1));
                _board.PlaceMinesFromLayout(layout);
            }
            else
            {
                _board = new MinesweeperBoard(_settings.Rows, _settings.Columns, _settings.MineCount);
            }

            BuildBoardUi(_board.Rows, _board.Columns);
            RedrawBoard();

            _timer.Start();
        }

        private void BuildBoardUi(int rows, int columns)
        {
            _boardPanel.SuspendLayout();
            _boardPanel.Controls.Clear();
            _boardPanel.RowStyles.Clear();
            _boardPanel.ColumnStyles.Clear();
            _boardPanel.RowCount = rows;
            _boardPanel.ColumnCount = columns;

            _cellButtons = new Button[rows, columns];

            for (int r = 0; r < rows; r++)
            {
                _boardPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, ButtonSize));
            }
            for (int c = 0; c < columns; c++)
            {
                _boardPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, ButtonSize));
            }

            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < columns; c++)
                {
                    var btn = new Button
                    {
                        Width = ButtonSize,
                        Height = ButtonSize,
                        Margin = new Padding(0),
                        Tag = (r, c),
                        Font = new Font(Font.FontFamily, 9, FontStyle.Bold)
                    };
                    btn.MouseDown += CellButton_MouseDown;
                    _boardPanel.Controls.Add(btn, c, r);
                    _cellButtons[r, c] = btn;
                }
            }

            _boardPanel.ResumeLayout();

            ClientSize = new Size(
                Math.Max(columns * ButtonSize, 300),
                rows * ButtonSize + _statusPanel.Height + MenuHeightEstimate);
        }

        private void CellButton_MouseDown(object sender, MouseEventArgs e)
        {
            if (_board.IsGameOver) return;

            var btn = (Button)sender;
            var (row, col) = ((int, int))btn.Tag;

            if (e.Button == MouseButtons.Left)
            {
                RevealOutcome outcome = _board.RevealCell(row, col);
                RedrawBoard();

                if (_board.IsGameOver)
                {
                    _timer.Stop();
                    if (_board.IsWon)
                    {
                        MessageBox.Show(this, "Cestitamo, otkrili ste sva polja!", "Pobeda",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (outcome == RevealOutcome.HitMine)
                    {
                        MessageBox.Show(this, "Nagazili ste minu. Igra je zavrsena.", "Kraj igre",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                _board.ToggleFlag(row, col);
                RedrawBoard();
            }
        }

        private void RedrawBoard()
        {
            for (int r = 0; r < _board.Rows; r++)
            {
                for (int c = 0; c < _board.Columns; c++)
                {
                    Cell cell = _board.Cells[r, c];
                    Button btn = _cellButtons[r, c];
                    ApplyCellAppearance(btn, cell);
                }
            }

            int remainingMines = _board.MineCount - _board.CountFlags();
            _mineLabel.Text = $"Mine: {remainingMines}";
        }

        private static void ApplyCellAppearance(Button btn, Cell cell)
        {
            if (!cell.IsRevealed)
            {
                btn.Text = cell.IsFlagged ? "F" : "";
                btn.BackColor = SystemColors.Control;
                btn.ForeColor = Color.Red;
                btn.Enabled = true;
                return;
            }

            btn.Enabled = false;
            btn.BackColor = Color.Gainsboro;

            if (cell.IsMine)
            {
                btn.Text = "*";
                btn.ForeColor = Color.Black;
                btn.BackColor = Color.IndianRed;
            }
            else if (cell.AdjacentMines > 0)
            {
                btn.Text = cell.AdjacentMines.ToString();
                btn.ForeColor = GetNumberColor(cell.AdjacentMines);
            }
            else
            {
                btn.Text = "";
            }
        }

        private static Color GetNumberColor(int number)
        {
            switch (number)
            {
                case 1: return Color.Blue;
                case 2: return Color.Green;
                case 3: return Color.Red;
                case 4: return Color.DarkBlue;
                case 5: return Color.DarkRed;
                case 6: return Color.Teal;
                case 7: return Color.Black;
                default: return Color.Gray;
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            _elapsedSeconds++;
            UpdateTimeLabel();
        }

        private void UpdateTimeLabel()
        {
            TimeSpan time = TimeSpan.FromSeconds(_elapsedSeconds);
            _timeLabel.Text = $"Vreme: {time:mm\\:ss}";
        }

        private void SaveGame_Click(object sender, EventArgs e)
        {
            using var dialog = new SaveFileDialog
            {
                Filter = "XML fajlovi (*.xml)|*.xml",
                FileName = "minesweeper_save.xml"
            };

            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                GameState state = _board.ToGameState(_elapsedSeconds);
                XmlFileHelper.Save(state, dialog.FileName);
                MessageBox.Show(this, "Igra je sacuvana.", "Sacuvano", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void LoadGame_Click(object sender, EventArgs e)
        {
            using var dialog = new OpenFileDialog
            {
                Filter = "XML fajlovi (*.xml)|*.xml"
            };

            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                try
                {
                    GameState state = XmlFileHelper.Load<GameState>(dialog.FileName);
                    _board = MinesweeperBoard.FromGameState(state);
                    _elapsedSeconds = state.ElapsedSeconds;

                    BuildBoardUi(_board.Rows, _board.Columns);
                    RedrawBoard();
                    UpdateTimeLabel();

                    _timer.Stop();
                    if (!_board.IsGameOver)
                    {
                        _timer.Start();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, "Ucitavanje nije uspelo: " + ex.Message, "Greska",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void EndGame_Click(object sender, EventArgs e)
        {
            _board.EndGame();
            _timer.Stop();
            RedrawBoard();
        }

        private void ConfigureBoard_Click(object sender, EventArgs e)
        {
            using var form = new SettingsForm(_settings);
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                _settings = form.ResultSettings;
                SaveSettings();
                StartNewGame();
            }
        }

        private void DesignBoard_Click(object sender, EventArgs e)
        {
            using var form = new AdminBoardForm(_settings.Rows, _settings.Columns);
            form.ShowDialog(this);
        }

        private void LoadLayout_Click(object sender, EventArgs e)
        {
            using var dialog = new OpenFileDialog
            {
                Filter = "XML fajlovi (*.xml)|*.xml"
            };

            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                try
                {
                    BoardLayout layout = XmlFileHelper.Load<BoardLayout>(dialog.FileName);
                    StartNewGame(layout);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, "Ucitavanje rasporeda nije uspelo: " + ex.Message, "Greska",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
