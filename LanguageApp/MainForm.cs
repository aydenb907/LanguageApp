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

        public MainForm(UserManager u)
        {

            this.u = u;
            InitializeComponent();

        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            lblUsername.Text = u.GetUsername();
            lblTotalScore.Text = u.DisplayTotalPoints();
            lblPlace.Text = u.CompareTotalScores(lblUsername.Text);

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
                string connectionString = ConfigurationManager.ConnectionStrings["LanguageApp.Properties.Settings.Database1ConnectionString"].ConnectionString;
                string query = "DELETE FROM UsersTable WHERE UserID = @UserID";

                using (SqlConnection connection = new SqlConnection(connectionString))
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

        
    }
}
