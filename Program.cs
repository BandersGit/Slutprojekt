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
            string[] horses = { "", "1. Roach", "2. Epona", "3. Agro", "4. Rapidash" };
            Random generator = new Random();
            int money = generator.Next(100, 2001);
            
            Console.WriteLine("Welcome to the horse races!");

            Break();

            Console.WriteLine("I see you have " + money + " dollars");

            Break();

            Console.WriteLine("Here are todays horses!");
            Console.WriteLine("");

            for (int i = 1; i < horses.Length; i++)
            {
                Console.WriteLine(horses[i]);
                Console.WriteLine("");
            }

            Break();

            Console.WriteLine("Write the number of the horse you want to bet on!");

            string horse = Console.ReadLine();

            int.TryParse(horse, out int horseInt);

            Thread.Sleep(500);
            Console.Clear();

            while (horseInt == 0 || horseInt > 4)
            {
                Console.WriteLine("That is not a valid number, sir");

                Break();

                Console.WriteLine("Please choose again");
                Console.WriteLine("");

                for (int i = 1; i < horses.Length; i++)
                {
                    Console.WriteLine(horses[i]);
                    Console.WriteLine("");
                }

                horse = Console.ReadLine();

                int.TryParse(horse, out horseInt);

                Console.WriteLine("");
                Console.WriteLine("");
            }

            Thread.Sleep(1000);
            Console.Clear();

            Console.WriteLine("You chose horse number " + horses[horseInt] + "!");

            Break();

            Console.WriteLine("How much do you want to bet?");

            Break();

            Console.WriteLine("You have " + money + " dollars");

            string bet = Console.ReadLine();

            int.TryParse(bet, out int betint);

            Console.WriteLine("");
            Console.WriteLine("");

            while (betint > money)
            {
                Console.WriteLine("You can't do that sir");

                Break();

                Console.WriteLine("Place another bet");

                bet = Console.ReadLine();

                int.TryParse(bet, out betint);
            }

            money -= betint;

            Break();

            Console.Clear();
            Console.WriteLine("You bet " + betint + " dollars on " + horses[horseInt]);

            Break();

            Console.WriteLine("You have " + money + " dollars left");

            Break();

            Console.Clear();
            Console.WriteLine("It's time to race!");

            

            int result = generator.Next(1, 5);

            Break();

            Console.WriteLine("And the winner is... " + horses[result] + "!");

            Break();

            if (result != horseInt)
            {
                Console.WriteLine("You lost!");
            }

            else if (result == horseInt)
            {
                Console.WriteLine("You won!");
            }





            //Bestäm användarens pengar

            //Kom in till hästbanan

            //Betta på en häst

            //Hästarna springer

            //Få in resultatet, jämför med hästen man bettade på

            //Bestäm om användaren tjänar eller förlorar pengar

            //GO AGAIN?


            Console.ReadLine();

        }

        static void Break()
        {
            Thread.Sleep(1700);
            Console.WriteLine("");
        }
    }
}
