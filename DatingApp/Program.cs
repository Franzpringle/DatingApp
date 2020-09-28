using Figgle;
using System;
using System.ComponentModel;

namespace DatingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string username, pass = string.Empty;

            Console.WriteLine(FiggleFonts.Standard.Render("Dating App"));
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Please enter your username and password.");
            Console.WriteLine("New user? type NEW followed by Enter");
            Console.Write("Username: ");
            username = Console.ReadLine();

            if(username.ToLower() == "new")
            {
                User u = new User();
                u = User.NewUser();
                User.SaveUser(u);

                Console.WriteLine($"{u.Firstname} {u.Lastname} {u.Username} {u.Email}");
                Console.ReadKey();
                
            }

            Console.Write("password: ");
            ConsoleKey key;
            do
            {
                var keyInfo = Console.ReadKey(intercept: true);
                key = keyInfo.Key;

                if (key == ConsoleKey.Backspace && pass.Length > 0)
                {
                    Console.Write("\b \b");
                    pass = pass[0..^1];
                }
                else if (!char.IsControl(keyInfo.KeyChar))
                {
                    Console.Write("*");
                    pass += keyInfo.KeyChar;
                }
            } while (key != ConsoleKey.Enter);


        }
    }
}
