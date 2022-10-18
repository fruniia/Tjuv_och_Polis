using System;
using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;

namespace TjuvOchPolis
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Game game = new Game();
            game.StartGame();


            //Person - Basklass
            //Tjuvar - T
            //Poliser - P
            //Medborgare - M
            //Klass - Saker - Tjuv - Stöldgods : Polisen - Beslagtaget : Medborgare - Tillhörigheter
            //Inventory - lista med saker
            //Stad -> Skriv ut vad som händer - Newsflash! [X] -> 100x25
            //Alla har properties X-led Y-led, -> <- 
            // 6 olika riktningar slumpmässig riktning - rotera
            //Polis möter tjuv - Polisen tar tjuven, polisen får tjuvens ALLA saker inventory
            //Medborgare möter tjuv ->Tjuven rånar medborgaren på 1 slumpmässig sak medborgaren bär på sig.
            // ->Stöldgodset hamnar i tjuvens inventory
            //Medborgare möter polis - Inget händer
            //Redovisa antal rånade medborgare //Antal gripna tjuvar

            //Game game = new Game();
            //game.StartGame();
            Console.CursorVisible = false;


            //string[,] city = new string[25, 100];

            //City grid = new City(city);
            //grid.DrawGrid();

            //Random random = new Random();
            //int rows = city.GetLength(1);
            //int cols = city.GetLength(0);

            //List<Person> persons = new List<Person>();
            ////Citizen citizen = new Citizen(10, 0);
            ////Police police = new Police(12, 1);
            ////Thief thief = new Thief(14, 2);
            //for (int i = 0; i < 30; i++)
            //{
                
            //    Citizen citizen = new(random.Next(rows), random.Next(cols));
            //    persons.Add(citizen);
            //    if (i < 21)
            //    {
            //        Police police = new(random.Next(rows), random.Next(cols));
            //        persons.Add(police);
                    
            //    }
            //    if (i < 10)
            //    {
            //        Thief thief = new(random.Next(rows), random.Next(cols));
            //        persons.Add(thief);
            //    }
            //}


            //while (true)
            //{
            //    Draw();
            //    Console.Clear();
            //}

            //void Draw()
            //{
            //    //Console.Clear();
            //    //citizen.Draw(); //Rita ut medborgare
            //    //police.Draw(); //Rita ut poliser
            //    //thief.Draw();  //Rita ut tjuvar
            //    //grid.DrawGrid(); //Rita ut spelplanen
            //    foreach (Person person in persons)
            //    {
            //        person.Draw();
                    
            //    }
            //    Console.ReadKey();
            //}

        }
    }
}