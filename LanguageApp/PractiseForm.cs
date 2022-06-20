using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        private List<string> practiceAns;
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
            LessonInfo i = new LessonInfo(u);
            i.FormClosed += (s, args) => this.Close();
            i.Show();
        }

        
        private void PractiseForm_Load(object sender, EventArgs e)
        {
            string list = "";

            foreach (string englishWord in Lesson.GetEnglishWords(MainForm.lesson))
            {
                list += englishWord + "\n";
            }

            lblEnglisch.Text = list;
            list = "";

            foreach (string germanWord in Lesson.GetGermanWords(MainForm.lesson))
            {
                list += germanWord + "\n";
            }

            lblDeutsch.Text = list;


            lblUsername.Text = u.GetUsername();
            lblTotalPoints.Text = u.DisplayTotalPoints();
            lblPlace.Text = u.CompareTotalScores(lblUsername.Text);

            Random rand = new Random();
            List<int> randomIndexes = new List<int>();

            if (indexes.Count == 0)
            {

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
            List<string> practiceQues = Lesson.GenQuestions(randomIndexes, MainForm.lesson, LessonInfo.lessonType);
            practiceAns = Lesson.GenAnswers(randomIndexes, MainForm.lesson, LessonInfo.lessonType);

            //displays the first 5 of the random questions
            label1.Text = practiceQues[0];
            label2.Text = practiceQues[1];
            label3.Text = practiceQues[2];
            label4.Text = practiceQues[3];
            label5.Text = practiceQues[4];

        }

        //Checks user's answer for first random question. Answers are checked individually. If the user is wrong then they can always correct what they typed in the textbox and click the check answer buttons again.
        private void btnCheck1_Click(object sender, EventArgs e)
        {
            string userAnswer = txtAnswer1.Text;

         //if the user's answer is the same as the correct answer, then a message box will show saying correct. If the user is wrong, the message box will say incorrect and will display what the correct answer instead.
            if (Lesson.MarkQuestions(0, userAnswer, practiceAns))
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
            if (Lesson.MarkQuestions(1, userAnswer, practiceAns))
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
            if (Lesson.MarkQuestions(2, userAnswer, practiceAns))
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
            if (Lesson.MarkQuestions(3, userAnswer, practiceAns))
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
            if (Lesson.MarkQuestions(4, userAnswer, practiceAns))
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
      

        private void lblEnglisch_Click(object sender, EventArgs e)
        {

        }

        private void lblDeutsch_Click(object sender, EventArgs e)
        {

        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login l = new Login(u);
            l.FormClosed += (s, args) => this.Close();
            l.Show();
        }

        private void txtAnswer1_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}
