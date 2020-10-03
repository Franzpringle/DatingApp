using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DatingApp
{
    class ProfileRepository
    {
        public static Profile CreateNewProfile()
        {
            Profile p = new Profile();

            Console.SetCursorPosition(34, 14);
            p.Firstname = Console.ReadLine();
            Console.SetCursorPosition(34, 15);
            p.Lastname = Console.ReadLine();
            Console.SetCursorPosition(34, 16);
            p.Gender = Console.ReadLine();
            Console.SetCursorPosition(34, 17);
            p.InterestedIn = Console.ReadLine();
            Console.SetCursorPosition(34, 18);
            p.Height = Convert.ToInt16(Console.ReadLine());
            Console.SetCursorPosition(34, 19);
            p.Eyecolor = Console.ReadLine();
            Console.SetCursorPosition(34, 20);
            p.Haircolor = Console.ReadLine();
            Console.SetCursorPosition(34, 21);
            p.DateOfBirth = Convert.ToDateTime(Console.ReadLine());
            Console.SetCursorPosition(34, 22);
            p.About = Console.ReadLine();

            p.IsActive = true;

            return p;
        }

        public static void SaveProfile(Profile p, User u)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString.GetConnectionString()))
            {
                conn.Open();
                string command = "createprofilebio";

                SqlCommand cmd = new SqlCommand(command, conn);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@username", u.Username));
                cmd.Parameters.Add(new SqlParameter("@firstname", p.Firstname));
                cmd.Parameters.Add(new SqlParameter("@lastname", p.Lastname));
                cmd.Parameters.Add(new SqlParameter("@gender", p.Gender));
                cmd.Parameters.Add(new SqlParameter("@interestedIn", p.InterestedIn));
                cmd.Parameters.Add(new SqlParameter("@height", p.Height));
                cmd.Parameters.Add(new SqlParameter("@eyecolor", p.Eyecolor));
                cmd.Parameters.Add(new SqlParameter("@haircolor", p.Haircolor));
                cmd.Parameters.Add(new SqlParameter("@dateOfBirth", p.DateOfBirth));
                cmd.Parameters.Add(new SqlParameter("@isActive", p.IsActive));
                cmd.Parameters.Add(new SqlParameter("@about", p.About));

                cmd.ExecuteNonQuery();


                Console.Write($"> {p.Firstname} {p.Lastname} has been saved..");
                Console.ReadKey();

                conn.Close();
            }
        }

        public static Profile GetUserProfile(User u)
        {
            Profile p = new Profile();

            // kald til DB her så vi kan finde users profile

            return p;
        }
        public static Profile GetPotentialMatchProfile(User currentUser)
        {
            Profile potentialMatch = new Profile();
            using (SqlConnection conn = new SqlConnection(ConnectionString.GetConnectionString()))
            {
                string command = "GetPotentialMatch";
                SqlCommand cmd = new SqlCommand(command, conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@username", currentUser.Username));

                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    potentialMatch.Firstname = (string)reader.GetValue("firstname");
                    potentialMatch.Lastname = (string)reader.GetValue("lastname");
                    potentialMatch.Gender = (string)reader.GetValue("gender");
                    potentialMatch.InterestedIn = (string)reader.GetValue("interestedIn");
                    potentialMatch.Height = (int)reader.GetValue("height");
                    potentialMatch.Eyecolor = (string)reader.GetValue("eyecolor");
                    potentialMatch.Haircolor = (string)reader.GetValue("haircolor");
                    potentialMatch.Age = (int)reader.GetValue("age");
                    potentialMatch.About = (string)reader.GetValue("about");
                    potentialMatch.ProfileId = (int)reader.GetValue("ID");
                }
            }

            return potentialMatch;
        }

        public static void ChangeProfileStatus(Profile p, User u)
        {

            if (p.IsActive == true) p.IsActive = false;
            if (p.IsActive == false) p.IsActive = true;

            using (SqlConnection conn = new SqlConnection(ConnectionString.GetConnectionString()))
            {
                conn.Open();
                string command = "ChangeStatus";

                SqlCommand cmd = new SqlCommand(command, conn);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@username", u.Username));
                cmd.Parameters.Add(new SqlParameter("@isActive", p.IsActive));

                cmd.ExecuteNonQuery();

                conn.Close();
            }

            Console.SetCursorPosition(2, 22);
            Console.Write("You have changed the status of your profile..");
        }
    }
}
