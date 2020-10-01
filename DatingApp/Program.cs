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
                GUI.DisplayFrontpage();
                menuChoice = Console.ReadKey();

            } while (menuChoice.Key != ConsoleKey.NumPad1 && menuChoice.Key != ConsoleKey.D1 && menuChoice.Key != ConsoleKey.NumPad2 && menuChoice.Key != ConsoleKey.D2);

            if (menuChoice.Key == ConsoleKey.NumPad1 || menuChoice.Key == ConsoleKey.D1)
            {
                GUI.DisplayLoginPage();
                UserRepository.GetUserByLogin();

            }

            if (menuChoice.Key == ConsoleKey.NumPad2 || menuChoice.Key == ConsoleKey.D2)
            {
                GUI.DisplayCreateNewUser();
                UserRepository.CreateNewUser();
                UserRepository.SaveUser();

            }

            if (UserRepository.userIsNew == true)
            {
                GUI.DisplayCreateNewProfile();
                ProfileRepository.CreateNewProfile();
                ProfileRepository.SaveProfile();

            }

            GUI.DisplayUserMenu();
            menuChoice = Console.ReadKey();

            if (menuChoice.Key == ConsoleKey.NumPad1 || menuChoice.Key == ConsoleKey.D1)
            {
                GUI.DisplayDatingProfile();
                ProfileRepository.GetProfile();

            }

            if (menuChoice.Key == ConsoleKey.NumPad2 || menuChoice.Key == ConsoleKey.D2)
            {
                GUI.DisplayEditProfile();
                menuChoice = Console.ReadKey();
                if (menuChoice.Key == ConsoleKey.NumPad1 || menuChoice.Key == ConsoleKey.D1)
                {
                    if (Profile.IsActive == true) ProfileRepository.SetInactive();
                    if (Profile.IsActive == false) ProfileRepository.SetActive();
                }

            }
            menuChoice = Console.ReadKey();

            if (menuChoice.Key == ConsoleKey.NumPad1 || menuChoice.Key == ConsoleKey.D1)
            {
                if (MatchRepository.CheckIfMatch() == true)
                {
                    GUI.DisplayMatchMenu();
                    MessageRepository.CreateNewMessage();
                    MessageRepository.SendMessage();
                }
            }
        }
    }
}
