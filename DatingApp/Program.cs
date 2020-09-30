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
            //User u = new User();

            do
            {
                GUI.BuildFrontpage();
                menuChoice = Console.ReadKey();

            } while (menuChoice.Key != ConsoleKey.NumPad1 && menuChoice.Key != ConsoleKey.D1 && menuChoice.Key != ConsoleKey.NumPad2 && menuChoice.Key != ConsoleKey.D2);

            if (menuChoice.Key == ConsoleKey.NumPad2 || menuChoice.Key == ConsoleKey.D2)
            {
                GUI.BuildCreateNewUser();
                UserRepository.CreateNewUser();
                UserRepository.SaveUser();

            }
            if (menuChoice.Key == ConsoleKey.NumPad1 || menuChoice.Key == ConsoleKey.D1)
            {
                GUI.BuildLoginPage();
                UserRepository.GetUser();

            }

            if (UserRepository.userIsNew == true)
            {
                GUI.BuildCreateProfile();
                UserRepository.CreateNewUser();
                UserRepository.SaveUser();

            }
            //if (userIsNew == false)
            //{
            //    GUI.BuildUserMenu();
            //    Console.SetCursorPosition(60, 10);

            //    menuChoice = Console.ReadKey();

            //    if(menuChoice.Key == ConsoleKey.NumPad1 || menuChoice.Key == ConsoleKey.D1)
            //    {
            //        // hent max 20 brugere
            //        // cycle gennem dem
            //        // user vælger 1 eller 2 for hhv. ja-tak eller nej-tak

            //    }


            //}

        }
    }
}
