using System;
using System.Collections.Generic;
using System.Text;
using Figgle;

namespace DatingApp
{
    public class GUI
    {
        public static void DisplayFrontpage() //done
        {
            Console.Clear();
            Console.WriteLine(FiggleFonts.Standard.Render("\t DatingApp!"));

            Console.SetCursorPosition(2, 10);
            Console.Write("Choose an option by typing a number from the menu below: ");
            Console.SetCursorPosition(2, 13);
            Console.Write("1. Login");
            Console.SetCursorPosition(2, 14);
            Console.Write("2. Create new user");
            Console.SetCursorPosition(2, 15);
            Console.Write("3. Exit program");
            Console.SetCursorPosition(60, 10);
        }

        public static void DisplayCreateNewUser() //done
        {
            Console.Clear();
            Console.WriteLine(FiggleFonts.Standard.Render("\t DatingApp!"));

            Console.SetCursorPosition(2, 10);
            Console.Write("Desired username: ");
            Console.SetCursorPosition(2, 11);
            Console.Write("Email           : ");
            Console.SetCursorPosition(2, 12);
            Console.Write("Desired Password: ");
        }

        public static void DisplayLoginPage() //done
        {
            Console.Clear();
            Console.WriteLine(FiggleFonts.Standard.Render("\t DatingApp!"));

            Console.SetCursorPosition(2, 10);
            Console.Write("Username     : ");
            Console.SetCursorPosition(2, 11);
            Console.Write("Password     : ");

        }

        public static void DisplayCreateNewProfile() //done
        {
            Console.Clear();
            Console.WriteLine(FiggleFonts.Standard.Render("\t DatingApp!"));

            Console.SetCursorPosition(2, 10);
            Console.WriteLine("Please fill in information about yourself");
            Console.SetCursorPosition(2, 11);
            Console.WriteLine("This information will be displayed to other users");
            Console.SetCursorPosition(2, 12);
            Console.WriteLine("Fields marked with a * are required");

            Console.SetCursorPosition(2, 14);
            Console.WriteLine("* Firstname                  : ");
            Console.SetCursorPosition(2, 15);
            Console.WriteLine("* Lastname                   : ");
            Console.SetCursorPosition(2, 16);
            Console.WriteLine("* Gender (m/f)               : ");
            Console.SetCursorPosition(2, 17);
            Console.WriteLine("* Interrested in (m/f/b)     : ");
            Console.SetCursorPosition(2, 18);
            Console.WriteLine("  Height                     : ");
            Console.SetCursorPosition(2, 19);
            Console.WriteLine("  Eyecolor                   : ");
            Console.SetCursorPosition(2, 20);
            Console.WriteLine("  Haircolor                  : ");
            Console.SetCursorPosition(2, 21);
            Console.WriteLine("* Date of birth (dd-MM-yyyy) : ");
            Console.SetCursorPosition(2, 22);
            Console.WriteLine("  Something about yourself   : ");

        }

        public static void DisplayUserMenu() //done
        {
            Console.Clear();
            Console.WriteLine(FiggleFonts.Standard.Render("\t DatingApp!"));

            Console.SetCursorPosition(2, 10);
            Console.WriteLine("Choose an option by typing a number from the menu below: ");
            Console.SetCursorPosition(2, 13);
            Console.WriteLine("1. Start dating! :");
            Console.SetCursorPosition(2, 14);
            Console.WriteLine("2. Edit profile  :");

            Console.SetCursorPosition(60, 10);

        }

        public static void DisplayDatingProfile(Profile potentialMatch) //done
        {
            Console.Clear();

            Console.SetCursorPosition(2, 14);
            Console.WriteLine($"Firstname             : {potentialMatch.Firstname}");
            Console.SetCursorPosition(2, 15);
            Console.WriteLine($"Lastname              : {potentialMatch.Lastname}");
            Console.SetCursorPosition(2, 16);
            Console.WriteLine($"Gender (m/f)          : {potentialMatch.Gender}");
            Console.SetCursorPosition(2, 17);
            Console.WriteLine($"Age                   : {potentialMatch.Age}");
            Console.SetCursorPosition(2, 18);
            Console.WriteLine($"Height                : {potentialMatch.Height}");
            Console.SetCursorPosition(2, 19);
            Console.WriteLine($"Eyecolor              : {potentialMatch.Eyecolor}");
            Console.SetCursorPosition(2, 20);
            Console.WriteLine($"Haircolor             : {potentialMatch.Haircolor}");
            Console.SetCursorPosition(2, 21);
            Console.WriteLine($"Interrested in        : {potentialMatch.InterestedIn}");
            Console.SetCursorPosition(2, 22);
            Console.WriteLine($"About                 : {potentialMatch.About}");

            Console.SetCursorPosition(2, 25);
            Console.WriteLine("What do you choose? : ");
            Console.SetCursorPosition(2, 27);
            Console.WriteLine("1. Like and continue");
            Console.SetCursorPosition(2, 28);
            Console.WriteLine("2. Continue without liking");
            Console.SetCursorPosition(2, 29);
            Console.WriteLine("3. Exit..");

            Console.SetCursorPosition(25, 25);

        }

        public static void DisplayMatchMenu(Profile currentProfile, Profile matchProfile)
        {
            //vi har et match! bruger kan skrive direkte til modpartens indbakke
        }

        public static void DisplayEditProfile(Profile p) //done
        {
            Console.Clear();
            Console.SetCursorPosition(2, 14);
            Console.Write("Please choose an option from the menu below: ");
            Console.SetCursorPosition(2, 16);
            if (p.IsActive == true)
            {
                Console.Write("1. Change status to inactive");
            }
            else
            {
                Console.Write("1. Change status to active");
            }
            Console.SetCursorPosition(2, 17);
            Console.WriteLine("2. Go back..");

            Console.SetCursorPosition(48, 14);
        }
    }
}
