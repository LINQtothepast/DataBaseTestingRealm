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
        private bool userBlocked;
        private bool userArmed;
        private int userRole;
        private string userVisitedBy;

        //constructor
        public User(string email, string name, int id, int role, bool armed, bool blocked, string visitedBy)
        {
            UserEmail = email;
            UserName = name;
            UserID = id;
            UserArmed = armed;
            UserBlocked = blocked;
            UserRole = role;
            UserVisitedBy = visitedBy;
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
        public bool UserBlocked
        {
            get { return userBlocked; }
            set { userBlocked = value; }
        }
        public bool UserArmed
        {
            get { return userArmed; }
            set { userArmed = value; }
        }
        public int UserRole
        {
            get { return userRole; }
            set { userRole = value; }
        }
        public string UserVisitedBy
        {
            get { return userVisitedBy; }
            set { userVisitedBy = value; }
        }
    }
}
