using System;

namespace MinesweeperCore
{
    
    [Serializable]
    public class GameSettings
    {
        public const int MinRows = 9;
        public const int MinColumns = 9;
        public const int MinMines = 10;

        public int Rows { get; set; } = MinRows;
        public int Columns { get; set; } = MinColumns;
        public int MineCount { get; set; } = MinMines;

        public GameSettings()
        {
        }

        public GameSettings(int rows, int columns, int mineCount)
        {
            Rows = rows;
            Columns = columns;
            MineCount = mineCount;
        }

        public static GameSettings CreateDefault()
        {
            return new GameSettings(MinRows, MinColumns, MinMines);
        }


        /// da li podesavanja zadovoljavaju minimalne uslovve

        public bool IsValid(out string error)
        {
            if (Rows < MinRows)
            {
                error = $"Broj redova ne moze biti manji od {MinRows}.";
                return false;
            }
            if (Columns < MinColumns)
            {
                error = $"Broj kolona ne moze biti manji od {MinColumns}.";
                return false;
            }
            if (MineCount < MinMines)
            {
                error = $"Broj mina ne moze biti manji od {MinMines}.";
                return false;
            }
            if (MineCount >= Rows * Columns)
            {
                error = "Broj mina mora biti manji od ukupnog broja polja na tabli.";
                return false;
            }

            error = null;
            return true;
        }
    }
}
