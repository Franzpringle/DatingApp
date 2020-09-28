using System;
using System.Collections.Generic;
using System.Text;
using Figgle;

namespace DatingApp
{
    public class UserInterface
    {
        public static void BuildFrontpage()
        {
            Console.Clear();
            Console.WriteLine(FiggleFonts.Standard.Render("\t DatingApp!"));

            Console.SetCursorPosition(2, 10);
            Console.Write("ny bruger? j/n: ");
        }

        public static void BuildCreateNewUser()
        {
            Console.Clear();
            Console.WriteLine(FiggleFonts.Standard.Render("\t DatingApp!"));

            Console.SetCursorPosition(2, 10);
            Console.Write("Desired username: ");
            Console.SetCursorPosition(2, 11);
            Console.Write("Firstname       : ");
            Console.SetCursorPosition(2, 12);
            Console.Write("Lastname        : ");
            Console.SetCursorPosition(2, 13);
            Console.Write("Email           : ");
            Console.SetCursorPosition(2, 14);
            Console.Write("Desired Password: ");
        }

        public static void BuildLoginPage()
        {
            Console.Clear();
            Console.WriteLine(FiggleFonts.Standard.Render("\t DatingApp!"));

            Console.SetCursorPosition(2, 10);
            Console.Write("Username     :");
            Console.SetCursorPosition(2, 11);
            Console.Write("Password     :");

        }

        public static void BuildCreateProfile()
        {
            Console.Clear();

            Console.SetCursorPosition(2, 10);
            Console.WriteLine("Please fill in information about yourself");
            Console.SetCursorPosition(2, 11);
            Console.WriteLine("This information will be displayed to other users");
            Console.SetCursorPosition(2, 12);
            Console.WriteLine("Fields marked with a * are required");

            Console.SetCursorPosition(2, 14);
            Console.WriteLine("* Gender (m/f)             :");
            Console.SetCursorPosition(2, 15);
            Console.WriteLine("* Interrested in (m/f/b)   :");

        }
    }
}
