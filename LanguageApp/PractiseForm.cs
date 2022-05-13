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
    public partial class PractiseForm : Form
    {
        UserManager u = new UserManager();
        private static List<string> practiceAns;
        private static List<int> indexes = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };


        public PractiseForm(UserManager u)
        {
            this.u = u;
            InitializeComponent();
        }

        //Go to main form
        private void btnHome_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm m = new MainForm(u);
            m.FormClosed += (s, args) => this.Close();
            m.Show();
        }

        //Go to lesson form to read lesson again
        private void btnLesson_Click(object sender, EventArgs e)
        {
            this.Hide();
            Info i = new Info(u);
            i.FormClosed += (s, args) => this.Close();
            i.Show();
        }

        
        private void PractiseForm_Load(object sender, EventArgs e)
        {
            lblUsername.Text = u.GetUsername();
            lblTotalScore.Text = u.CalcTotalScore();

            Random rand = new Random();
            List<int> randomIndexes = new List<int>();
            

            List<string> practiceQues = new List<string>();

            if(indexes.Count == 0)
            {
                if(Info.lessonType == 1)
                {
                    MessageBox.Show("No more new practice questions.");
                }
                else
                {
                    MessageBox.Show("No more new vocabulary words.");
                }

                indexes = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            }
            //Randomly assorts indexes in list 
            for (int i = 0; i < 5; i++)
            {
                int random = rand.Next(0, indexes.Count - 1);
                randomIndexes.Add(indexes[random]);
                indexes.Remove(indexes[random]);
            }
        
            //random indexes used to put questions in random order, based on what kind of lesson it is (what number, whether it's completing sentences or a vocab lesson)
            practiceQues = Lesson.GenPracQuestions(randomIndexes, MainForm.lesson, Info.lessonType);
            //random indexes used to put correct answers in the same random order
            practiceAns = Lesson.GenPracAns(randomIndexes, Info.lessonType);

            //displays the first 5 of the random questions
            label1.Text = practiceQues[0];
            label2.Text = practiceQues[1];
            label3.Text = practiceQues[2];
            label4.Text = practiceQues[3];
            label5.Text = practiceQues[4];


            //vocabulary lists are displayed if the lesson is practising questions, if it's a vocabulary lesson then the labels will be blank
            if (Info.lessonType == 1)
            {
                lblEnglisch.Text = Lesson.GetEnglishWords(MainForm.lesson);
                lblDeutsch.Text = Lesson.GetGermanWords();
            }
            else
            {
                lblEnglisch.Text = "";
                lblDeutsch.Text = "";

            }
        }

        //Checks user's answer for first random question. Answers are checked individually. If the user is wrong then they can always correct what they typed in the textbox and click the check answer buttons again.
        private void btnCheck1_Click(object sender, EventArgs e)
        {
            string userAnswer = txtAnswer1.Text;

         //if the user's answer is the same as the correct answer, then a message box will show saying correct. If the user is wrong, the message box will say incorrect and will display what the correct answer instead.
            if (Lesson.MarkPracQuestions(0, userAnswer, practiceAns))
            {

                MessageBox.Show("Correct");
            }
            else
            {
                MessageBox.Show($"Incorrect. The correct answer is {practiceAns[0]}.\n");
            }
           

          

        }

        //Checks answer for 2nd question
        private void btnCheck2_Click(object sender, EventArgs e)
        {
            string userAnswer = txtAnswer2.Text;
            if (Lesson.MarkPracQuestions(1, userAnswer, practiceAns))
            {

                MessageBox.Show("Correct");
            }
            else
            {
                MessageBox.Show($"Incorrect. The correct answer is {practiceAns[1]}.\n");
            }

        }

        //Checks answer for 3rd question
        private void btnCheck3_Click(object sender, EventArgs e)
        {
            string userAnswer = txtAnswer3.Text;
            if (Lesson.MarkPracQuestions(2, userAnswer, practiceAns))
            {

                MessageBox.Show("Correct");
            }
            else
            {
                MessageBox.Show($"Incorrect. The correct answer is {practiceAns[2]}.\n");
            }

        }

        //Checks answer for 4th question
        private void btnCheck4_Click(object sender, EventArgs e)
        {
            string userAnswer = txtAnswer4.Text;
            if (Lesson.MarkPracQuestions(3, userAnswer, practiceAns))
            {

                MessageBox.Show("Correct");
            }
            else
            {
                MessageBox.Show($"Incorrect. The correct answer is {practiceAns[3]}.\n");
            }

        }

        //Checks answer for 5th question
        private void btnCheck5_Click(object sender, EventArgs e)
        {
            string userAnswer = txtAnswer5.Text;
            if (Lesson.MarkPracQuestions(4, userAnswer, practiceAns))
            {

                MessageBox.Show("Correct");
            }
            else
            {
                MessageBox.Show($"Incorrect. The correct answer is {practiceAns[4]}.\n");
            }
        }
        
        //Loads more random questions, by loading the practice form again. Same questions may appear again.
        private void btnMoreQuestions_Click(object sender, EventArgs e)
        {
            this.Hide();
            PractiseForm p = new PractiseForm(u);
            p.FormClosed += (s, args) => this.Close();
            p.Show();

        }
        private void txtAnswer1_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblEnglisch_Click(object sender, EventArgs e)
        {

        }

        private void lblDeutsch_Click(object sender, EventArgs e)
        {

        }

        
    }
}
