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
        private string enteredUsername;
        private SqlConnection connect;

        public MainWindow()
        {
            enteredUsername = "a";
            InitializeComponent();
            UserCollection.fillListFromDB();
            sessionUser = UserCollection.returnAUser(enteredUsername);

            UserList = UserCollection.returnAList();

            PlayerListBox.ItemsSource = UserList;
            UsernameLabel.Content = sessionUser.UserName;
        }

        private void DatabaseButton_Click(object sender, RoutedEventArgs e)
        {
            string connetionString = null;
            connetionString = ("user id=Derek;" +
                                "server=localhost;" +
                                "Trusted_Connection=yes;" +
                                "database=Test");

            using (connect = new SqlConnection(connetionString))
            {
                connect.Open();
                string command = "INSERT INTO UserTable"
                + " (Email, Name, ID) " +
                 "VALUES (@Email, @Name, @ID)";
                SqlCommand insertCommand = new SqlCommand(command, connect);
                insertCommand.Parameters.AddWithValue("@Email", "h");
                insertCommand.Parameters.AddWithValue("@Name", "h");
                insertCommand.Parameters.AddWithValue("@ID", 1);
                //go to m for 15
                insertCommand.ExecuteNonQuery();
                connect.Close();
            }
        }
    }
}
