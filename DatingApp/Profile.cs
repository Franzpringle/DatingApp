using System;

namespace DatingApp
{
    public class Profile
    {
        public string Username { get; set; }
        public string Gender { get; set; }
        public string InterrestedIn { get; set; }
        public int Height { get; set; }
        public string Haircolor { get; set; }
        public string Eyecolor { get; set; }
        public int Age { get; set; }
        public string About { get; set; }
        public bool IsActive { get; set; }
        private object User { get; set; }
        public DateTime DateOfBirth { get; set; }
        

        public Profile(string username, string gender, string interrestedIn, int height, string haircolor, string eyecolor, int age, string about)
        {
            Username = username;
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

        public void SetInactive(Profile profile)
        {
            profile.IsActive = false;
            SaveProfile(profile);
        }

        public void SetActive(Profile profile)
        {
            profile.IsActive = true;
            SaveProfile(profile);
        }
    }
}
