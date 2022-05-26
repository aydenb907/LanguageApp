using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        
        //Lesson buttons
        //Same process for each lesson button
        private void btnBeginner_Click(object sender, EventArgs e)
        {
            lesson = 0;
            //once they clicked on a lesson, the lesson will be added to the user's completed lessons so when they come back to the mainform, 
            //the button for this lesson will be a different colour and they will know they've already looked at this lesson
            u.AddLessonsToUser(0);

            //closes mainform and goes onto the lesson's form
            this.Hide();
            LessonInfo i = new LessonInfo(u);
            i.FormClosed += (s, args) => this.Close();
            i.Show();
        }
        //Same for every lesson button
        private void btn1_Click(object sender, EventArgs e)
        {
            lesson = 1; // integer will be used to display the right text for the lesson
            u.AddLessonsToUser(1); //adds lesson to list of lessons users have clicked on, so that when they return to the mainform the button will be a different colour to show they've already done that lesson
            
            //Goes to lesson form
            this.Hide();
            LessonInfo i = new LessonInfo(u);
            i.FormClosed += (s, args) => this.Close();
            i.Show();
        }
        private void btn2_Click(object sender, EventArgs e)
        {
            lesson = 2;
            u.AddLessonsToUser(2);
            this.Hide();
           
            LessonInfo i = new LessonInfo(u);
            i.FormClosed += (s, args) => this.Close();
            i.Show();
        }

        
        private void MainForm_Load(object sender, EventArgs e)
        {
            //Checks which lessons have been done to change the colour of their buttons
            List<int> lessons = u.GetLessons();

            foreach (int l in lessons)
            {
                if (l==1)
                {
                    btn1.BackColor = Color.LightGreen;
                }
                else if (l==2)
                {
                    btn2.BackColor = Color.LightGreen;
                }
                else
                {
                    btnBeginner.BackColor = Color.LightGreen;
                }
            }

            //Displays username and user's information
            lblUsername.Text = u.GetUsername();
            lblTotalScore.Text = u.CalcTotalPoints();
            //Gets total points for user
            int place = u.CompareTotalScores(lblUsername.Text);

            //If their placing is 1, will display 'st' on the end, if it's 2, it will end in 'nd', etc
            if(place == 1)
            {
                lblPlace.Text = $"1st place";
            }
            else if (place == 2)
            {
                lblPlace.Text = $"2nd place";
            }
            else if (place == 3)
            {
                lblPlace.Text = $"3rd place";
            }
            else
            {
                lblPlace.Text = $"{place}th place";
            }

        }

        //menu strip

        //Goes to login form
        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            this.Hide();
            Login l = new Login(u);
            l.FormClosed += (s, args) => this.Close();
            l.Show();
        }
        
        //Displays message box when clicked
        private void menuInfo_Click(object sender, EventArgs e)
        {
            MessageBox.Show("");
        }
    }
}
