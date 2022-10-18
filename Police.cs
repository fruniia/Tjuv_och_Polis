using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TjuvOchPolis
{
    internal class Police : Person
    {
        List<Thing> Confiscated = new List<Thing>();
        public Police(int InitialX, int InitialY) : base(InitialX, InitialY)
        {
            PlayerMarker = "P";
            PlayerColor = ConsoleColor.Cyan;
        }

    }
}
