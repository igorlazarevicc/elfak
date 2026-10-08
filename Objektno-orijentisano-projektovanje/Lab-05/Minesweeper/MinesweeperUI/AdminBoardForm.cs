using System;
using System.Drawing;
using System.Windows.Forms;
using MinesweeperCore;

namespace MinesweeperUI
{
    /// <summary>
    /// Administratorski deo za rucno dizajniranje table - klikom se postavljaju/skidaju mine.
    /// Rezultat (raspored mina) se cuva u XML fajl (zadaci 8 i 9).
    /// </summary>
    public class AdminBoardForm : Form
    {
        private const int ButtonSize = 28;

        private readonly TableLayoutPanel _grid;
        private readonly NumericUpDown _rowsInput;
        private readonly NumericUpDown _columnsInput;
        private readonly Label _mineCountLabel;

        private Button[,] _buttons;
        private bool[,] _mines;
        private int _rows;
        private int _columns;

        public AdminBoardForm(int initialRows, int initialColumns)
        {
            _rows = Math.Max(initialRows, GameSettings.MinRows);
            _columns = Math.Max(initialColumns, GameSettings.MinColumns);

            Text = "Administracija - dizajn table";
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;

            var topPanel = new Panel { Dock = DockStyle.Top, Height = 70 };

            var rowsLabel = new Label { Text = "Redovi:", Left = 10, Top = 12, Width = 50 };
            _rowsInput = new NumericUpDown
            {
                Left = 65,
                Top = 9,
                Width = 60,
                Minimum = GameSettings.MinRows,
                Maximum = 30,
                Value = _rows
            };

            var columnsLabel = new Label { Text = "Kolone:", Left = 140, Top = 12, Width = 50 };
            _columnsInput = new NumericUpDown
            {
                Left = 195,
                Top = 9,
                Width = 60,
                Minimum = GameSettings.MinColumns,
                Maximum = 30,
                Value = _columns
            };

            var regenerateButton = new Button { Text = "Generisi tablu", Left = 270, Top = 8, Width = 110 };
            regenerateButton.Click += (s, e) =>
            {
                _rows = (int)_rowsInput.Value;
                _columns = (int)_columnsInput.Value;
                RebuildGrid();
            };

            _mineCountLabel = new Label { Left = 10, Top = 42, Width = 300, Text = "Postavljeno mina: 0" };

            topPanel.Controls.Add(rowsLabel);
            topPanel.Controls.Add(_rowsInput);
            topPanel.Controls.Add(columnsLabel);
            topPanel.Controls.Add(_columnsInput);
            topPanel.Controls.Add(regenerateButton);
            topPanel.Controls.Add(_mineCountLabel);

            var hintLabel = new Label
            {
                Dock = DockStyle.Top,
                Height = 24,
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(10, 0, 0, 0),
                Text = "Levi klik na polje postavlja ili skida minu."
            };

            _grid = new TableLayoutPanel { Dock = DockStyle.Fill };

            var bottomPanel = new Panel { Dock = DockStyle.Bottom, Height = 45 };
            var saveButton = new Button { Text = "Sacuvaj raspored u XML...", Left = 10, Top = 7, Width = 200 };
            var closeButton = new Button { Text = "Zatvori", Left = 220, Top = 7, Width = 80 };
            saveButton.Click += SaveButton_Click;
            closeButton.Click += (s, e) => Close();
            bottomPanel.Controls.Add(saveButton);
            bottomPanel.Controls.Add(closeButton);

            Controls.Add(_grid);
            Controls.Add(bottomPanel);
            Controls.Add(hintLabel);
            Controls.Add(topPanel);

            RebuildGrid();
        }

        private void RebuildGrid()
        {
            _mines = new bool[_rows, _columns];
            _buttons = new Button[_rows, _columns];

            _grid.SuspendLayout();
            _grid.Controls.Clear();
            _grid.RowStyles.Clear();
            _grid.ColumnStyles.Clear();
            _grid.RowCount = _rows;
            _grid.ColumnCount = _columns;

            for (int r = 0; r < _rows; r++)
            {
                _grid.RowStyles.Add(new RowStyle(SizeType.Absolute, ButtonSize));
            }
            for (int c = 0; c < _columns; c++)
            {
                _grid.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, ButtonSize));
            }

            for (int r = 0; r < _rows; r++)
            {
                for (int c = 0; c < _columns; c++)
                {
                    var btn = new Button
                    {
                        Width = ButtonSize,
                        Height = ButtonSize,
                        Margin = new Padding(0),
                        Tag = (r, c),
                        BackColor = SystemColors.Control
                    };
                    btn.Click += MineButton_Click;
                    _grid.Controls.Add(btn, c, r);
                    _buttons[r, c] = btn;
                }
            }

            _grid.ResumeLayout();
            UpdateMineCountLabel();

            ClientSize = new Size(
                Math.Max(_columns * ButtonSize + 20, 420),
                _rows * ButtonSize + 70 + 24 + 45 + 20);
        }

        private void MineButton_Click(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            var (row, col) = ((int, int))btn.Tag;

            _mines[row, col] = !_mines[row, col];
            btn.BackColor = _mines[row, col] ? Color.IndianRed : SystemColors.Control;
            btn.Text = _mines[row, col] ? "*" : "";

            UpdateMineCountLabel();
        }

        private void UpdateMineCountLabel()
        {
            int count = 0;
            foreach (bool isMine in _mines)
            {
                if (isMine) count++;
            }
            _mineCountLabel.Text = $"Postavljeno mina: {count}";
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            int mineCount = 0;
            foreach (bool isMine in _mines)
            {
                if (isMine) mineCount++;
            }

            if (mineCount < GameSettings.MinMines)
            {
                MessageBox.Show(this, $"Potrebno je postaviti bar {GameSettings.MinMines} mina.",
                    "Nedovoljno mina", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var layout = new BoardLayout { Rows = _rows, Columns = _columns };
            for (int r = 0; r < _rows; r++)
            {
                for (int c = 0; c < _columns; c++)
                {
                    if (_mines[r, c])
                    {
                        layout.Mines.Add(new MinePosition(r, c));
                    }
                }
            }

            using var dialog = new SaveFileDialog
            {
                Filter = "XML fajlovi (*.xml)|*.xml",
                FileName = "minesweeper_layout.xml"
            };

            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                XmlFileHelper.Save(layout, dialog.FileName);
                MessageBox.Show(this, "Raspored mina je sacuvan.", "Sacuvano",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
