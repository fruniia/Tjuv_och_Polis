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
        string[,] city = new string[100, 25];

        private Person Person;
        List<Person> persons = new List<Person>();


        public void StartGame()
        {
            Console.CursorVisible = false;
            MyCity = new City(city);
            Random random = new Random();
            int rows = city.GetLength(0);
            int cols = city.GetLength(1);

            for (int i = 0; i < 30; i++)
            {
                int direction = random.Next(0, 8);

                Citizen citizen = new(random.Next(rows), random.Next(cols), direction);
                persons.Add(citizen);
                //Random för direction.


                if (i < 21)
                {
                    Police police = new(random.Next(rows), random.Next(cols), direction);
                    persons.Add(police);

                }
                if (i < 10)
                {
                    Thief thief = new(random.Next(rows), random.Next(cols), direction);
                    persons.Add(thief);
                }
            }


            while (true)
            {
                Draw();
                ListOfPersons();
                Console.ReadKey();
            }

            void Draw()
            {
                Console.Clear();
                MyCity.DrawGrid();


                foreach (Person person in persons)
                {
                    person.Draw();

                    switch (person.Z)
                    {
                        case 0:
                            if (person.Y > 0)
                            { person.WalkUp(); }
                            else if (person.Y == 0)
                                person.Y = cols - 1;
                            break;
                        case 1:
                            if (person.Y < cols - 1)
                            { person.WalkDown(); }
                            else if (person.Y == cols - 1)
                                person.Y = 0;
                            break;
                        case 2:
                            if (person.X > 0)
                            { person.WalkLeft(); }
                            else if (person.X == 0)
                                person.X = rows - 1;
                            break;
                        case 3:
                            if (person.X < rows - 1)
                            { person.WalkRight(); }
                            else if (person.X == rows - 1)
                                person.X = 0;
                            break;
                        case 4:
                            if (person.X > 0 && person.Y > 0)
                            { person.WalkUpLeft(); }
                            else if (person.X == 0 || person.Y == 0)
                            {
                                if (person.X == 0)
                                {
                                    person.X = (cols - 1) - person.Y;
                                    person.Y = cols - 1;
                                }
                                else if (person.Y == 0)
                                {
                                    person.Y = ((rows - 1) - person.X);
                                    if (person.Y > cols)
                                    {
                                        person.Y = cols - 1;
                                        person.X = cols + person.X;
                                    }
                                    else if (person.Y < cols - 1)
                                        person.X = rows - 1;
                                }
                            }
                            break;
                        case 5:
                            if (person.X < rows - 1 && person.Y > 0)
                            { person.WalkUpRight(); }
                            else if (person.X == rows - 1 || person.Y == 0)
                            {
                                if (person.X == rows - 1)
                                {
                                    person.X = (rows - 1) - ((cols - 1) - person.Y);
                                    person.Y = cols - 1;
                                }
                                else if (person.Y == 0)
                                {
                                    person.Y = ((rows - 1) - person.X);
                                    if (person.Y < cols - 1)
                                    {
                                        person.Y = cols - 1;
                                        person.X = person.X - (cols - 1);
                                    }
                                    else if (person.Y > cols - 1)
                                    {
                                        person.Y = person.X;
                                        if (person.X > cols - 1)
                                        {
                                            person.Y = cols - 1;
                                            person.X = person.X - (cols - 1);
                                        }
                                        else
                                            person.X = 0;
                                    }
                                }
                            }
                            break;
                        case 6:
                            if (person.X > 0 && person.Y < cols - 1)
                            { person.WalkDownLeft(); }
                            else if (person.X == 0 || person.Y == cols - 1)
                            {
                                if (person.X == 0)
                                {
                                    person.X = person.Y;
                                    person.Y = 0;
                                }
                                else if (person.Y == cols - 1)
                                {
                                    person.Y = ((rows - 1) - person.X);
                                    if (person.Y > cols)
                                    {
                                        person.Y = 0;
                                        person.X = (cols - 1) + person.X;
                                    }
                                    else if (person.Y < cols - 1)
                                    {
                                        person.Y = (rows - 1) - person.X;
                                        person.Y = (cols - 1) - person.Y;
                                        person.X = rows - 1;
                                    }
                                }
                            }
                            break;
                        case 7:
                            if (person.X < rows - 1 && person.Y < cols - 1)
                            { person.WalkDownRight(); }
                            else if (person.X == rows - 1 || person.Y == cols - 1)
                            {
                                if (person.X == rows - 1)
                                {
                                    person.X = (rows - 1) - person.Y;
                                    person.Y = 0;
                                }
                                else if (person.Y == cols - 1)
                                {
                                    person.Y = ((rows - 1) - person.X);
                                    if (person.Y > cols)
                                    {
                                        person.Y = 0;
                                        person.X = person.X - (cols - 1);
                                        if (person.X < 0)
                                        {
                                            person.Y = (-person.X);
                                            person.X = 0;
                                        }
                                    }
                                    else if (person.Y < cols - 1)
                                    {
                                        person.Y = 0;
                                        person.X = person.X - (cols - 1);
                                    }
                                }
                            }
                            break;
                        case 8: person.StayStill(); break;
                    }
                }

                Thread.Sleep(200);
                Console.ReadKey();



            }
        }

        private void ListOfPersons()
        {
            for (int i = 0; i < persons.Count; i++)
            {

                Console.WriteLine($"{persons[i].GetType().Name}  {persons[i].X}, {persons[i].Y}");
            }
        }
    }
}
