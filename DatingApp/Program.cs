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

            UserInterface.BuildFrontpage();

            username = Console.ReadLine();

            if(username.ToLower() == "j")
            {

                UserInterface.BuildCreateNewUser();
                User u = new User();

                Console.SetCursorPosition(22, 10);
                u.Username = Console.ReadLine();
                Console.SetCursorPosition(22, 11);
                u.Firstname = Console.ReadLine();
                Console.SetCursorPosition(22, 12);
                u.Lastname = Console.ReadLine();
                Console.SetCursorPosition(22, 13);
                u.Email = Console.ReadLine();
                Console.SetCursorPosition(22, 14);
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

                u.Password = pass;

                Console.SetCursorPosition(2, 17);
                Console.WriteLine($"Test af output: {u.Firstname} {u.Lastname} {u.Username} {u.Email} {u.Password}");
                Console.ReadKey();
                
            }


        }
    }
}
