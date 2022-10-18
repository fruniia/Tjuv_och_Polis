using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TjuvOchPolis
{
    internal class Thief : Person
    {
        List<Thing> StolenGoods = new List<Thing>();
        public Thief(int InitialX, int InitialY, int Direction) : base(InitialX, InitialY, Direction)
        {
            PlayerMarker = "T";
            PlayerColor = ConsoleColor.Red;
        }
   
    }
}
