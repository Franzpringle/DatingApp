using Figgle;
using System;
using System.ComponentModel;

namespace DatingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string pass = string.Empty;
            ConsoleKeyInfo menuChoice;

            do
            {
                UserInterface.BuildFrontpage();
                Console.SetCursorPosition(62, 10);
                menuChoice = Console.ReadKey();

            } while (menuChoice.Key != ConsoleKey.NumPad1 && menuChoice.Key != ConsoleKey.D1 && menuChoice.Key != ConsoleKey.NumPad2 && menuChoice.Key != ConsoleKey.D2);

            if (menuChoice.Key == ConsoleKey.NumPad2 || menuChoice.Key == ConsoleKey.D2)
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

            }
            if (menuChoice.Key == ConsoleKey.NumPad1 || menuChoice.Key == ConsoleKey.D1)
            {
                UserInterface.BuildLoginPage();
                User loginUser = new User();

                Console.SetCursorPosition(17, 10);
                loginUser.Username = Console.ReadLine();
                Console.SetCursorPosition(17, 11);
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

                loginUser.Password = pass;

                Console.SetCursorPosition(2, 13);
                Console.WriteLine($"Testing output: {loginUser.Username} {loginUser.Password}");

                Console.ReadKey();
            }


        }
    }
}
