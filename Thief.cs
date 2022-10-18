using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TjuvOchPolis
{
    internal class Thief : Person
    {
        public Thief(int InitialX, int InitialY, int Direction) : base(InitialX, InitialY, Direction)
        {
            PlayerMarker = "T";
            PlayerColor = ConsoleColor.Red;
        }
        List<Things> stolenGoods = new List<Things>();
    }
}
