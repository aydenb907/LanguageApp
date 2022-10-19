using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data.SqlClient;
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
        private static List<int> indexes = new List<int>();
        private string type;

        public PractiseForm(UserManager u, string lessonType)
        {
            this.u = u;
            type = lessonType;
            InitializeComponent();
           
    }

        //Goes to mainform
        private void btnHome_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm m = new MainForm(u);
            m.FormClosed += (s, args) => this.Close();
            m.Show();
        }

        //Goes to lesson form to read lesson again
        private void btnLesson_Click(object sender, EventArgs e)
        {
            this.Hide();
            LessonInfo i = new LessonInfo(u);
            i.FormClosed += (s, args) => this.Close();
            i.Show();
        }

        //When the form loads, questions are selected and displayed based on which form they've come from
        //Sentences if they came from LessonInfo
        //English words if they've come from Vocab form
        private void PractiseForm_Load(object sender, EventArgs e)
        {
       
           //displays vocabulary list if it's just practice questions, and not a vocab lesson
            if (type.Equals("practice"))
            {
                lblEnglisch.Text = Lesson.EnglishWordsList();

                lblDeutsch.Text = Lesson.GermanWordsList();
            }
            else //makes sure vocabulary list isn't shown when English words are the questions, or else the user can cheat when trying to memorise unfamiliar words
            {
                label6.Text = "";
                label7.Text = "";
                lblEnglisch.Text = "";
                lblDeutsch.Text = "";
            }

            //displays user's details, same as every other form apart from login
            lblUsername.Text = u.GetUsername();
            lblTotalPoints.Text = u.DisplayTotalPoints();
            lblPlace.Text = u.CalculatePlacingForUser(lblUsername.Text);

            
            Random rand = new Random();
            List<int> randomIndexes = new List<int>();
  
            //Rather than having to make sure the number of questions stored in the database is a factor of 5, so that the program doesn't break when the form loads, when the number of questions that have not been used yet
            //in one cycle is less than 5, then the indexes list will be emptied and be populated again with all the indexes possible for the lesson. 
            if (indexes.Count <5)
            {
                indexes = new List<int>();  //Indexes list is made new again rather than keep the question indexes that are not used yet, otherwise they could be displaced twice on the form when it loads again
                //Questions are shown in random order so the ones that have not been used for one cycle will not always be the ones that aren't used. 

                //Each index is added no matter how many questions there are
                for (int n = 0; n < Lesson.QuestionsNumber(type)+1; n++) // +1 so that last question is added as well
                {
                   
                   indexes.Add(n);
                      
                }
                    

            }
            //Randomly picks 5 indexes and adds them to another list, randomIndexes
            //randomIndexes will be used to get the 5 random questions from Lesson class
            for (int i = 0; i < 5; i++)
            {
                int random = rand.Next(0, indexes.Count - 1);
                randomIndexes.Add(indexes[random]);
                indexes.Remove(indexes[random]); //after random index is picked it is removed from indexes so that it is not used again. Otherwise a question could be displayed multiple times when the form is loaded
            }

            //gets the practice questions needed, and their respective answers, for this load
            List<string> practiceQues = Lesson.GenQuestions(randomIndexes, type);
            practiceAns = Lesson.GenAnswers(randomIndexes, type); //randomIndexes used for practiceAns as well to get answers in the same order as the questions, otherwise the marking will be inaccurate
            //type is needed to get the questions from the right lesson - either vocabulary words of practice questions

            //displays the 5 randomly selected questions in the order they were picked
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

         //if the user's answer is the same as the correct answer, then a message box will show saying correct. If the user is wrong, the message box will say incorrect and will display what the correct answer is.
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
        
        //Loads more random questions, by loading the practice form again. Questions wwon't repeat until there are less than 5 indexes left in the indexes list
        private void btnMoreQuestions_Click(object sender, EventArgs e)
        {
            this.Hide();
            PractiseForm p = new PractiseForm(u, type);
            p.FormClosed += (s, args) => this.Close();
            p.Show();

        }
      

        private void lblEnglisch_Click(object sender, EventArgs e)
        {

        }

        private void lblDeutsch_Click(object sender, EventArgs e)
        {

        }
    //Goes to login form
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
