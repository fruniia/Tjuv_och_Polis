using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TjuvOchPolis
{
    internal class Citizen : Person
    {
        public List<Thing> Belongings = new List<Thing>();

        public Citizen(int InitialX, int InitialY, int Direction) : base(InitialX, InitialY, Direction)
        {
            PlayerMarker = "M";
            PlayerColor = ConsoleColor.Green;
            Belongings.Add(new Thing("wallet"));
            Belongings.Add(new Thing("keys"));
            Belongings.Add(new Thing("cellPhone"));
            Belongings.Add(new Thing("watch"));
        }
    }
}
