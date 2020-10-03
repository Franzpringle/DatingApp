using System;

namespace DatingApp
{
    public class Profile
    {   
        public int ProfileId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Gender { get; set; }
        public string InterestedIn { get; set; }
        public int Height { get; set; }
        public string Haircolor { get; set; }
        public string Eyecolor { get; set; }
        public int Age { get; set; }
        public string About { get; set; }
        public bool IsActive { get; set; }
        public DateTime DateOfBirth { get; set; }

    }
}
