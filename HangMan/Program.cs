using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Threading;

namespace HangMan
{
    class Program
    {
        static void Main(string[] args)
        {
            Game();
        }
        public static void Game()
        {
            string ordet =  Word();  
            List<char> exempelord = new List<char>();  //creating list for exampleword
            foreach (char c in ordet)//loop putting all chars of word in exampleword
            {
                exempelord.Add(c);
            }
            char gissningsbokstav = ' '; //letterguess
            List<char> rättcharlist = new List<char>();//list for right guesses
            List<char> gissningar = new List<char>();//list for all guesses
            bool won = false;
            Console.Clear();
            Console.WriteLine("Hela ordet du ska gissa på är:");//shows amount of letters in the word before playing
            foreach (int e in ordet)
            {
                Console.Write("*");
            }
            Console.WriteLine();
            int point = ordet.Length;
            int fel = 0;
            do
            {
                int gamlavärdet = rättcharlist.Count;
                int inskrivnaförsök = gamlavärdet;
                Console.WriteLine("Skriv in en bokstav:");
                gissningsbokstav = Console.ReadKey().KeyChar; //enter a char into gissningsbokstav
                Console.WriteLine();
                gissningar.Add(gissningsbokstav);           //add letter to allguesses
                for (int i = 0; i < exempelord.Count; i++)
                {

                    if (rättcharlist.Contains(exempelord[i]))
                    {
                        Console.Write(exempelord[i]);//write out letter
                    }
                    else if (exempelord[i] == gissningsbokstav)//if guessingletter == letter in word
                    {
                        Console.Write(gissningsbokstav);            //write letter
                        rättcharlist.Add(gissningsbokstav);
                        gamlavärdet++;
                    }
                    else
                    {
                        Console.Write("*");
                    }
                    if (rättcharlist.Count == point)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("\nDu vann!");//You won 
                        Console.WriteLine($" --~~== {ordet} ==~~--");
                        Thread.Sleep(5000);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Game();
                    }
                }                        
                inskrivnaförsök++;
                Console.WriteLine("\n");       //new line     
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("Du har gissat fel på: ");
                foreach (char giss in gissningar)
                {
                    if (!rättcharlist.Contains(giss))
                    {
                        Console.Write("{0} ", giss);
                    }
                    else { }
                }
                if (gamlavärdet != inskrivnaförsök)
                {
                    fel++;
                }
                Console.ForegroundColor = ConsoleColor.Yellow;
                if (fel > 0)
                {
                    Man(fel);
                }
                if (fel == 6)
                {
                    Console.ReadKey();
                    Environment.Exit(1);
                }
                Console.WriteLine("\n_____________________");       //new line     
            } while (won == false);

        }
        public static string Word()
        {
            String[] ordgenerator = new string[]
            { "onomatopeia", "flodhäst","automatisera","kärleksfull","mjukvaruutvecklare","psykopatisk","simbassäng", "myntsamlare","receptnedskrivare","motorvägsanläggare", "hängagubbespelsutvecklare",
                "akrobatisk", "kampsportsutövare", "långhårig","näringsidkare","filosofilektör", "innehållslista"};//17 ord
            Random display = new Random();
            int randoooo = display.Next(17); //random siffra skapas i randoooo
            string GissningsOrd = ordgenerator[randoooo];
            return GissningsOrd;
            ////SKAPAR GISSNINGSORD
        }
        public static void Man(int fel)
        {
            int höjd = 20;
            int bredd = 20;
            string[,] gubbe = new string[höjd, bredd];
            switch (fel)
            {
                case 1:
                    //Botten  1
                    gubbe[17, 17] = "^";
                    gubbe[18, 16] = "/";
                    gubbe[18, 18] = @"\";
                    gubbe[19, 15] = "/";
                    gubbe[19, 19] = @"\";
                    gubbe[18, 17] = "|";
                    gubbe[19, 17] = "|";
                    break;
                case 2:
                    //Botten  1
                    gubbe[17, 17] = "^";
                    gubbe[18, 16] = "/";
                    gubbe[18, 18] = @"\";
                    gubbe[19, 15] = "/";
                    gubbe[19, 19] = @"\";
                    gubbe[18, 17] = "|";
                    gubbe[19, 17] = "|";
                    //stolpen  2
                    gubbe[11, 17] = "|";
                    gubbe[12, 17] = "|";
                    gubbe[13, 17] = "|";
                    gubbe[14, 17] = "|";
                    gubbe[15, 17] = "|";
                    gubbe[16, 17] = "|";
                    break;
                case 3:
                    //Botten  1
                    gubbe[17, 17] = "^";
                    gubbe[18, 16] = "/";
                    gubbe[18, 18] = @"\";
                    gubbe[19, 15] = "/";
                    gubbe[19, 19] = @"\";
                    gubbe[18, 17] = "|";
                    gubbe[19, 17] = "|";
                    //stolpen  2
                    gubbe[11, 17] = "|";
                    gubbe[12, 17] = "|";
                    gubbe[13, 17] = "|";
                    gubbe[14, 17] = "|";
                    gubbe[15, 17] = "|";
                    gubbe[16, 17] = "|";
                    // plankan   3
                    gubbe[5, 8] = "¤";
                    gubbe[5, 9] = "¤";
                    gubbe[5, 10] = "¤";
                    gubbe[5, 11] = "¤";
                    gubbe[5, 12] = "¤";
                    gubbe[5, 13] = "¤";
                    gubbe[5, 14] = "¤";
                    gubbe[5, 15] = "¤";
                    gubbe[5, 16] = "¤";
                    gubbe[5, 17] = "|";
                    gubbe[6, 17] = "|";
                    gubbe[7, 17] = "|";
                    gubbe[8, 17] = "|";
                    gubbe[9, 17] = "|";
                    gubbe[10, 17] = "|";
                    break;
                case 4:
                    //Botten  1
                    gubbe[17, 17] = "^";
                    gubbe[18, 16] = "/";
                    gubbe[18, 18] = @"\";
                    gubbe[19, 15] = "/";
                    gubbe[19, 19] = @"\";
                    gubbe[18, 17] = "|";
                    gubbe[19, 17] = "|";
                    //stolpen  2
                    gubbe[11, 17] = "|";
                    gubbe[12, 17] = "|";
                    gubbe[13, 17] = "|";
                    gubbe[14, 17] = "|";
                    gubbe[15, 17] = "|";
                    gubbe[16, 17] = "|";
                    // plankan   3
                    gubbe[5, 8] = "¤";
                    gubbe[5, 9] = "¤";
                    gubbe[5, 10] = "¤";
                    gubbe[5, 11] = "¤";
                    gubbe[5, 12] = "¤";
                    gubbe[5, 13] = "¤";
                    gubbe[5, 14] = "¤";
                    gubbe[5, 15] = "¤";
                    gubbe[5, 16] = "¤";
                    //repet   4
                    gubbe[5, 17] = "|";
                    gubbe[6, 17] = "|";
                    gubbe[7, 17] = "|";
                    gubbe[8, 17] = "|";
                    gubbe[9, 17] = "|";
                    gubbe[10, 17] = "|";
                    gubbe[5, 7] = "|";
                    gubbe[6, 7] = "|";
                    gubbe[7, 7] = "|";
                    break;
                case 5:
                    //Botten  1
                    gubbe[17, 17] = "^";
                    gubbe[18, 16] = "/";
                    gubbe[18, 18] = @"\";
                    gubbe[19, 15] = "/";
                    gubbe[19, 19] = @"\";
                    gubbe[18, 17] = "|";
                    gubbe[19, 17] = "|";
                    //stolpen  2
                    gubbe[11, 17] = "|";
                    gubbe[12, 17] = "|";
                    gubbe[13, 17] = "|";
                    gubbe[14, 17] = "|";
                    gubbe[15, 17] = "|";
                    gubbe[16, 17] = "|";
                    // plankan   3
                    gubbe[5, 8] = "¤";
                    gubbe[5, 9] = "¤";
                    gubbe[5, 10] = "¤";
                    gubbe[5, 11] = "¤";
                    gubbe[5, 12] = "¤";
                    gubbe[5, 13] = "¤";
                    gubbe[5, 14] = "¤";
                    gubbe[5, 15] = "¤";
                    gubbe[5, 16] = "¤";
                    //repet   4
                    gubbe[5, 17] = "|";
                    gubbe[6, 17] = "|";
                    gubbe[7, 17] = "|";
                    gubbe[8, 17] = "|";
                    gubbe[9, 17] = "|";
                    gubbe[10, 17] = "|";
                    gubbe[5, 7] = "|";
                    gubbe[6, 7] = "|";
                    gubbe[7, 7] = "|";

                    gubbe[8, 7] = "Q";
                    gubbe[9, 6] = "/";
                    gubbe[9, 8] = @"\";
                    gubbe[9, 7] = "|";
                    gubbe[10, 7] = "|";
                    break;
                case 6:
                    //Botten  1
                    gubbe[17, 17] = "^";
                    gubbe[18, 16] = "/";
                    gubbe[18, 18] = @"\";
                    gubbe[19, 15] = "/";
                    gubbe[19, 19] = @"\";
                    gubbe[18, 17] = "|";
                    gubbe[19, 17] = "|";
                    //stolpen  2
                    gubbe[11, 17] = "|";
                    gubbe[12, 17] = "|";
                    gubbe[13, 17] = "|";
                    gubbe[14, 17] = "|";
                    gubbe[15, 17] = "|";
                    gubbe[16, 17] = "|";
                    // plankan   3
                    gubbe[5, 8] = "¤";
                    gubbe[5, 9] = "¤";
                    gubbe[5, 10] = "¤";
                    gubbe[5, 11] = "¤";
                    gubbe[5, 12] = "¤";
                    gubbe[5, 13] = "¤";
                    gubbe[5, 14] = "¤";
                    gubbe[5, 15] = "¤";
                    gubbe[5, 16] = "¤";
                    //repet   4
                    gubbe[5, 17] = "|";
                    gubbe[6, 17] = "|";
                    gubbe[7, 17] = "|";
                    gubbe[8, 17] = "|";
                    gubbe[9, 17] = "|";
                    gubbe[10, 17] = "|";
                    gubbe[5, 7] = "|";
                    gubbe[6, 7] = "|";
                    gubbe[7, 7] = "|";

                    gubbe[8, 7] = "Q";
                    gubbe[9, 6] = "/";
                    gubbe[9, 8] = @"\";
                    gubbe[9, 7] = "|";
                    gubbe[10, 7] = "|";
                    gubbe[11, 7] = "^";
                    gubbe[12, 6] = "/";
                    gubbe[12, 8] = @"\";
                    gubbe[13, 3] = "G";
                    gubbe[13, 4] = "A";
                    gubbe[13, 5] = "M";
                    gubbe[13, 6] = "E";
                    gubbe[13, 7] = " ";
                    gubbe[13, 8] = "O";
                    gubbe[13, 9] = "V";
                    gubbe[13, 10] = "E";
                    gubbe[13, 11] = "R";
                    break;
            }
            for (int i = 0; i < höjd; i++)
            {
                for (int h = 0; h < bredd; h++)
                {
                    if (gubbe[i, h] == null)
                    {
                        Console.Write(" ");
                    }
                    else
                    {
                        Console.Write(gubbe[i, h]);
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
