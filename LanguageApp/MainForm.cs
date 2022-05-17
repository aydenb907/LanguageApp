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
        
        private void btnBeginner_Click(object sender, EventArgs e)
        {
            lesson = 0;
            u.AddLessonsToUser(0);
            this.Hide();
            Info i = new Info(u);
            i.FormClosed += (s, args) => this.Close();
            i.Show();
        }
        private void btn1_Click(object sender, EventArgs e)
        {
            lesson = 1;
            u.AddLessonsToUser(1);
            this.Hide();
            Info i = new Info(u);
            i.FormClosed += (s, args) => this.Close();
            i.Show();
        }
        private void btn2_Click(object sender, EventArgs e)
        {
            lesson = 2;
            u.AddLessonsToUser(2);
            this.Hide();
           
            Info i = new Info(u);
            i.FormClosed += (s, args) => this.Close();
            i.Show();
        }

        private void menuInfo_Click(object sender, EventArgs e)
        {
            MessageBox.Show("");
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            List<int> lessons = u.GetLessons();

            foreach (int l in lessons)
            {
                if (l==1)
                {
                    btn1.BackColor = Color.AntiqueWhite;
                }
                if (l==2)
                {
                    btn2.BackColor = Color.AntiqueWhite;
                }
            }

            lblUsername.Text = u.GetUsername();
            lblTotalScore.Text = u.CalcTotalScore();

            int place = u.CompareTotalScores(lblUsername.Text);

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

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login l = new Login(u);
            l.FormClosed += (s, args) => this.Close();
            l.Show();
        }
    }
}
