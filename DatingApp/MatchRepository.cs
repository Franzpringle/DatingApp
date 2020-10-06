using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading;

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
            bool isMatch = false;

            using (SqlConnection conn = new SqlConnection(ConnectionString.GetConnectionString()))
            {
                conn.Open();

                string command = "DidWeMatch";

                SqlCommand cmd = new SqlCommand(command, conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.Add(new SqlParameter("@senderId", currentProfile.ProfileId));
                cmd.Parameters.Add(new SqlParameter("@recieverId", potentialMatch.ProfileId));


                var count = cmd.ExecuteScalar();
                int Matched = Convert.ToInt32(count);
                
                if (Convert.ToInt32(Matched) == 2)
                {
                    isMatch = true;
                }

                conn.Close();
            }
            return isMatch;

        }

        public static bool AnyMatchesWithoutMessageThread(Profile currentProfile)
        {
            bool jackpot = false;

            using (SqlConnection conn = new SqlConnection(ConnectionString.GetConnectionString()))
            {
                string command = "AnyMatchesWithoutMessageThread";

                SqlCommand cmd = new SqlCommand(command, conn);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@userid", currentProfile.ProfileId));

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }

            return jackpot;
        }
    }
}
