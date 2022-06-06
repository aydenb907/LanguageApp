using System;
using System.Collections.Generic;
using System.Windows.Forms;

using System.Data.SqlClient;
using System.Configuration;
using System.Drawing;

namespace LanguageApp
{
    public partial class Login : Form
    {
        UserManager u = new UserManager();
        SqlConnection connection;
        string connectionString;

        public Login(UserManager u)
        {
            //when the Login form opens, the UserManager from program.cs or the previous form 
            //will be passed through to this form so that the list of users in UserManager is kept the same
            //just stating UserManager u = new UserManager(); will mean the list of users will empty, and so the users won't be able to login and keep their progress

            //this is the same for each form, in order for all the users to be stored
            this.u = u;
            InitializeComponent();

            connectionString = ConfigurationManager.ConnectionStrings["LanguageApp.Properties.Settings.Database1ConnectionString"].ConnectionString;

        }

        //Adds new person's username and password
        private void btnSignUp_Click(object sender, EventArgs e)
        {
            string username = txtUserName.Text;

            //makes sure username is not blank
            if(username == "")
            {
                MessageBox.Show("Choose a username.");
                return;
            }
            //password is not checked to see if it matches any other passwords
            string password = txtPassword.Text;


            //makes sure password is not blank
            if(password == "")
            {
                MessageBox.Show("Choose a password.");
                return;
            }
            if(password.Length <6)
            {
                MessageBox.Show("Make sure your password is at least 6 characters long.");
                return;
            }


            string query = "SELECT COUNT(*) FROM UsersTable " +
                  "WHERE username = @username";
            int count;

            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();

                command.Parameters.AddWithValue("@username", username);
                count = (int)command.ExecuteScalar();

                if (count == 1)
                {
                    MessageBox.Show("Sorry but this username is already taken. Please choose another username.");
                }

                else
                {

                    string queryTwo = "INSERT INTO UsersTable VALUES (@username, @password)";

                    using (SqlCommand commandTwo = new SqlCommand(queryTwo, connection))
                    {


                        commandTwo.Parameters.AddWithValue("@username", username);
                        commandTwo.Parameters.AddWithValue("@password", password);

                        commandTwo.ExecuteScalar();

                        u.NewUser(username, password);

                        //This form closes and Mainform appears
                        this.Hide();
                        MainForm m = new MainForm(u);
                        m.FormClosed += (s, args) => this.Close();
                        m.Show();
                    }

                }


            }

        }

        //Finds user's account so they can log in and add to their progress
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUserName.Text;
            string password = txtPassword.Text;


            string query = "SELECT COUNT(*) FROM UsersTable " +
                           "WHERE password = @password AND username = @username";
            int count;

            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();

                command.Parameters.AddWithValue("@password", password);
                command.Parameters.AddWithValue("@username", username);
                count = (int)command.ExecuteScalar();

                if (count == 1)
                {
                    u.NewUser(username);

                    //This form closes and Mainform appears
                    this.Hide();
                    MainForm m = new MainForm(u);
                    m.FormClosed += (s, args) => this.Close();
                    m.Show();

                }
                else
                {

                    MessageBox.Show("The username or password that you have entered is incorrect.");
                }
                connection.Close();

            }

        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {
            

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
           
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(txtPassword.ForeColor == Color.Transparent)
            {
                txtPassword.ForeColor = Color.Black;
            }
            else
            {
                txtPassword.ForeColor = Color.Transparent;
            }
            
        }
    }
}
