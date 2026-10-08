using System;
using System.Collections.Generic;

namespace MinesweeperCore
{
    [Serializable]
    public class MinePosition
    {
        public int Row { get; set; }
        public int Col { get; set; }

        public MinePosition()
        {
        }

        public MinePosition(int row, int col)
        {
            Row = row;
            Col = col;
        }
    }

    [Serializable]
    public class BoardLayout
    {
        public int Rows { get; set; }
        public int Columns { get; set; }
        public List<MinePosition> Mines { get; set; } = new List<MinePosition>();
    }
}
