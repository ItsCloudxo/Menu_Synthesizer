using System;
using System.Speech.Synthesis;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ugeløn_Synthesizer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool loop = true;
            while (loop == true)
            {
                var synthesizer = new SpeechSynthesizer();
                synthesizer.SetOutputToDefaultAudioDevice();


                Console.WriteLine("1. Calculate hourly wage");
                Console.WriteLine("2. Calcualate salary influence on SU");
                string menuInput1 = Console.ReadLine();
                //Her benytter jeg en switch, da jeg anser denne løsning som værende den nemmeste i tale om menuer. 
                //En switch opstiller en række cases, og betingelsen for at en case bliver kørt, er at betingelsen er opfyldt.
                //Denne løsning gør at man kan undgå mange små if statements, og brugerinput risikerer ikke at give uønsket resultat.
                switch (menuInput1)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("Welcome to Youth Advice's move away from home service");
                        Console.WriteLine("Enter your name here:");
                        synthesizer.Speak("Welcome to Youth Advice's move away from home service. Enter your name here:");
                        string brugerNavn = Console.ReadLine();
                        Console.Clear();

                        Console.WriteLine("Enter your hourly wage:");
                        synthesizer.Speak("Enter your hourly wage");
                        string timeløn = Console.ReadLine();
                        Console.Clear();

                        Console.Write("How many hours a week do you work: ");
                        synthesizer.Speak("How many hours a week do you work");
                        string timer = Console.ReadLine();
                        Console.Clear();

                        double ugeløn = Convert.ToDouble(timeløn) * Convert.ToDouble(timer);

                        Console.WriteLine($"Hello {brugerNavn}, your weekly salary is {ugeløn} dkk.");
                        synthesizer.Speak($"Hello {brugerNavn}, your weekly salary is {ugeløn} dkk.");


                        //For at beregne mængden af stjerner der skal skrives, tager vi ugelønen modulus 100
                        //(Dette dividerer ugeløn med 100, til nærmeste heltal, og benytter rest værdien til at udregne-
                        // hvad ugelønen er som et tal 100 går op i.)
                        //Hvis vi ikke gør dette, kan der opstå problemer når vi sætter vores betingelse, som accepterer-
                        // alt over 1 og under 100 som 100. Til sidst lægger vi bare 100 til vores integer, og den kører-
                        // koden i vores løkke indtil den er samme værdi som vores ugeløn. Dermed får vi en stjerne for- 
                        // hver 100kr. i ugeløn.
                        for (int a = 0; a < ugeløn - ugeløn % 100; a += 100)
                        {
                            Console.Write("*");
                        }


                        if (ugeløn > 2600)
                        {
                            Console.WriteLine("\nYou can afford to move away from home.");
                            synthesizer.Speak("You can afford to move away from home.");

                        }
                        else
                        {
                            Console.WriteLine("\nYou can't afford to move away from home.");
                            synthesizer.Speak("You can't afford to move away from home.");

                        }

                        Console.ReadLine();
                        Console.Clear();

                        break;

                    case "2":
                        Console.Clear();
                        Console.WriteLine("Hello, welcome to the Youth Advice's calculator for salary influence on SU");
                        Console.WriteLine("Which education level are you currently pursuing:");
                        Console.WriteLine("1. Youth Education");
                        Console.WriteLine("2. Furthergoing Education");
                        string menuInput2 = Console.ReadLine();
                        switch (menuInput2)
                        {
                            case "1":
                                Console.Clear();
                                Console.WriteLine("Enter your weekly salary before tax:");
                                string weeklySalary1 = Console.ReadLine();
                                double suMax1 = 9178;

                                if (Convert.ToDouble(weeklySalary1) > suMax1)
                                {
                                    Console.WriteLine("Your SU will be nulled.");
                                    Console.ReadLine();
                                    Console.Clear();
                                }
                                else
                                {
                                    Console.WriteLine("Your SU will not be affected.");
                                    Console.ReadLine();
                                    Console.Clear();

                                }

                                break;


                            case "2":
                                Console.Clear();
                                Console.WriteLine("Enter your weekly salary before tax:");
                                string weeklySalary2 = Console.ReadLine();
                                double suMax2 = 13876;

                                if (Convert.ToDouble(weeklySalary2) > suMax2)
                                {
                                    Console.WriteLine("Your SU will be nulled.");
                                    Console.ReadLine();
                                }
                                else
                                {
                                    Console.WriteLine("Your SU will not be affected.");
                                    Console.ReadLine();
                                }
                                break;


                            default:
                                Console.WriteLine("Faulty input, try again.");
                                Console.ReadLine();
                                Console.Clear();
                                break;
                        }
                        break;

                    default:
                        Console.WriteLine("Faulty input, try again.");
                        Console.ReadLine();
                        Console.Clear();
                        break;

                }
            }

            
            
        }
    }
}
