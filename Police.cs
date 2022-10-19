using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TjuvOchPolis
{
    internal class Police : Person
    {
        public List<Thing> Confiscated;
        public Police(int InitialX, int InitialY, int Direction) : base(InitialX, InitialY, Direction)
        {
            PlayerMarker = "P";
            PlayerColor = ConsoleColor.Cyan;
            Confiscated = new List<Thing>();
        }

    }
}
