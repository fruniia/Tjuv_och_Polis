using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TjuvOchPolis
{
    internal class City
    {
        public string[,] Grid { get; set; }
        public int Rows;
        public int Cols;

        public City(string[,] grid)
        {
            Grid = grid;
            Cols = Grid.GetLength(0);
            Rows = Grid.GetLength(1);
        }

        public void DrawGrid()
        {
            for (int row = 0; row < Rows; row++)
            {
                for (int cols = 0; cols < Cols; cols++)
                {
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
