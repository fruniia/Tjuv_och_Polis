using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TjuvOchPolis
{
    internal class City
    {
        private string[,] Grid { get; set; }
        private int Rows;
        private int Cols;

        public City(string[,] grid)
        {
            Grid = grid;
            Rows = Grid.GetLength(0);
            Cols = Grid.GetLength(1);
            DrawGrid();
        }

        public void DrawGrid()
        {
            for (int row = 0; row < Grid.GetLength(0); row++)
            {
                for (int cols = 0; cols < Grid.GetLength(1); cols++)
                {
                    string position = Grid[row, cols];
                    Console.Write(".");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
