using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace DatabaseTestingApp
{
    class UserCollection
    {
        private static SqlConnection connect;
        private static List<User> UserList = new List<User>();

        public static List<User> returnAList()
        {
            return UserList;
        }

        public static User returnAUser(string passedName)
        {
            User temp = new User("temp", "temp", 0, 0, false, false, "");
            foreach (User element in UserList)
            {
                if (element.UserName == passedName)
                {
                    temp = element;
                }
            }
            return temp;
        }

        public static void fillListFromDB()
        {
            //connect to database
            string connetionString = ("user id=Derek;" +
                                "server=localhost;" +
                                "Trusted_Connection=yes;" +
                                "database=Test");

            using (connect = new SqlConnection(connetionString))
            {
                connect.Open();
                string readString = "select * from UserTable";
                SqlCommand readCommand = new SqlCommand(readString, connect);

                using (SqlDataReader dataRead = readCommand.ExecuteReader())
                {
                    if (dataRead != null)
                    {
                        while (dataRead.Read())
                        {
                            string tempEmail = dataRead["Email"].ToString();
                            string tempName = dataRead["Name"].ToString();
                            int tempID = Convert.ToInt32(dataRead["ID"]);
                            UserList.Add(new User(tempEmail, tempName, tempID, 0, false, false, ""));
                        }
                    }
                }
                connect.Close();
            }
        }

        public static void ResetStatusTable()
        {
            //connect to database
            string connetionString = ("user id=Derek;" +
                                "server=localhost;" +
                                "Trusted_Connection=yes;" +
                                "database=Test");

            using (connect = new SqlConnection(connetionString))
            {
                connect.Open();

                for(int i = 1; i < 16; i++)
                {
                    using (SqlCommand cmd =
                    new SqlCommand("UPDATE UserStatus SET Role=@Role, Status=@Status, RoleName=@RoleName, " +
                    "Blocked=@Blocked, Conned=@Conned, Saved=@Saved, Killed=@Killed, " +
                    "Armed=@Armed, RoleActive=@RoleActive, VisitedBy=@VisitedBy" +
                    " WHERE Id=@Id", connect))
                    {
                        cmd.Parameters.AddWithValue("@Id", i);
                        cmd.Parameters.AddWithValue("@Role", 0);
                        cmd.Parameters.AddWithValue("@RoleName", "");
                        cmd.Parameters.AddWithValue("@Status", 0);
                        cmd.Parameters.AddWithValue("@Blocked", 0);
                        cmd.Parameters.AddWithValue("@Conned", 0);
                        cmd.Parameters.AddWithValue("@Saved", 0);
                        cmd.Parameters.AddWithValue("@Killed", 0);
                        cmd.Parameters.AddWithValue("@Armed", 0);
                        cmd.Parameters.AddWithValue("@RoleActive", 0);
                        cmd.Parameters.AddWithValue("@VisitedBy", "");

                        int rows = cmd.ExecuteNonQuery();
                    }
                }
                

                connect.Close();
            }
        }

        public static void ResetLynchVoteTable()
        {
            //connect to database
            string connetionString = ("user id=Derek;" +
                                "server=localhost;" +
                                "Trusted_Connection=yes;" +
                                "database=Test");

            using (connect = new SqlConnection(connetionString))
            {
                connect.Open();

                for (int i = 1; i < 16; i++)
                {
                    using (SqlCommand cmd =
                    new SqlCommand("UPDATE LynchTable SET NominationVotes=@NominationVotes, LynchVotes=@LynchVotes" +
                    " WHERE Id=@Id", connect))
                    {
                        cmd.Parameters.AddWithValue("@Id", i);
                        cmd.Parameters.AddWithValue("@NominationVotes", 0);
                        cmd.Parameters.AddWithValue("@LynchVotes", 0);
                        
                        int rows = cmd.ExecuteNonQuery();
                    }
                }


                connect.Close();
            }
        }
    }
}
