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

            int.TryParse(bet, out int betInt);

            Console.WriteLine("");
            Console.WriteLine("");

            while (betInt > money || betInt == 0)
            {
                Console.WriteLine("You can't bet that amount sir");

                Break();

                Console.WriteLine("Place another bet");

                bet = Console.ReadLine();

                int.TryParse(bet, out betInt);
            }

            money -= betInt;

            Break();

            Console.Clear();
            Console.WriteLine("You bet " + betInt + " dollars on horse number " + horses[horseInt]);

            Break();

            Console.WriteLine("You have " + money + " dollars left");

            Thread.Sleep(2000);

            Console.Clear();
            Console.WriteLine("It's time to race!");

            int result = generator.Next(1, 5);

            Break();

            Console.WriteLine("And the winner is... " + horses[result] + "!");

            Break();

            money = Winnings(money, betInt, result, horseInt);

            Break();
            Console.Clear();

            Console.WriteLine("You now have " + money + " dollars!");

            Console.ReadLine();
        }


        static int Winnings(int money, int betInt, int result, int horseInt)
        {
            if (result != horseInt)
            {
                Console.WriteLine("You lost!");

                Break();

                Console.WriteLine("You get nothing!");
            }

            else if (result == horseInt)
            {
                Console.WriteLine("You won!");

                Break();

                Console.WriteLine("You get double your winnings back!");

                betInt *= 2;

                money += betInt;
            }

            return money;
        }

        static void Break()
        {
            Thread.Sleep(1700);
            Console.WriteLine("");
        }
    }
}
