using System;

namespace DatingApp
{
    public class Profile
    {   
        public static int ProfileId { get; private set; }
        public static string Firstname { get; set; }
        public static string Lastname { get; set; }
        public static string Gender { get; set; }
        public static string InterrestedIn { get; set; }
        public static int Height { get; set; }
        public static string Haircolor { get; set; }
        public static string Eyecolor { get; set; }
        public static int Age { get; set; }
        public static string About { get; set; }
        public static bool IsActive { get; set; }
        public static DateTime DateOfBirth { get; set; }

    }
}
