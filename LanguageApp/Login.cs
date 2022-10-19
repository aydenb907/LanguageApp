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
            //will be passed through to this form so that the list of users in UserManager isn't lost
            //just stating UserManager u = new UserManager(); for every form will mean the list of users will empty, and so the users won't be able to login and keep their progress

            //this is the same for each form, in order for all the users to be stored
            this.u = u;
            InitializeComponent();

            connectionString = ConfigurationManager.ConnectionStrings["LanguageApp.Properties.Settings.Database1ConnectionString"].ConnectionString; //needed to connect to the database
   
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
           
            string password = txtPassword.Text;


            //makes sure password is not blank
            if(password == "")
            {
                MessageBox.Show("Choose a password.");
                return;
            }
            //makes sure password is at least 6 characters
            if(password.Length <6)
            {
                MessageBox.Show("Make sure your password is at least 6 characters long.");
                return;
            }

            //Checks that username isn't already taken

            string query = "SELECT COUNT(*) FROM UsersTable " +
                  "WHERE username = @username";
            int count;

            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();

                command.Parameters.AddWithValue("@username", username);
                count = (int)command.ExecuteScalar();

                //if the username is already in the table, then the user will have to choose another username if they want to proceed

                if (count == 1)
                {
                    MessageBox.Show("Sorry but this username is already taken. Please choose another username.");
                }

                else //otherwise, the new user's username and password will be added
                {

                    string queryTwo = "INSERT INTO UsersTable VALUES (@username, @password)";

                    using (SqlCommand commandTwo = new SqlCommand(queryTwo, connection))
                    {


                        commandTwo.Parameters.AddWithValue("@username", username);
                        commandTwo.Parameters.AddWithValue("@password", password);

                        commandTwo.ExecuteScalar();

                        //Selects id of new user so that it can be added along with the username to the user class. Id and username is needed for other methods, but not the password. Password will have been stored in the databse in case they log in again
                        string queryThree = "SELECT UserID FROM UsersTable WHERE username = @username";

                        using (SqlCommand commandThree = new SqlCommand(queryThree, connection))
                        {

                            commandThree.Parameters.AddWithValue("@username", username);
                            int id = (int)commandThree.ExecuteScalar();

                            u.NewUser(id, username);
                        }

                        MessageBox.Show("User has been added.");

                            
                      //Once the new user had been added to the database and the users list in UserManager:

                        //This form closes and Mainform appears
                        this.Hide();
                        MainForm m = new MainForm(u);
                        m.FormClosed += (s, args) => this.Close();
                        m.Show();
                    }

                }


            }

        }

        //Finds user's account in the database so they can log in and add to their progress
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUserName.Text;
            string password = txtPassword.Text;

            //Selects number of users in the UsersTable that has the same username and password they've typed in

            string query = "SELECT COUNT(*) FROM UsersTable WHERE username = @username AND password = @password";
            int count;

            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();

                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@password", password);
                count = (int)command.ExecuteScalar();

                //If the number is zero, then that means they haven't signed up yet or they typed in the username or password incorrectly, so that there are no matches in the database. 
                if (count == 0)
                {
                    MessageBox.Show("Sorry but the username and/or password is incorrect");
                }
                //Else, there will be one user in the database that matches exactly what they've typed in the form, so login will be successful. They will move onto the next form, the mainform. 
                //There shouldn't be more than one of the same username with the same password in the database, because when they sign up it prevents that 
                else
                {
                    u.Login(username); //Method removes user if they've logged in already since the program started, and adds them again so they are in the last index
                    //This form closes and Mainform appears
                    this.Hide();
                    MainForm m = new MainForm(u);
                    m.FormClosed += (s, args) => this.Close();
                    m.Show();
                }


            }

        }

        
        //When this button is clicked, it controls whether the user can see the password they're typing in or not
        private void button1_Click(object sender, EventArgs e)
        {
            //Before they press the button, password's text colour is already transparent.


            //If the password is already hidden (textbox font colour is transparent) then when they click the button, the font colour will change to black so that they can see it
            if(txtPassword.ForeColor == Color.Transparent)
            {
                txtPassword.ForeColor = Color.Black;
                button1.Text = "Hide password"; //Button text changes as well so they know what will happen if they press the button again, which is change back to transparent font colour
            }
            else //If they click again to hide the password once more, the font colour will go back to the original
            {
                txtPassword.ForeColor = Color.Transparent;
                button1.Text = "Show password";
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            
        }
    }
}
