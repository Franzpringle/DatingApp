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
    }
}
