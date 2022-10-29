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
            string ordet = Word();
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
            Console.WriteLine("Hela ordet du ska gissa på är:");
            foreach (int e in ordet)
            {
                Console.Write("*");
            }
            Console.WriteLine();
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
                    if (rättcharlist.Count == ordet.Length)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("\nDu vann!");
                        Console.WriteLine($" --~~== {ordet} ==~~--");
                        Thread.Sleep(6500);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Game();
                    }
                    if (rättcharlist.Contains(exempelord[i]))   //tar bara in poäng"" för a 1 gång om a finns 2 gngr
                    {
                        Console.Write(exempelord[i]);//write out letter
                    }
                    else if (exempelord[i] == gissningsbokstav)
                    {
                        foreach (char kopia in exempelord)
                        {
                            if (gissningsbokstav == kopia)
                            {
                                rättcharlist.Add(gissningsbokstav);
                            }
                        }
                        Console.Write(gissningsbokstav);
                        gamlavärdet++;
                    }
                    else
                    {
                        Console.Write("*");
                    }
                }
                inskrivnaförsök++;
                if (gamlavärdet != inskrivnaförsök)
                {
                    fel++;
                }
                if (fel > 0)
                {
                    Man(fel);
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("\n\nDu har gissat fel på följande: ");
                    foreach (char giss in gissningar)
                    {
                        if (!rättcharlist.Contains(giss))
                        {
                            Console.Write("-{0} ", giss.ToString().ToUpper());
                        }
                    }
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                if (fel == 6)
                {
                    Thread.Sleep(1500);
                    fel = 0;
                    Game();
                }
                Console.WriteLine("\n_____________________");
            } while (won == false);
        }
        public static string Word()
        {
            String[] ordgenerator = new string[]
            { "onomatopeia", "flodhäst","automatisera","kärleksfull","mjukvaruutvecklare","psykopatisk","simbassäng", "myntsamlare","receptnedskrivare","motorvägsanläggare", "hängagubbespelsutvecklare",
                "akrobatisk", "kampsportsutövare", "långhårig","näringsidkare","filosofilektör", "innehållslista","observation","urinoar","saltgruva","hägring","verifiera",
                "certifiera","ökenråtta","obducera","djurförsäkring","årsavgift",
                "balsamering","affirmation","laminering","meditation","krus",
                "höjdhopp","novell","bagatell","karusell","bänk",
                "stänk","länk","kränkning","skärmavbild","olympier",
                "ansträngning","kex","häxa","zebra","zoologisk",
                "xenofobisk","astrobiologi","lambda","veganism","tamdjur",};//52
            Random display = new Random();
            int randoooo = display.Next(52); //random siffra skapas i randoooo
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