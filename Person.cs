using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TjuvOchPolis
{
    internal class Person
    {
        //public List<Thing> Inventory { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }
        public List<Person> People { get; set; } //Eventuellt i GameLoopen
        protected string PlayerMarker;
        protected ConsoleColor PlayerColor;
        private int initialX;
        private int initialY;

        public Person(int InitialX, int InitialY, int Direction)
        {
            X = InitialX;
            Y = InitialY;
            Z = Direction;
           //Inventory = new List<Thing>(); //Lägg till i Thief/Police/Citizen
            PlayerMarker = "*";
            PlayerColor = ConsoleColor.Magenta;
        }

        public Person(int initialX, int initialY)
        {
            this.initialX = initialX;
            this.initialY = initialY;
        }

        public void AddGoods(List<Thing> things, string newThing)
        {
            things.Add(new Thing(newThing));
        }

        public void RemoveGoods(List<Thing> things)
        {
            //things.RemoveAt(things.Count - 1);
        }

        public void Draw()
        {
            Console.ForegroundColor = PlayerColor;
            Console.SetCursorPosition(X, Y);
            Console.Write(PlayerMarker);
            Console.ResetColor();
        }

        public void WalkUp()
        {
            Y--;
        }

        public void WalkDown()
        {
            Y++;
        }

        public void WalkLeft()
        {
            X--;
        }

        public void WalkRight()
        {
            X++;
        }

        public void WalkUpRight()
        {
            Y--;
            X++;
        }
        public void WalkUpLeft()
        {
            Y--;
            X--;
        }

        public void WalkDownRight()
        {
            Y++;
            X++;
        }

        public void WalkDownLeft()
        {
            Y++;
            X--;
        }

        public void StayStill()
        {
            X = X;
            Y = Y;
        }

        public void DirectionMove(int random)
        {
            switch(random)
            {
                case 0: WalkUp(); break;
                case 1: WalkDown(); break;
                case 2: WalkLeft(); break;
                case 3: WalkRight(); break;
                case 4: WalkUpLeft(); break;
                case 5: WalkUpRight(); break;
                case 6: WalkDownLeft(); break;
                case 7: WalkDownRight(); break;
                case 8: StayStill(); break;
            }

        }
    }
}
