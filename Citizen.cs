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
            Belongings.Add(new Money());
            Belongings.Add(new Keys());
            Belongings.Add(new Watch());
            Belongings.Add(new CellPhone());
        }

        public void RemoveGoods(int removeThing)
        {
            Belongings.RemoveAt(removeThing);
        }
    }
}
