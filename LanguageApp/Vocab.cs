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
    public partial class Vocab : Form
    {
        UserManager u = new UserManager();

        public Vocab(UserManager u)
        {
            this.u = u;
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
         
            //initially displays one German word for each button 
            btn1.Text = Lesson.GermanWord(0);
            btn2.Text = Lesson.GermanWord(1);
            btn3.Text = Lesson.GermanWord(2);
            btn4.Text = Lesson.GermanWord(3);
            btn5.Text = Lesson.GermanWord(4);
            btn6.Text = Lesson.GermanWord(5);
            btn7.Text = Lesson.GermanWord(6);
            btn8.Text = Lesson.GermanWord(7);
            btn9.Text = Lesson.GermanWord(8);
            btn10.Text = Lesson.GermanWord(9);
            btn11.Text = Lesson.GermanWord(10);
            btn12.Text = Lesson.GermanWord(11);

            //displays user's details in the corner
            lblUsername.Text = u.GetUsername();
            lblTotalPoints.Text = u.DisplayTotalPoints();
            lblPlace.Text = u.CalculatePlacingForUser(lblUsername.Text);

        }


        private void btnHome_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm m = new MainForm(u);
            m.FormClosed += (s, args) => this.Close();
            m.Show();
        }

        private void btnLesson_Click(object sender, EventArgs e)
        {
            this.Hide();
            LessonInfo i = new LessonInfo(u);
            i.FormClosed += (s, args) => this.Close();
            i.Show();
        }

        //goes to practice form once user feels familiar with the vocab words, to test their active vocabulary
        private void btnMemorise_Click(object sender, EventArgs e)
        {
           
            this.Hide();
            PractiseForm p = new PractiseForm(u, "words"); //type is "words", to make sure practice questions aren't displayed when the new form loads instead
            p.FormClosed += (s, args) => this.Close();
            p.Show();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
       
            this.Hide();
            Login l = new Login(u);
            l.FormClosed += (s, args) => this.Close();
            l.Show();
        }


        //Word Buttons

        //When each button is clicked, its text changes from the German word to the English word.
        //the background colour also switches, to indicate there is a change in the button
        private void btn1_Click(object sender, EventArgs e)
        {
            if (btn1.Text.Equals(Lesson.GermanWord(0))) //for the first button, if the first German word is being displayed when it was clicked then:
            {
                btn1.BackColor = Color.MediumSeaGreen; //the colour and text changes 
                btn1.Text = Lesson.EnglishWord(0);
            }
            else //if not, meaning the English word is being displayed instead, then the button will change back to what it was originally, the German version
            {
                btn1.BackColor = Color.DarkCyan;
                btn1.Text = Lesson.GermanWord(0);
            }
        }

        //Same for each button except its the next word in the list
        private void btn2_Click(object sender, EventArgs e)
        {
            if (btn2.Text.Equals(Lesson.GermanWord(1)))
            {
                btn2.BackColor = Color.MediumSeaGreen;
                btn2.Text = Lesson.EnglishWord(1);
            }
            else
            {
                btn2.BackColor = Color.DarkCyan;
                btn2.Text = Lesson.GermanWord(1);
            }
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            if (btn3.Text.Equals(Lesson.GermanWord(2)))
            {
                btn3.BackColor = Color.MediumSeaGreen;
                btn3.Text = Lesson.EnglishWord(2);
            }
            else
            {
                btn3.BackColor = Color.DarkCyan;
                btn3.Text = Lesson.GermanWord(2);
            }
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            if (btn4.Text.Equals(Lesson.GermanWord(3)))
            {
                btn4.BackColor = Color.MediumSeaGreen;
                btn4.Text = Lesson.EnglishWord(3);
            }
            else
            {
                btn4.BackColor = Color.DarkCyan;
                btn4.Text = Lesson.GermanWord(3);
            }
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            if (btn5.Text.Equals(Lesson.GermanWord(4)))
            {
                btn5.BackColor = Color.MediumSeaGreen;
                btn5.Text = Lesson.EnglishWord(4);
            }
            else
            {
                btn5.BackColor = Color.DarkCyan;
                btn5.Text = Lesson.GermanWord(4);
            }
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            if (btn6.Text.Equals(Lesson.GermanWord(5)))
            {
                btn6.BackColor = Color.MediumSeaGreen;
                btn6.Text = Lesson.EnglishWord(5);
            }
            else
            {
                btn6.BackColor = Color.DarkCyan;
                btn6.Text = Lesson.GermanWord(5);
            }
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            if (btn7.Text.Equals(Lesson.GermanWord(6)))
            {
                btn7.BackColor = Color.MediumSeaGreen;
                btn7.Text = Lesson.EnglishWord(6);
            }
            else
            {
                btn7.BackColor = Color.DarkCyan;
                btn7.Text = Lesson.GermanWord(6);
            }
          
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            if (btn8.Text.Equals(Lesson.GermanWord(7)))
            {
                btn8.BackColor = Color.MediumSeaGreen;
                btn8.Text = Lesson.EnglishWord(7);
            }
            else
            {
                btn8.BackColor = Color.DarkCyan;
                btn8.Text = Lesson.GermanWord(7);
            }
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            if (btn9.Text.Equals(Lesson.GermanWord(8)))
            {
                btn9.BackColor = Color.MediumSeaGreen;
                btn9.Text = Lesson.EnglishWord(8);
            }
            else
            {
                btn9.BackColor = Color.DarkCyan;
                btn9.Text = Lesson.GermanWord(8);
            }
        }

        private void btn10_Click(object sender, EventArgs e)
        {
            if (btn10.Text.Equals(Lesson.GermanWord(9)))
            {
                btn10.BackColor = Color.MediumSeaGreen;
                btn10.Text = Lesson.EnglishWord(9);
            }
            else
            {
                btn10.BackColor = Color.DarkCyan;
                btn10.Text = Lesson.GermanWord(9);
            }
        }

        private void btn11_Click(object sender, EventArgs e)
        {
            if (btn11.Text.Equals(Lesson.GermanWord(10)))
            {
                btn11.BackColor = Color.MediumSeaGreen;
                btn11.Text = Lesson.EnglishWord(10);
            }
            else
            {
                btn11.BackColor = Color.DarkCyan;
                btn11.Text = Lesson.GermanWord(10);
            }
        }

        private void btn12_Click(object sender, EventArgs e)
        {
            if (btn12.Text.Equals(Lesson.GermanWord(11)))
            {
                btn12.BackColor = Color.MediumSeaGreen;
                btn12.Text = Lesson.EnglishWord(11);
            }
            else
            {
                btn12.BackColor = Color.DarkCyan;
                btn12.Text = Lesson.GermanWord(11);
            }
        }
    }
}
