using System;
using System.Security;

namespace HangMan
{
    class Program
    {
        static void Main(string[] args)
        {

            string orr= Word();  //ORDET SOM HÄMTATS MEN INTE VISATS ÄN! SOM SKA ANVÄDAS
            //Console.WriteLine($"--~~== {orr} ==~~--");



            ///visa ordet i *** dolt, om inskrivet tecken == samma som i gissningsord VISA tecken 
            //rita gubbe metod,   fel variabel , om fel=1 rita gubbe +1
            SecureString passworrrdd =maskInputString();
            string Password = new System.Net.NetworkCredential(string.Empty, passworrrdd).Password;
            Console.WriteLine();
            Console.WriteLine(Password);
            Console.ReadKey();
        }
        public static string Word()
        {
            //List <string> ordgenerator  = new List<string>()
            String[] ordgenerator = new string[]
            { "onomatopeia", "flodhäst","automatisera","kärleksfull","mjukvaruutvecklare",
                "akrobatisk", "kampsportsutövare", "långhårig","näringsidkare","filosofilektör", "innehållslista"};//11 ord
            //for loop   if index = randooo Console Write ordgenrator[i]
            Random display = new Random();
            int randoooo = display.Next(11); //random siffra skapas i randoooo
            string GissningsOrd = ordgenerator[randoooo];
            //Console.WriteLine($"--~~== {GissningsOrd} ==~~--");
            return GissningsOrd;
            ////SKAPAR GISSNINGSORD
        }
        private static SecureString maskInputString()
        {
            Console.WriteLine("Enter your password");
            SecureString pass = new SecureString();
            ConsoleKeyInfo keyInfo;

            do
            {
                keyInfo = Console.ReadKey(true);
                if (!char.IsControl(keyInfo.KeyChar))
                {
                    pass.AppendChar(keyInfo.KeyChar);
                    Console.Write("*");
                }
                else if (keyInfo.Key ==ConsoleKey.Backspace && pass.Length > 0)
                {
                    pass.RemoveAt(pass.Length - 1);
                    Console.Write(" ⧵b ⧵b");
                }
            } while (keyInfo.Key != ConsoleKey.Enter);
            {
                return pass;

            }
        }
    }
}
