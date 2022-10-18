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


        }
    }
}