using System;
using System.Collections.Generic;
using System.Text;

namespace DatingApp
{
    class ProfileRepository
    {
        public static void CreateNewProfile()
        {

            Console.SetCursorPosition(34, 14);
            Profile.Firstname = Console.ReadLine();
            Console.SetCursorPosition(34, 15);
            Profile.Lastname = Console.ReadLine();
            Console.SetCursorPosition(34, 16);
            Profile.Gender = Console.ReadLine();
            Console.SetCursorPosition(34, 17);
            Profile.InterrestedIn = Console.ReadLine();
            Console.SetCursorPosition(34, 18);
            Profile.Height = Convert.ToInt16(Console.ReadLine());
            Console.SetCursorPosition(34, 19);
            Profile.Eyecolor = Console.ReadLine();
            Console.SetCursorPosition(34, 20);
            Profile.Haircolor = Console.ReadLine();
            Console.SetCursorPosition(34, 21);
            Profile.DateOfBirth = Convert.ToDateTime(Console.ReadLine());
            Console.SetCursorPosition(34, 22);
            Profile.About = Console.ReadLine();

            Profile.IsActive = true;
        }

        public static void SaveProfile()
        {
            //gem bruger med SP her
            Console.Write($"{Profile.Firstname} {Profile.Lastname} has been saved..");
        }

        public static void GetProfile()
        {
            //hent profil som bruger skal tage stilling til

            Console.SetCursorPosition(26, 14);
            Console.Write($"{Profile.Firstname}");
            Console.SetCursorPosition(26, 15);
            Console.Write($"{Profile.Lastname}");
            Console.SetCursorPosition(26, 16);
            Console.Write($"{Profile.Gender}");
            Console.SetCursorPosition(26, 17);
            Console.Write($"{Profile.Age}");
            Console.SetCursorPosition(26, 18);
            Console.Write($"{Profile.Height}");
            Console.SetCursorPosition(26, 19);
            Console.Write($"{Profile.Eyecolor}");
            Console.SetCursorPosition(26, 20);
            Console.Write($"{Profile.Haircolor}");
            Console.SetCursorPosition(26, 21);
            Console.Write($"{Profile.InterrestedIn}");
            Console.SetCursorPosition(26, 22);
            Console.Write($"{Profile.About}");

            Console.SetCursorPosition(24, 25);
        }
    }
}
