using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseTestingApp
{
    public class User
    {
        //attributes
        private string userEmail;
        private string userName;
        private int userID;

        //constructor
        public User(string email, string name, int id)
        {
            UserEmail = email;
            UserName = name;
            UserID = id;
        }

        //properties
        public string UserEmail
        {
            get { return userEmail; }
            set { userEmail = value; }
        }
        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }
        public int UserID
        {
            get { return userID; }
            set { userID = value; }
        }
    }
}
