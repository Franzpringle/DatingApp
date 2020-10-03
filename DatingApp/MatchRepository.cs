using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DatingApp
{
    class MatchRepository
    {
        public static void RegisterLike(User currentUser, Profile potentialMatch)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString.GetConnectionString()))
            {
                string command = "NewLike";

                SqlCommand cmd = new SqlCommand(command, conn);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@username", currentUser.Username));
                cmd.Parameters.Add(new SqlParameter("@matchProfileId", potentialMatch.ProfileId));

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        public static bool CheckIfMatch(Profile currentProfile, Profile potentialMatch)
        {
            bool match = false;
            //check her om der er match via SP

            return match;
        }
    }
}
