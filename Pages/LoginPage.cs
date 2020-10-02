using System;
using System.Collections.Generic;
using System.Text;
using DatingApp;
using Figgle;

namespace DatingApp
{
    class LoginPage
    {
        public static void Run()
        {
            GUI.DisplayLoginPage();

            User currentUser = new User();
            UserRepository.GetUserByLogin(currentUser);

            //Console.SetCursorPosition(2, 13);
            //Console.WriteLine($"Testing output: {currentUser.Username} {currentUser.Password}");

            Console.ReadKey();
        }
    }
}
