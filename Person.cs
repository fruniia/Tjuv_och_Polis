using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TjuvOchPolis
{
    internal class Person
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }

        protected string PlayerMarker;
        protected ConsoleColor PlayerColor;
        private int initialX;
        private int initialY;

        public Person(int InitialX, int InitialY, int Direction)
        {
            X = InitialX;
            Y = InitialY;
            Z = Direction;

            PlayerMarker = "*";
            PlayerColor = ConsoleColor.Magenta;
        }


        public virtual void AddGoods(List<Thing> things)
        {
                things.Add(new Thing());
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
    }
}
