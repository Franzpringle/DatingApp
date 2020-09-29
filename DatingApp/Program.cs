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
            bool userIsNew = false;
            ConsoleKeyInfo menuChoice;
            User u = new User();
            Profile p = new Profile();

            do
            {
                UserInterface.BuildFrontpage();
                Console.SetCursorPosition(62, 10);
                menuChoice = Console.ReadKey();

            } while (menuChoice.Key != ConsoleKey.NumPad1 && menuChoice.Key != ConsoleKey.D1 && menuChoice.Key != ConsoleKey.NumPad2 && menuChoice.Key != ConsoleKey.D2);

            if (menuChoice.Key == ConsoleKey.NumPad2 || menuChoice.Key == ConsoleKey.D2)
            {
                UserInterface.BuildCreateNewUser();

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

                User.SaveUser(u);
                userIsNew = true;


            }
            if (menuChoice.Key == ConsoleKey.NumPad1 || menuChoice.Key == ConsoleKey.D1)
            {
                UserInterface.BuildLoginPage();

                Console.SetCursorPosition(17, 10);
                u.Username = Console.ReadLine();
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

                u.Password = pass;

                User.LoginUser(u);
                userIsNew = false;
                
                Console.SetCursorPosition(2, 13);
                Console.WriteLine($"Testing output: {u.Username} {u.Password}");

                Console.ReadKey();
            }

            if (userIsNew == true)
            {
                UserInterface.BuildCreateProfile();
                p.Username = u.Username;

                Console.SetCursorPosition(34, 14);
                p.Gender = Console.ReadLine();
                Console.SetCursorPosition(34, 15);
                p.InterrestedIn = Console.ReadLine();
                Console.SetCursorPosition(34, 16);
                p.Height = Convert.ToInt16(Console.ReadLine());
                Console.SetCursorPosition(34, 17);
                p.Eyecolor = Console.ReadLine();
                Console.SetCursorPosition(34, 18);
                p.Haircolor = Console.ReadLine();
                Console.SetCursorPosition(34, 19);
                p.DateOfBirth = Convert.ToDateTime(Console.ReadLine());
                Console.SetCursorPosition(34, 20);
                p.About = Console.ReadLine();

                p.IsActive = true;
                p.SaveProfile(p);

            }

        }
    }
}
