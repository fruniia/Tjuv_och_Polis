using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TjuvOchPolis
{
    internal class Police : Person
    {
        public Police(int InitialX, int InitialY) : base(InitialX, InitialY)
        {
            PlayerMarker = "P";
            PlayerColor = ConsoleColor.Cyan;
            Inventory = new List<Things>();  
        }

        List<Things> confiscated = new List<Things>();
    }
}
