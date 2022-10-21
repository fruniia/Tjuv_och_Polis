using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TjuvOchPolis
{
    internal class Prison : City
    {
        string[,] MyPrison = {
                {"-", "-", "-", "-", "-", "-", "-", "-", "-", "-", "-", "-"},
                { "|", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "|" },
                { "|", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "|" },
                { "|", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "|" },
                { "|", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "|" },
                { "|", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "|" },
                { "|", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "|" },
                { "|", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "|" },
                { "|", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "|" },
                { "|", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "|" },
                { "|", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "|" },
                {"-", "-", "-", "-", "-", "-", "-", "-", "-", "-", "-", "-"}

            };
        public Prison(string[,] grid) : base(grid)
        {
           
        }

        public void DrawGrid(List<Thief> thieves)
        {
            Random random = new Random();
            int pos = random.Next(1,11);
            for (int row = 0; row < MyPrison.GetLength(0); row++)
            {
                for (int cols = 0; cols < MyPrison.GetLength(1); cols++)
                {
                    Console.Write(MyPrison[row, cols]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine($"Antal tjuvar i fängelse: {thieves.Count.ToString()}");
        }
    }
}
