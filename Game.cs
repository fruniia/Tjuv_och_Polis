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
        private City? MyCity;
        private Prison MyPrison;
        string[,] city = new string[100, 25];
        string[,] prison = new string[11, 11];
        List<Person> persons = new List<Person>();
        List<Thief> thieves = new List<Thief>();
        int numberOfRobberys = 0;
        int freeThieves = 0;
        Random random = new Random();

        public void StartGame()
        {
            Console.CursorVisible = false;
            Console.Title = "Tjuv och polis";
            MyCity = new City(city);
            MyPrison = new Prison(prison);
            int rows = city.GetLength(0);
            int cols = city.GetLength(1);

            for (int i = 0; i < 30; i++)
            {
                int direction = random.Next(0, 9);

                Citizen citizen = new(random.Next(rows), random.Next(cols), direction);
                persons.Add(citizen);

                if (i < 10)
                {
                    Police police = new(random.Next(rows), random.Next(cols), direction);
                    persons.Add(police);

                }
                if (i < 20)
                {
                    Thief thief = new(random.Next(rows), random.Next(cols), direction);
                    persons.Add(thief);
                    freeThieves++;
                }

            }

            while (true)
            {
                Console.SetCursorPosition(0, 0);
                MyCity.DrawGrid();
                Draw();

                for (int i = 0; i < persons.Count; i++)
                {
                    for (int j = 0; j < persons.Count; j++)
                    {
                        if (persons[i].X == persons[j].X && persons[i].Y == persons[j].Y)
                        {
                            if (persons[i] is Police && persons[j] is Thief)
                            {
                                if (((Thief)persons[j]).StolenGoods.Count > 0)
                                {
                                    ((Police)persons[i]).AddGoods(((Thief)persons[j]).StolenGoods);
                                    ((Thief)persons[j]).NumberOfStolenGoods = ((Thief)persons[j]).StolenGoods.Count;
                                    ((Thief)persons[j]).StolenGoods.Clear();
                                    ((Thief)persons[j]).Arrested = true;
                                    if (((Thief)persons[j]).Arrested == true)
                                    {
                                        thieves.Add((Thief)persons[j]);
                                        persons.RemoveAt(j);
                                        freeThieves--;
                                    }

                                    //Ändra P & T till en Stjärna *
                                    Console.SetCursorPosition(35, 26);
                                    Console.WriteLine($"Polis tar tjuv på position {persons[i].X}, {persons[i].Y}");
                                    Thread.Sleep(2000);
                                    Console.SetCursorPosition(35, 26);
                                    Console.WriteLine($"                                    ");

                                }

                            }
                            if (persons[i] is Citizen && persons[j] is Thief)
                            {
                                if (((Citizen)persons[i]).Belongings.Count > 0)
                                {
                                    numberOfRobberys++;

                                    int removeThing = random.Next(0, ((Citizen)persons[i]).Belongings.Count);
                                    ((Thief)persons[j]).AddGoods(((Citizen)persons[i]).Belongings, removeThing);
                                    ((Citizen)persons[i]).RemoveGoods(removeThing);
                                    Console.SetCursorPosition(35, 27);
                                    Console.WriteLine($"Tjuv rånar medborgare på position {persons[i].X}, {persons[i].Y}");
                                    Thread.Sleep(2000);
                                    Console.SetCursorPosition(35, 27);
                                    Console.WriteLine("                                          ");
                                    //Ändra C & T till en Stjärna *
                                }
                            }
                        }
                    }
                }
                //Console.ReadKey();
                DrawThief();
            }

            void Draw()
            {
                //Console.Clear();
                //DrawThief();
                //ListOfPersons();


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
                Thread.Sleep(15);
            }
        }


        private void ListOfPersons()
        {
            int count = 0;

            for (int i = 0; i < persons.Count; i++)
            {

                Console.SetCursorPosition(101, count);
                Console.WriteLine($"                                                                               ");
                if (persons.Count < 60)  // Hårdkodat talet. Ändras totalen i listan måste man sätta samma tal till höger om <.
                {
                    Console.SetCursorPosition(101,persons.Count);
                    Console.WriteLine($"                                                                               ");
                    Console.WriteLine($"                                                                               ");
                }
                Console.SetCursorPosition(101, count);
                Console.Write($"{persons[i].GetType().Name}:\t{persons[i].X}, {persons[i].Y}\t");
                if (persons[i] is Citizen)
                {
                    var a = ((Citizen)persons[i]).Belongings;
                    foreach (var b in a.ToList())
                    {
                        Console.Write($"{b.thingName} ");
                    }
                }
                else if (persons[i] is Thief)
                {
                    var a = ((Thief)persons[i]).StolenGoods;
                    foreach (var b in a.ToList())
                    {
                        Console.Write($"{b.thingName} ");
                    }
                }
                else if (persons[i] is Police)
                {
                    var a = ((Police)persons[i]).Confiscated;
                    foreach (var b in a.ToList())
                    {
                        Console.Write($"{b.thingName} ");
                    }
                }
                Console.WriteLine($"");

                count++;
            }
        }
        private void DrawThief()
        {
            Console.SetCursorPosition(0, 26);
            MyPrison.DrawGrid(thieves);
            Console.WriteLine($"Antal rånade personer: {numberOfRobberys}");
            Console.WriteLine($"Antal tjuvar på fri fot: {freeThieves}");

            foreach (Thief person in thieves.ToList())
            {
                int rows = 11;
                int cols = 37;
                int randomX = random.Next(1, 10);
                int randomY = random.Next(27, 35);

                if (person.X < 100 && person.Y < 25)
                {
                    person.X = randomX;
                    person.Y = randomY;
                    person.NumberOfStolenGoods *= 20;
                }

                person.Draw();


                switch (person.Z)
                {
                    case 0:
                        if (person.Y > 27)
                        { person.WalkUp(); }
                        else if (person.Y == 27)
                            person.Y = cols;
                        break;
                    case 1:
                        if (person.Y < cols - 1)
                        { person.WalkDown(); }
                        else if (person.Y == cols - 1)
                            person.Y = 27;
                        break;
                    case 2:
                        if (person.X > 1)
                        { person.WalkLeft(); }
                        else if (person.X == 1)
                            person.X = rows - 1;
                        break;
                    case 3:
                        if (person.X < rows - 1)
                        { person.WalkRight(); }
                        else if (person.X == rows - 1)
                            person.X = 1;
                        break;
                    case 4:
                        if (person.X > 1 && person.Y > 26)
                        { person.WalkUpLeft(); }
                        else if (person.X == 1 || person.Y == 26)
                        {
                            if (person.X == 1)
                            {
                                person.X = (cols - 1) - person.Y;
                                person.Y = cols - 1;
                            }
                            else if (person.Y == 26)
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
                        if (person.X < rows - 1 && person.Y > 26)
                        { person.WalkUpRight(); }           //Fungerar men ej rätt matematik.
                        else if (person.X == rows - 1 || person.Y == 26)
                        {
                            if (person.X == rows - 1)
                            {
                                person.X = (rows - 1) - ((cols - 1) - person.Y);
                                person.Y = cols - 1;
                            }
                            else if (person.Y == 26)
                            {
                                person.Y = ((rows - 1) - person.X);
                                if (person.Y < cols - 1)
                                {
                                    person.Y = cols - 1;
                                    person.X = 1;
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
                                        person.X = 1;
                                }
                            }
                        }
                        break;
                    case 6:
                        if (person.X > 1 && person.Y < cols - 1)
                        { person.WalkDownLeft(); }          //Fungerar men ej rätt matematik.
                        else if (person.X == 1 || person.Y == cols - 1)
                        {
                            if (person.X == 1)
                            {
                                person.X = (cols - 1) - person.Y;
                                person.Y = 27;
                            }
                            else if (person.Y == cols - 1)
                            {
                                person.Y = ((rows - 1) - person.X);
                                if (person.Y > cols)
                                {
                                    person.Y = 26;
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
                                person.X = rows - person.X;
                                person.Y = 27;
                            }
                            else if (person.Y == cols - 1)
                            {
                                person.Y = ((rows - 1) - person.X);
                                if (person.Y > cols)
                                {
                                    person.Y = 27;
                                    person.X = person.X - (cols - 1);
                                    if (person.X < 1)
                                    {
                                        person.Y = 26;
                                        person.X = 1;
                                    }
                                }
                                else if (person.Y < cols - 1)
                                {
                                    person.Y = 26;
                                    person.X = 1;
                                }
                            }
                        } //Fungerar men ej rätt matematik.
                        break;
                    case 8: person.StayStill(); break;
                }
                person.NumberOfStolenGoods--;
                if (person.NumberOfStolenGoods == 0)
                {
                    person.Arrested = false;
                    thieves.Remove(person);
                    person.Y = random.Next(0, 25);
                    person.X = random.Next(0, 100);
                    persons.Add(person);
                    freeThieves++;
                }
            }


        }
    }
}
