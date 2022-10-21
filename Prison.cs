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

                    //if (thieves.Count > 0)
                    //{
                    //    for (int i = 0; i < thieves.Count; i++)
                    //    {
                    //        if (thieves[i].X > 10 || thieves[i].Y > 10)
                    //        {
                    //            thieves[i].X = pos;
                    //            thieves[i].Y = pos;

                    //            //MyPrison[row, cols] = MyPrison[thieves[i].X, thieves[i].Y];
                    //            MyPrison[thieves[i].X, thieves[i].Y] = "T";

                    //           Console.Write(MyPrison[thieves[i].X, thieves[i].Y]);
                    //        }
                    //        else
                    //        {
                    //             Console.Write(MyPrison[row, cols]);
                    //        }
                    //    }
                    //}
                    //else
                    //{
                    //    Console.Write(MyPrison[row, cols]);
                    //}
                    Console.Write(MyPrison[row, cols]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine($"Antal tjuvar i fängelse: {thieves.Count.ToString()}");
        }
    }
}
