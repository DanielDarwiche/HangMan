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
            Game();//Plays game
        }
        public static void Game()
        {
            string theWord = Word();
            List<char> exempelord = new List<char>();  //creating list of char for exampleword
            foreach (char c in theWord)//Loop to put all chars of theWord in exampleword
            {
                exempelord.Add(c);
            }
            char gissningsbokstav = ' '; //Creating the variable used for inputletter
            List<char> rättcharlist = new List<char>();//list for right guesses
            List<char> gissningar = new List<char>();//list for all guesses
            bool won = false;
            Console.Clear();
            Console.WriteLine("Hela ordet du ska gissa på är:");//Full word to guess
            foreach (int e in theWord)//Writes the word with asterisks=hidden word
            {
                Console.Write("*");
            }
            Console.WriteLine();
            int fel = 0;//error starts as 0 for each game
            do
            {
                int gamlavärdet = rättcharlist.Count;//creates oldvalue, the size of rightguesseslist
                int inskrivnaförsök = gamlavärdet;//written tries the same of oldvalue
                Console.WriteLine("Skriv in en bokstav:"); 
                gissningsbokstav = Console.ReadKey().KeyChar; //enter a char as inputletter
                Console.WriteLine();
                gissningar.Add(gissningsbokstav);           //add inputletter to allguesses
                for (int i = 0; i < exempelord.Count; i++)//loops through the wordlist
                {
                    if (rättcharlist.Count == theWord.Length)//if theWord is the same size as rightguesseslist
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;//You win and restarts the game
                        Console.WriteLine("\nDu vann!");
                        Console.WriteLine($" --~~== {theWord} ==~~--");
                        Thread.Sleep(6500);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Game();
                    }
                    if (rättcharlist.Contains(exempelord[i]))   //rightguesseslist already contains the letter in theWord
                    {
                        Console.Write(exempelord[i]);//write out letter
                    }
                    else if (exempelord[i] == gissningsbokstav)//else, we see if the letterinput equals theWord[i]
                    {
                        foreach (char kopia in exempelord)//foreach char in thewordarray
                        {
                            if (gissningsbokstav == kopia)//if its the same as guessinput, add it to rightguesseslist
                            {
                                rättcharlist.Add(gissningsbokstav);
                            }
                        }
                        Console.Write(gissningsbokstav);//write it out and add to the oldvalue
                        gamlavärdet++;
                    }
                    else
                    {
                        Console.Write("*");//otherwise, write out *, so that the unknown letter is hidden
                    }
                }
                inskrivnaförsök++; //After the comparing loop, add value to writtentries
                if (gamlavärdet != inskrivnaförsök)//if the oldvalue isnt same as writtentries
                {
                    fel++;//we ad an error
                }
                if (fel > 0)//if we have made any errors, we want to se the illustration of the hung man
                {
                    Man(fel);
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("\n\nDu har gissat fel på följande: ");//and display the amount of guesses
                    foreach (char giss in gissningar)
                    {//we go trough guesses, and if the guess isnt put in the rightguesseslist, we write them out as wrongguess
                        if (!rättcharlist.Contains(giss))
                        {
                            Console.Write("-{0} ", giss.ToString().ToUpper());
                        }
                    }
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                if (fel == 6)
                {//if errors are equal to 6 we sleep the thread and restards the errorvalue and restards the game
                    Thread.Sleep(1500);
                    fel = 0;
                    Game();
                }
                Console.WriteLine("\n_____________________");
            } while (won == false);  //Loops the game
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
                "xenofobisk","astrobiologi","lambda","veganism","tamdjur",};//We create an array of the 52 words
            Random display = new Random();
            int rando = display.Next(52); //We create a random wordgenerator here, called rando
            string GissningsOrd = ordgenerator[rando];
            return GissningsOrd;
        }
        public static void Man(int fel)
        {
            int höjd = 20;//creates the height and width of the complete illustration
            int bredd = 20;
            string[,] gubbe = new string[höjd, bredd];
            switch (fel)
            {
                case 1://All cases adds the a value aswell as the previous values, 
                    //so that we can visibly hang the man
                    //Bottom  1
                    gubbe[17, 17] = "^";
                    gubbe[18, 16] = "/";
                    gubbe[18, 18] = @"\";
                    gubbe[19, 15] = "/";
                    gubbe[19, 19] = @"\";
                    gubbe[18, 17] = "|";
                    gubbe[19, 17] = "|";
                    break;
                case 2:
                    //Bottom  1
                    gubbe[17, 17] = "^";
                    gubbe[18, 16] = "/";
                    gubbe[18, 18] = @"\";
                    gubbe[19, 15] = "/";
                    gubbe[19, 19] = @"\";
                    gubbe[18, 17] = "|";
                    gubbe[19, 17] = "|";
                    //Pole  2
                    gubbe[11, 17] = "|";
                    gubbe[12, 17] = "|";
                    gubbe[13, 17] = "|";
                    gubbe[14, 17] = "|";
                    gubbe[15, 17] = "|";
                    gubbe[16, 17] = "|";
                    break;
                case 3:
                    //Bottom  1
                    gubbe[17, 17] = "^";
                    gubbe[18, 16] = "/";
                    gubbe[18, 18] = @"\";
                    gubbe[19, 15] = "/";
                    gubbe[19, 19] = @"\";
                    gubbe[18, 17] = "|";
                    gubbe[19, 17] = "|";
                    //Pole  2
                    gubbe[11, 17] = "|";
                    gubbe[12, 17] = "|";
                    gubbe[13, 17] = "|";
                    gubbe[14, 17] = "|";
                    gubbe[15, 17] = "|";
                    gubbe[16, 17] = "|";
                    // Plank   3
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
                    //Bottom  1
                    gubbe[17, 17] = "^";
                    gubbe[18, 16] = "/";
                    gubbe[18, 18] = @"\";
                    gubbe[19, 15] = "/";
                    gubbe[19, 19] = @"\";
                    gubbe[18, 17] = "|";
                    gubbe[19, 17] = "|";
                    //Pole  2
                    gubbe[11, 17] = "|";
                    gubbe[12, 17] = "|";
                    gubbe[13, 17] = "|";
                    gubbe[14, 17] = "|";
                    gubbe[15, 17] = "|";
                    gubbe[16, 17] = "|";
                    // Plank   3
                    gubbe[5, 8] = "¤";
                    gubbe[5, 9] = "¤";
                    gubbe[5, 10] = "¤";
                    gubbe[5, 11] = "¤";
                    gubbe[5, 12] = "¤";
                    gubbe[5, 13] = "¤";
                    gubbe[5, 14] = "¤";
                    gubbe[5, 15] = "¤";
                    gubbe[5, 16] = "¤";
                    //Rope   4
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
                    //Bottom  1
                    gubbe[17, 17] = "^";
                    gubbe[18, 16] = "/";
                    gubbe[18, 18] = @"\";
                    gubbe[19, 15] = "/";
                    gubbe[19, 19] = @"\";
                    gubbe[18, 17] = "|";
                    gubbe[19, 17] = "|";
                    //Pole  2
                    gubbe[11, 17] = "|";
                    gubbe[12, 17] = "|";
                    gubbe[13, 17] = "|";
                    gubbe[14, 17] = "|";
                    gubbe[15, 17] = "|";
                    gubbe[16, 17] = "|";
                    // Plank   3
                    gubbe[5, 8] = "¤";
                    gubbe[5, 9] = "¤";
                    gubbe[5, 10] = "¤";
                    gubbe[5, 11] = "¤";
                    gubbe[5, 12] = "¤";
                    gubbe[5, 13] = "¤";
                    gubbe[5, 14] = "¤";
                    gubbe[5, 15] = "¤";
                    gubbe[5, 16] = "¤";
                    //Rope   4
                    gubbe[5, 17] = "|";
                    gubbe[6, 17] = "|";
                    gubbe[7, 17] = "|";
                    gubbe[8, 17] = "|";
                    gubbe[9, 17] = "|";
                    gubbe[10, 17] = "|";
                    gubbe[5, 7] = "|";
                    gubbe[6, 7] = "|";
                    gubbe[7, 7] = "|";
                    // Upper Body of man
                    gubbe[8, 7] = "Q";
                    gubbe[9, 6] = "/";
                    gubbe[9, 8] = @"\";
                    gubbe[9, 7] = "|";
                    gubbe[10, 7] = "|";
                    break;
                case 6:
                    //Bottom  1
                    gubbe[17, 17] = "^";
                    gubbe[18, 16] = "/";
                    gubbe[18, 18] = @"\";
                    gubbe[19, 15] = "/";
                    gubbe[19, 19] = @"\";
                    gubbe[18, 17] = "|";
                    gubbe[19, 17] = "|";
                    //Pole  2
                    gubbe[11, 17] = "|";
                    gubbe[12, 17] = "|";
                    gubbe[13, 17] = "|";
                    gubbe[14, 17] = "|";
                    gubbe[15, 17] = "|";
                    gubbe[16, 17] = "|";
                    // Plank   3
                    gubbe[5, 8] = "¤";
                    gubbe[5, 9] = "¤";
                    gubbe[5, 10] = "¤";
                    gubbe[5, 11] = "¤";
                    gubbe[5, 12] = "¤";
                    gubbe[5, 13] = "¤";
                    gubbe[5, 14] = "¤";
                    gubbe[5, 15] = "¤";
                    gubbe[5, 16] = "¤";
                    //Rope   4
                    gubbe[5, 17] = "|";
                    gubbe[6, 17] = "|";
                    gubbe[7, 17] = "|";
                    gubbe[8, 17] = "|";
                    gubbe[9, 17] = "|";
                    gubbe[10, 17] = "|";
                    gubbe[5, 7] = "|";
                    gubbe[6, 7] = "|";
                    gubbe[7, 7] = "|";
                    //Full body of man
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
            for (int i = 0; i < höjd; i++) //Displays the total values of the illustration
            {
                for (int h = 0; h < bredd; h++)
                {
                    if (gubbe[i, h] == null)//If the values null we write ' '
                    {
                        Console.Write(" ");
                    }
                    else
                    {
                        Console.Write(gubbe[i, h]);//if the values are set, we write them
                    }
                }
                Console.WriteLine();
            }
        }
    }
}