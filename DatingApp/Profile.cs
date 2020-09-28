using System;

namespace DatingApp
{
    public class Profile
    {
        public string Gender { get; set; }
        public string InterrestedIn { get; set; }
        public int Height { get; set; }
        public string Haircolor { get; set; }
        public string Eyecolor { get; set; }
        public int Age { get; set; }
        public string About { get; set; }
        public bool IsActive { get; set; }
        private object User { get; set; }
        

        public Profile(object user, string gender, string interrestedIn, int height, string haircolor, string eyecolor, int age, string about)
        {
            User = user;
            Gender = gender;
            InterrestedIn = interrestedIn;
            Height = height;
            Haircolor = haircolor;
            Eyecolor = eyecolor;
            Age = age;
            About = about;
            IsActive = true;
        }
        public Profile()
        {

        }

        public void SaveProfile(object profile)
        {
            Console.WriteLine("I saved the profile in the db..");
        }

        public void SetInactive(string username)
        {
            if (IsActive == false)
            {
                Console.WriteLine("I have made the profile inactive in db..");
            }
            else
            {
                Console.WriteLine("profile is already inactive");
            }
        }

        public void SetActive(string username)
        {
            if (IsActive == true)
            {
                Console.WriteLine("I have made the profile active in db..");
            }
            else
            {
                Console.WriteLine("profile is already active");
            }
        }
    }
}
