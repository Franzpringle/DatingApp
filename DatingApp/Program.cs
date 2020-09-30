using Figgle;
using System;
using System.ComponentModel;

namespace DatingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo menuChoice;


            do
            {
                GUI.BuildFrontpage();
                menuChoice = Console.ReadKey();

            } while (menuChoice.Key != ConsoleKey.NumPad1 && menuChoice.Key != ConsoleKey.D1 && menuChoice.Key != ConsoleKey.NumPad2 && menuChoice.Key != ConsoleKey.D2);

            if (menuChoice.Key == ConsoleKey.NumPad1 || menuChoice.Key == ConsoleKey.D1)
            {
                GUI.BuildLoginPage();
                UserRepository.GetUserByLogin();

            }

            if (menuChoice.Key == ConsoleKey.NumPad2 || menuChoice.Key == ConsoleKey.D2)
            {
                GUI.BuildCreateNewUser();
                UserRepository.CreateNewUser();
                UserRepository.SaveUser();

            }

            if (UserRepository.userIsNew == true)
            {
                GUI.BuildCreateProfile();
                ProfileRepository.CreateNewProfile();
                ProfileRepository.SaveProfile();

            }

            GUI.BuildUserMenu();
            menuChoice = Console.ReadKey();

            if (menuChoice.Key == ConsoleKey.NumPad1 || menuChoice.Key == ConsoleKey.D1)
            {
                GUI.BuildDatingProfile();
                ProfileRepository.GetProfile();

            }

            menuChoice = Console.ReadKey();

            if (menuChoice.Key == ConsoleKey.NumPad1 || menuChoice.Key == ConsoleKey.D1)
            {
                if (MatchRepository.CheckIfMatch() == true)
                {
                    GUI.BuildMatchMenu();
                    MessageRepository.CreateNewMessage();
                    MessageRepository.SendMessage();
                }
            }
        }
    }
}
