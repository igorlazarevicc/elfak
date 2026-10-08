using System;
using System.Collections.Generic;

namespace MinesweeperCore
{
    [Serializable]
    public class GameState
    {
        public int Rows { get; set; }
        public int Columns { get; set; }
        public int MineCount { get; set; }
        public int ElapsedSeconds { get; set; }
        public bool GameOver { get; set; }
        public bool Won { get; set; }
        public List<Cell> Cells { get; set; } = new List<Cell>();
    }
}
