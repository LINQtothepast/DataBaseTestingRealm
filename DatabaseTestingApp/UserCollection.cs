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
            User temp = new User("temp", "temp", 0);
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
                            UserList.Add(new User(tempEmail, tempName, tempID));
                        }
                    }
                }
                connect.Close();
            }
        }
    }
}
