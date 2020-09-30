using System;
using System.Collections.Generic;
using System.Text;

namespace DatingApp
{
    class UserRepository
    {
        public static bool userIsNew { get; set; }
        public static string pass { get; set; }

        public static void CreateNewUser()
        {
            Console.SetCursorPosition(22, 10);
            User.Username = Console.ReadLine();
            Console.SetCursorPosition(22, 11);
            User.Firstname = Console.ReadLine();
            Console.SetCursorPosition(22, 12);
            User.Lastname = Console.ReadLine();
            Console.SetCursorPosition(22, 13);
            User.Email = Console.ReadLine();
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

            User.Password = pass;

            Console.SetCursorPosition(2, 17);
            Console.WriteLine($"Test af output: {User.Firstname} {User.Lastname} {User.Username} {User.Email} {User.Password}");

            userIsNew = true;
        }

        public static void SaveUser()
        {
            Console.WriteLine($"user: {User.Username} has been saved..");
            Console.ReadKey();
        }

        public static void GetUser()
        {

            Console.SetCursorPosition(17, 10);
            User.Username = Console.ReadLine();
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

            User.Password = pass;
            userIsNew = false;

            Console.SetCursorPosition(2, 13);
            Console.WriteLine($"Testing output: {User.Username} {User.Password}");

            Console.ReadKey();
        }
    }
}
