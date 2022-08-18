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

        private Color ButtonColour(float a)
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
                return Color.Brown;
            }
            else
            {
                return Color.MintCream;
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
        private void btn2_Click(object sender, EventArgs e)
        {
            lesson = 2;

            this.Hide();

            LessonInfo i = new LessonInfo(u);
            i.FormClosed += (s, args) => this.Close();
            i.Show();
        }
        private void btn3_Click(object sender, EventArgs e)
        {
            lesson = 3;

            this.Hide();

            LessonInfo i = new LessonInfo(u);
            i.FormClosed += (s, args) => this.Close();
            i.Show();
        }
        private void btn4_Click(object sender, EventArgs e)
        {
            lesson = 4;

            this.Hide();

            LessonInfo i = new LessonInfo(u);
            i.FormClosed += (s, args) => this.Close();
            i.Show();
        }



        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
         
            this.Hide();
            Login i = new Login(u);
            i.FormClosed += (s, args) => this.Close();
            i.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this account?", "Delete Account", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                
                string query = "DELETE FROM UsersTable WHERE UserID = @UserID";

                using (connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();

                    command.Parameters.AddWithValue("@UserID", u.GetId());
                    command.ExecuteScalar();
                }

                MessageBox.Show($"Your account {u.GetUsername()} has been deleted.");

                u.DeleteUser();
               
                this.Hide();
                Login i = new Login(u);
                i.FormClosed += (s, args) => this.Close();
                i.Show();
            }
            
        }

        private void btnUsernameChange_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "")
            {
                MessageBox.Show("Your new username can't be blank.");
                return;
            }

           

            DialogResult dialogResult = MessageBox.Show("Are you sure you want to change your username?", "Change Username", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                string query = "UPDATE UsersTable SET username = @username WHERE UserID = @UserID";

                using (connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@username", txtUsername.Text);
                    command.Parameters.AddWithValue("@UserID", u.GetId());
                    command.ExecuteScalar();
                }

                u.ChangeUsername(txtUsername.Text);

                this.Hide();
                MainForm m = new MainForm(u);
                m.FormClosed += (s, args) => this.Close();
                m.Show();
            }
        
        }

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
    }
}
