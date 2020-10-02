using Figgle;
using System;
using System.ComponentModel;


namespace DatingApp 
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                GUI.DisplayFrontpage();
                string menuChoice = Console.ReadLine().ToLower();

                if (menuChoice == "1") LoginPage.Run();
                if (menuChoice == "2") CreateNewUserPage.Run();
                if (menuChoice == "3") Environment.Exit(0);
            }
        }
    }
}
