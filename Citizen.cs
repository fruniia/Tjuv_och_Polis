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

        public Citizen(int InitialX, int InitialY, int Direction) : base(InitialX, InitialY, Direction)
        {

            PlayerMarker = "M";
            PlayerColor = ConsoleColor.Green;
            Inventory = new List<Things>();
            
            
        }

        







    }
}
