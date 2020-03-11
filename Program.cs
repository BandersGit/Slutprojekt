using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Slutprojekt
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] horses = { "Nope", "1. Roach", "2. Epona", "3. Agro", "4. Rapidash" };
            int money = 1000;

            Console.WriteLine("Welcome to the horse races!");

            Console.WriteLine("I see you have " + money + " dollars");

            Console.WriteLine("Here are todays horses!");

            for (int i = 1; i < horses.Length; i++)
            {
                Console.WriteLine(horses[i]);
                Console.WriteLine("");
            }

            Console.WriteLine("Write the number of the horse you want to bet on!");

            string horse = Console.ReadLine();

            int.TryParse(horse, out int horseInt);

            Thread.Sleep(1000);
            Console.Clear();

            while (horseInt == 0 || horseInt > 4)
            {
                Console.WriteLine("That is not a valid number, sir");
                Console.WriteLine("Please choose again");

                for (int i = 1; i < horses.Length; i++)
                {
                    Console.WriteLine(horses[i]);
                    Console.WriteLine("");
                }

                horse = Console.ReadLine();

                int.TryParse(horse, out  horseInt);

                Thread.Sleep(1000);
                Console.Clear();
            }


            
            Console.WriteLine( "You chose horse number " + horses[horseInt] + "!");
            Thread.Sleep(2000);

            Console.WriteLine("How much do you want to bet?");
            Console.WriteLine("You have " + money + " dollars");

            string bet = Console.ReadLine();

            int.TryParse(bet, out int betint);

            while (betint > money)
            {
                Console.WriteLine("You can't do that sir");
                Console.WriteLine("Place another bet");

                bet = Console.ReadLine();

                int.TryParse(bet, out betint);
            }

            money -= betint;

            Console.WriteLine(betint);
            Console.WriteLine(money);



            //Bestäm användarens pengar

            //Kom in till hästbanan

            //Betta på en häst

            //Hästarna springer

            //Få in resultatet, jämför med hästan man bettade på

            //Bestäm om användaren tjänar eller förlorar pengar

            //GO AGAIN?


            Console.ReadLine();

        }
    }
}
