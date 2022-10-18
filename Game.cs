using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TjuvOchPolis
{
    internal class Game
    {

        private City MyCity;
        string[,] city = new string[25, 100];

        private Person Person;
        List<Person> persons = new List<Person>();


        public void StartGame()
        {
            Console.CursorVisible = false;
            MyCity = new City(city);


            Random random = new Random();
            int rows = city.GetLength(1);
            int cols = city.GetLength(0);
            int direction = random.Next(0,9);

            for (int i = 0; i < 10; i++)
            {

                Citizen citizen = new(random.Next(rows), random.Next(cols),direction);
                persons.Add(citizen);
                        //Random för direction.


                //if (i < 21)
                //{
                //    Police police = new(random.Next(rows), random.Next(cols));
                //    persons.Add(police);

                //}
                //if (i < 10)
                //{
                //    Thief thief = new(random.Next(rows), random.Next(cols));
                //    persons.Add(thief);
                //}
            }




            while (true)
            {
                Draw();    
            }

            void Draw()
            {
                Console.Clear();
                MyCity.DrawGrid();
                int direction = random.Next(0,9);
                foreach (Person person in persons)
                {
                    person.Draw();
                    person.DirectionMove(direction);            //If 1 gå så.
                }


                Console.ReadKey();
            }

        }
    }
}
