using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;


namespace DatabaseTestingApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<User> UserList;
        private User sessionUser;
        private User passedUser;
        private string enteredUsername;

        public MainWindow()
        {
            enteredUsername = "a";
            InitializeComponent();
            UserCollection.fillListFromDB();
            passedUser = UserCollection.returnAUser("b");
            sessionUser = UserCollection.returnAUser(enteredUsername);
            passedUser.UserRole = 13;

            UserList = UserCollection.returnAList();

            PlayerListBox.ItemsSource = UserList;
        }


        private void ResetStatusClick(object sender, RoutedEventArgs e)
        {
            UserCollection.ResetStatusTable();
        }

        private void ResetVotesClick(object sender, RoutedEventArgs e)
        {
            UserCollection.ResetLynchVoteTable();
        }


        public void UserValuesClick(object sender, RoutedEventArgs e)
        {
            SqlConnection connect;
            
            string retRole = "n/a", retArmed = "n/a", retBlocked = "n/a", retVisitedBy = "n/a";
            //connect to database
            string connetionString = ("user id=Derek;" +
                                "server=localhost;" +
                                "Trusted_Connection=yes;" +
                                "database=Test");

            connect = new SqlConnection(connetionString);
            connect.Open();

            SqlCommand command = new SqlCommand("Select role, blocked, armed, visitedby FROM [UserStatus] WHERE ID=@ID", connect);
            command.Parameters.AddWithValue("@ID", passedUser.UserID);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    retRole = reader["Role"].ToString();
                    retBlocked = reader["Blocked"].ToString();
                    retArmed = reader["Armed"].ToString();
                    retVisitedBy = reader["VisitedBy"].ToString();
                }
            }
            connect.Close();


            Username.Content = passedUser.UserName;
            Role.Content = retRole;
            Armed.Content = retArmed;
            Blocked.Content = retBlocked;
            VisitedBy.Content = retVisitedBy;
        }


        private void ArmedClick(object sender, RoutedEventArgs e)
        {
            SqlConnection connect;
            string connetionString = null;
            connetionString = ("user id=Derek;" +
                                "server=localhost;" +
                                "Trusted_Connection=yes;" +
                                "database=Test");

            using (connect = new SqlConnection(connetionString))
            {
                connect.Open();
                passedUser.UserArmed = true;
                using (SqlCommand cmd =
                new SqlCommand("UPDATE UserStatus SET Armed=@Armed" +
                " WHERE Id=@Id", connect))
                {
                    cmd.Parameters.AddWithValue("@Id", passedUser.UserID);
                    cmd.Parameters.AddWithValue("@Armed", 1);

                    int rows = cmd.ExecuteNonQuery();
                    connect.Close();
                }
            }
        }


        private void BardClick(object sender, RoutedEventArgs e)
        {
            SqlConnection connect;
            string connetionString = null;
            connetionString = ("user id=Derek;" +
                                "server=localhost;" +
                                "Trusted_Connection=yes;" +
                                "database=Test");

            using (connect = new SqlConnection(connetionString))
            {
                connect.Open();
                string retVisitedBy = "";

                if (passedUser.UserRole == 13)
                {
                    passedUser.UserArmed = false;
                    using (SqlCommand cmd =
                    new SqlCommand("UPDATE UserStatus SET Armed=@Armed" +
                    " WHERE Id=@Id", connect))
                    {
                        cmd.Parameters.AddWithValue("@Id", passedUser.UserID);
                        cmd.Parameters.AddWithValue("@Armed", 0);

                        int rows = cmd.ExecuteNonQuery();
                    }
                }


                SqlCommand command = new SqlCommand("Select visitedby FROM [UserStatus] WHERE ID=@ID", connect);
                command.Parameters.AddWithValue("@ID", passedUser.UserID);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        retVisitedBy = reader["VisitedBy"].ToString();
                    }
                }

                retVisitedBy += (" " + sessionUser.UserName);

                passedUser.UserBlocked = true;
                passedUser.UserVisitedBy += sessionUser.UserName + " ";

                using (SqlCommand cmd =
                new SqlCommand("UPDATE UserStatus SET VisitedBy=@VisitedBy" +
                " WHERE Id=@Id", connect))
                {
                    cmd.Parameters.AddWithValue("@Id", passedUser.UserID);
                    cmd.Parameters.AddWithValue("@VisitedBy", retVisitedBy);

                    int rows = cmd.ExecuteNonQuery();
                }

                using (SqlCommand cmd =
                new SqlCommand("UPDATE UserStatus SET Blocked=@Blocked" +
                " WHERE Id=@Id", connect))
                {
                    cmd.Parameters.AddWithValue("@Id", passedUser.UserID);
                    cmd.Parameters.AddWithValue("@Blocked", 1);

                    int rows = cmd.ExecuteNonQuery();
                }

                connect.Close();
            }
        }
    }
}
