using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TjuvOchPolis
{
    internal class Person
    {
       
        public List<Things> Inventory { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public List<Person> People { get; set; } //Eventuellt i GameLoopen
        protected string PlayerMarker;
        protected ConsoleColor PlayerColor;

        

        public Person(int InitialX, int InitialY)
        {
            X = InitialX;
            Y = InitialY;
            Inventory = new List<Things>(); //Lägg till i Thief/Police/Citizen
            PlayerMarker = "*";
            PlayerColor = ConsoleColor.Magenta;
        }

        public void AddGoods()
        {
            Inventory.Add(new Things());
        }

        public void RemoveGoods()
        { 
            Inventory.RemoveAt(Inventory.Count - 1);
        }
        public void Draw()
        {
            Console.ForegroundColor = PlayerColor;
            Console.SetCursorPosition(X, Y);
            Console.Write(PlayerMarker);
            Console.ResetColor();
        }
        public void WalkUp(int x, int y)
        {
            Y = y--;
        }

        public void WalkDown(int x, int y)
        {
            Y = y++;
        }

        public void WalkLeft(int x, int y)
        {
            X = x--;
        }

        public void WalkRight(int x, int y)
        {
            X = x++;
        }

        public void WalkUpRight(int x, int y)
        {
            Y = y--;
            X = x++;
        }
        public void WalkUpLeft(int x, int y)
        {
            Y = y--;
            X = x--;
        }

        public void WalkDownRight(int x, int y)
        {
            Y = y++;
            X = x++;
        }

        public void WalkDownLeft(int x, int y)
        {
            Y = y++;
            X = x--;
        }

        public void StayStill(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
