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
            string[] horses = { "", "1. Roach", "2. Epona", "3. Agro", "4. Rapidash" };    //Array med hästarna, den första i tom p.g.a att om man skriver en bokstav i en tryparse så blir det 0,
                                                                                           //alltså skulle första hästen väljas om man skrev en bokstav
            
            Random generator = new Random();                                               //En generator som används för att generera användarens pengar nedan.
            int money = generator.Next(100, 2001);
            
            bool again = true;                                                             //Boolen som kan bryta while loopen så att man kommer ut ur spelet.

            while (again == true && money != 0)                     //Ovannämnda while loop, den bryts när "again" inte längre är true eller när användarens pengar är slut.
            {
                Console.WriteLine("Welcome to the horse races!");

                Break();     //Endast en stilistisk metod som jag skapade för att spara plats i koden, istället för att skriva ut alla tomma writelines och sleeps.

                Console.WriteLine("I see you have " + money + " dollars");

                Break();

                Console.WriteLine("Here are todays horses!");
                Console.WriteLine("");

                for (int i = 1; i < horses.Length; i++)       //En for loop för att skriva ut alla hästar på ett sätt som är effektivt och direkt kopplat till arrayen och inte en längre while loop
                {
                    Console.WriteLine(horses[i]);
                    Console.WriteLine("");
                }

                Break();

                Console.WriteLine("Write the number of the horse you want to bet on!");

                string horse = Console.ReadLine();      //Tar in svaret

                int.TryParse(horse, out int horseInt);      //Gör om det till en int

                Thread.Sleep(500);
                Console.Clear();

                while (horseInt == 0 || horseInt > 4)       //Om talet inte är ett möjligt svar, får de försöka igen
                {
                    Console.WriteLine("That is not a valid number, sir");

                    Break();

                    Console.WriteLine("Please choose again");
                    Console.WriteLine("");

                    for (int i = 1; i < horses.Length; i++)     //Den använder sig av samma for loop som tidigare för att skriva ut hästarna igen
                    {
                        Console.WriteLine(horses[i]);
                        Console.WriteLine("");
                    }

                    horse = Console.ReadLine();

                    int.TryParse(horse, out horseInt);

                    Console.WriteLine("");
                    Console.WriteLine("");
                }

                Thread.Sleep(1500);
                Console.Clear();

                Console.WriteLine("You chose horse number " + horses[horseInt] + "!");   //Bekräftelse på hästen användaren valt

                Break();

                Console.WriteLine("How much do you want to bet?");

                Break();

                Console.WriteLine("You have " + money + " dollars"); //Visar hur mycket pengar användaren har igen för att göra det lättare för dem att betta.

                string bet = Console.ReadLine(); //Tar in svaret

                int.TryParse(bet, out int betInt);  //Gör det till en int

                while (betInt > money || betInt == 0)   //Om svaret är högre än deras pengar eller om det är 0 får de inte betta och de måste tänka om
                {
                    Console.WriteLine("");
                    Console.WriteLine("");

                    Console.WriteLine("You can't bet that amount sir");

                    Break();

                    Console.WriteLine("Place another bet");

                    bet = Console.ReadLine();

                    int.TryParse(bet, out betInt);
                }

                money -= betInt;        //Här tas de satsade pengarna bort från användaren

                Break();

                Console.Clear();
                Console.WriteLine("You bet " + betInt + " dollars on horse number " + horses[horseInt]);    //Bekräftelse på satsning och häst.

                Break();

                Console.WriteLine("You have " + money + " dollars left");

                Thread.Sleep(2000);

                Console.Clear();
                Console.WriteLine("It's time to race!");

                int result = generator.Next(1, 5);          //här används samma generator som ovan för att skapa en vinnare

                Break();

                Console.WriteLine("And the winner is... " + horses[result] + "!");   //Här skrivs vinnaren ut

                Break();

                money = Winnings(money, betInt, result, horseInt);      //En metod för att räkna ut hur mcyket pengar användaren ska få

                Break();
                Console.Clear();

                Console.WriteLine("You now have " + money + " dollars!");   //Visar hur mycket användaren nu har

                Break();

                Console.WriteLine("Do you want to have another go? (Y/N)");

                string answer = Console.ReadLine().ToUpper();   //Det tar in svaret och gör det till uppercase så att man kan skriva y och Y, respektive n och N

                Thread.Sleep(1500);
                Console.Clear();

                while (answer != "Y" && answer != "N")                          //Så länge svaret inte är Y eller N kommer frågan ställas igen
                {
                    Console.WriteLine("Excuse me sir, I couldn't hear you");

                    Break();

                    Console.WriteLine("Please say Y or N");

                    answer = Console.ReadLine().ToUpper();
                    Break();
                }

                if (answer == "Y")          //Om de vill spela igen, kommer de komma upp till toppen av while loopen, och "again" forstätter vara true,
                {                           //de kan fortfarande åka ut om de inte har några pengar kvar men skriver Y ändå
                    again = true;
                    Console.Clear();

                    Console.WriteLine("I'll see you back at the betting site, sir");

                    Thread.Sleep(2000);
                    Console.Clear();
                    Thread.Sleep(2000);
                }

                else if (answer == "N") //Om de inte vill spela igen bryts loopen och de blir följda ut
                {
                    again = false;
                }
            }

            Console.Clear();
            Thread.Sleep(1500);

            if (again == false)         //Olika dialoger om de valde att gå ut själva eller ej, här valde användaren att gå ut
            {
                Console.WriteLine("Goodbye sir, your car is waiting for you outside");
            }

            if (money == 0 && again == true)    //Här ville de spela men de hade slut på pengar
            {
                Console.WriteLine("Looks like you are out of money");

                Break();

                Console.WriteLine("Unfortunately you will have to leave, sir");

                Break();

                Console.WriteLine("Your car will be waiting for you outside");
            }

            Console.ReadLine(); //En manuell exit, för att det inte ska gå för snabbt
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
