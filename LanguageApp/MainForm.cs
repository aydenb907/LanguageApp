using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LanguageApp
{
    public partial class MainForm : Form
    {
        UserManager u = new UserManager();
        public static int lesson;

        private string connectionString = ConfigurationManager.ConnectionStrings["LanguageApp.Properties.Settings.Database1ConnectionString"].ConnectionString;
        SqlConnection connection;
        public MainForm(UserManager u)
        {

            this.u = u;
            InitializeComponent();

        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            //Displays user's details: names, total points, placing out of all the users based on total points
            lblUsername.Text = u.GetUsername(); 
            lblTotalScore.Text = u.DisplayTotalPoints();
            lblPlace.Text = u.CalculatePlacingForUser(lblUsername.Text);

            //Shows the users in order of their placings, with their total points next to their name
            lblUsers.Text = u.SortUsers();

           
            //Sets colour for each button based on the average score 
            btn1.BackColor = ButtonColour(u.GetAvgScore(1));
            btn2.BackColor = ButtonColour(u.GetAvgScore(2));
            btn3.BackColor = ButtonColour(u.GetAvgScore(3));
            btn3.BackColor = ButtonColour(u.GetAvgScore(4));


        }

        //generates colour based on how well they've done in the test for a lesson
        private Color ButtonColour(decimal a)
        {
           
            if (a>90)
            {
                return Color.DarkCyan;
            }
            else if (a>70)
            {
                return Color.SeaGreen;
            }
            else if(a>50)
            {
                return Color.DarkGoldenrod;
            }
            else if(a>0)
            {
                return Color.Brown; //reddish colour for a bad average score
            }
            else
            {
                return Color.MintCream; //if there is no average score the colour will be white to show they haven't attempted it yet
            }
           
        }



        //Lesson buttons 
        //Same for every lesson button
        private void btn1_Click(object sender, EventArgs e)
        {
            lesson = 1; // integer will be used to display the right text for the lesson


            //Goes to lesson form
            this.Hide();
            LessonInfo i = new LessonInfo(u);
            i.FormClosed += (s, args) => this.Close();
            i.Show();
        }
        //Other buttons don't have complete lessons in the database yet, which means the program would break if they are clicked and the other forms are opened. 
        //So for now, nothing will happen when the other 3 buttons are clicked. These buttons are added on the mainform to show the layout.
        private void btn2_Click(object sender, EventArgs e)
        {
           /* lesson = 2;

            this.Hide();

            LessonInfo i = new LessonInfo(u);
            i.FormClosed += (s, args) => this.Close();
            i.Show();*/
        }
        private void btn3_Click(object sender, EventArgs e)
        {
           /* lesson = 3;

            this.Hide();

            LessonInfo i = new LessonInfo(u);
            i.FormClosed += (s, args) => this.Close();
            i.Show();*/
        }
        private void btn4_Click(object sender, EventArgs e)
        {
           /* lesson = 4;

            this.Hide();

            LessonInfo i = new LessonInfo(u);
            i.FormClosed += (s, args) => this.Close();
            i.Show();*/
        }


        //Logs the user out. Returns to Login Form
        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
         
            this.Hide();
            Login i = new Login(u);
            i.FormClosed += (s, args) => this.Close();
            i.Show();
        }

        //When the delete account button is clicked, it removes the user from the database and from the users list
        private void button1_Click(object sender, EventArgs e)
        {
            //Message box pops up whenever they click the button to confirm they really want to delete their account
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this account?", "Delete Account", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)    // if they press yes then they will be deleted, and it will return to the login form because they can no longer continue with their lessons
            {
              
                //Deletes user from UsersTable. If they remain in the database, then they will be added again to the users list when the program starts again and still be included in the leaderboard
                string query = "DELETE FROM UsersTable WHERE UserID = @UserID";

                using (connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();

                    command.Parameters.AddWithValue("@UserID", u.GetId()); //
                    command.ExecuteScalar();
                }

                //Deletes all of the user's scores from TestTable, because it's unnecessary to store them now.
                string queryTwo = "DELETE FROM TestTable WHERE UserID = @UserID";
                using (connection = new SqlConnection(connectionString))
                using (SqlCommand command2 = new SqlCommand(queryTwo, connection))
                {
                    connection.Open();
                    command2.Parameters.AddWithValue("@UserID", u.GetId()); //
                    command2.ExecuteScalar();
                }


                //Message box states that their account has been deleted before actually being deleted from the users list, because their username is still needed for this message. 
                //Username is placed in the message box to confirm their account has been the one deleted.
                MessageBox.Show($"Your account {u.GetUsername()} has been deleted.");

                u.DeleteUser();

             
                this.Hide();
                Login i = new Login(u);
                i.FormClosed += (s, args) => this.Close();
                i.Show();
            }
            
        }

        //Changes username, in database and users list 
        private void btnUsernameChange_Click(object sender, EventArgs e)
        {

            //if they've typed nothing in, they won't be allowed to change their username. Otherwise if they have a high total of points the leaderboard will appear blank
            if (txtUsername.Text == "")
            {
                MessageBox.Show("Your new username can't be blank.");
                return;
            }

           
            //Makes sure they actually want to change their username
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to change your username?", "Change Username", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                //if yes, then the database is updated, rather than have the user's account removed and then added again with the new username
                string query = "UPDATE UsersTable SET username = @username WHERE UserID = @UserID";

                using (connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@username", txtUsername.Text);
                    command.Parameters.AddWithValue("@UserID", u.GetId());
                    command.ExecuteScalar();
                }

                //UserManager changes username for the user stored in the list
                u.ChangeUsername(txtUsername.Text);

                //Reloads mainform, so that the new username is seen in the group box with the placing and total points. Also on the leaderboard if they're high enough on it
                //If the mainform doesn't relaod then they won't be able to tell if the change has actually occurred.
                this.Hide();
                MainForm m = new MainForm(u);
                m.FormClosed += (s, args) => this.Close();
                m.Show();
            }
        
        }

        //Changes password, same for when changing username, except makes sure their password is a certain length just like the login form. Maintains consistency and to help make their account more secure
        private void btnPasswordChange_Click(object sender, EventArgs e)
        {

            //makes sure password is not blank
            if (txtPassword.Text == "")
            {
                MessageBox.Show("Your new password can't be blank.");
                return;
            }
            //makes sure password is at least 6 characters
            if (txtPassword.TextLength < 6)
            {
                MessageBox.Show("Make sure your new password is at least 6 characters long.");
                return;
            }
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to change your password?", "Change Password", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                string query = "UPDATE UsersTable SET password = @password WHERE UserID = @UserID";

                using (connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@password", txtPassword.Text);
                    command.Parameters.AddWithValue("@UserID", u.GetId());
                    command.ExecuteScalar();
                }
                

                this.Hide();
                MainForm m = new MainForm(u);
                m.FormClosed += (s, args) => this.Close();
                m.Show();
            }
        }

        //This button has exactly same function as one in login. Hides or reveals password depending on how many times they click the button. When they change their password, just like with
        //signing up or logging in, they may not want someone else to see their password
        private void button7_Click(object sender, EventArgs e)
        {
            if (txtPassword.ForeColor == Color.Transparent)
            {
                txtPassword.ForeColor = Color.Black;
                button7.Text = "Hide password"; //Button text changes as well so they know what will happen if they press the button again, which is change back to transparent font colour
            }
            else //If they click again to hide the password once more, the font colour will go back to the original
            {
                txtPassword.ForeColor = Color.Transparent;
                button7.Text = "Show password";
            }
        }

        private void lblUsers_Click(object sender, EventArgs e)
        {

        }

    
        private void completeVocabularyListOfThisAppToolStripMenuItem_Click(object sender, EventArgs e)
        {

         
        }

        private void menuInfo_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The main purpose of this app is to learn German grammar, including how to structure a sentence, how to use prepositions, how to conjugate verbs etc." +
                "Each lesson covers a specific topic, with its own vocabulary list....");
        }

        private void dToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("1. German is the 12th most spoken language in the world, with 132 million speakers. Just under 32 million speakers are non-native too.\n" +
                "2. \n" +
                "");
        }

         //Sorts all German words alphabetically into a list with the English meaning beside them
        private void germanToEnglishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<string> englishWords = new List<string>();
            List<string> germanWords = new List<string>();


            string query = "SELECT answer from QuestionsTable WHERE type = @type";
            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();
                command.Parameters.AddWithValue("@type", "words");


                SqlDataReader reader = command.ExecuteReader();

                //adds English word, so that the indexes in both lists are linked 
                while (reader.Read())
                {
                    germanWords.Add((string)reader[0]);
                }
                reader.Close();


            }

            germanWords.Sort();

            foreach (string word in germanWords)
            {
                //selects the English word where a German word in the database is the same as the German word in the list
                string query2 = "SELECT question from QuestionsTable WHERE answer = @answer";

                using (connection = new SqlConnection(connectionString))
                using (SqlCommand command2 = new SqlCommand(query2, connection))
                {
                    connection.Open();
                    command2.Parameters.AddWithValue("@answer", word);


                    SqlDataReader reader = command2.ExecuteReader();

                    //adds English word, so that the indexes in both lists are linked 
                    while (reader.Read())
                    {
                        englishWords.Add((string)reader[0]);
                    }
                    reader.Close();


                }
            }


            //Combines the english words and German words into one list, German word before English word
            string message = "German to English Vocabulary List\n\n";

            for (int i = 0; i < germanWords.Count; i++)
            {
                message += germanWords[i] + " | " + englishWords[i] + "\n";
            }       
            MessageBox.Show(message);
        }

        //same as before but English and German are swapped around
        private void englishToGermanToolStripMenuItem_Click(object sender, EventArgs e)
        {


            List<string> germanWords = new List<string>();
            List<string> englishWords = new List<string>();

            string query = "SELECT question from QuestionsTable WHERE type = @type";
            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();
                command.Parameters.AddWithValue("@type", "words");


                SqlDataReader reader = command.ExecuteReader();

                //adds English word, so that the indexes in both lists are linked 
                while (reader.Read())
                {
                    englishWords.Add((string)reader[0]);
                }
                reader.Close();


            }
            englishWords.Sort();

            foreach (string word in englishWords)
            {
                //selects the English word where a German word in the database is the same as the German word in the list
                string query2 = "SELECT answer from QuestionsTable WHERE question = @question";

                using (connection = new SqlConnection(connectionString))
                using (SqlCommand command2 = new SqlCommand(query2, connection))
                {
                    connection.Open();
                    command2.Parameters.AddWithValue("@question", word);


                    SqlDataReader reader = command2.ExecuteReader();

                    //adds English word, so that the indexes in both lists are linked 
                    while (reader.Read())
                    {
                        germanWords.Add((string)reader[0]);
                    }
                    reader.Close();


                }
            }


            //Combines the english words and German words into one list, German word before English word
            string message = "English to German Vocabulary List\n\n";

            for (int i = 0; i < germanWords.Count; i++)
            {
                message += englishWords[i] + " | " + germanWords[i] + "\n";
            }



            MessageBox.Show(message);
          


        }
    }
    
}
