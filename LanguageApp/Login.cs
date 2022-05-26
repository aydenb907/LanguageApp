using System;
using System.Collections.Generic;
using System.Windows.Forms;


namespace LanguageApp
{
    public partial class Login : Form
    {
        UserManager u = new UserManager();
        public Login(UserManager u)
        {
            //when the Login form opens, the UserManager from program.cs or the previous form 
            //will be passed through to this form so that the list of users in UserManager is kept the same
            //just stating UserManager u = new UserManager(); will mean the list of users will empty, and so the users won't be able to login and keep their progress

            //this is the same for each form, in order for all the users to be stored
            this.u = u;
            InitializeComponent();
           
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

            //if the username the new person typed in matches a username that is already taken, a message box will show and say so
            // preventing the user from moving onto the next form until they sign up properly first
            foreach (string name in u.GetUsernames())
            {
                if (username == name)
                {
                    MessageBox.Show("This username is already taken.");
                    return;
                }
            }

            //these two lists have an index for each lesson, 0 for now because no tests have been done
            List<int> totalScores = new List<int>() {0,0,0 };
            List<int> attempts = new List<int>() {0,0,0 };
            
            //this list is empty because no lessons have been done as they have only just signed up
            List<int> completedLessons = new List<int>();

            //Adds user to users list in UserManager
            MessageBox.Show(u.AddUser(username, password, totalScores, attempts, completedLessons));

            //This form closes and Mainform appears
            this.Hide();
            MainForm m = new MainForm(u);
            m.FormClosed += (s, args) => this.Close();
            m.Show();
        }

        //Finds user's account so they can log in and add to their progress
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUserName.Text;
            string password = txtPassword.Text;

            //Finds user based on what username and password they've typed in, and makes sure they match to any of the profiles
            string message = u.FindUser(username, password);
            
            //If the username or password is incorrect, or the user has not signed up yet, a message box will show and say that it is invalid
            //the program won't move on until they have either created a new account or they have corrected their mistake
            if(message.Equals("Invalid username/password."))
            {
                MessageBox.Show(message);
                return;
            }

            //This form closes and Mainform appears
            this.Hide();
            MainForm m = new MainForm(u);
            m.FormClosed += (s, args) => this.Close();
            m.Show();

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
    }
}
