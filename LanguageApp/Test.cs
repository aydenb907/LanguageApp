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
    public partial class Test : Form
    {
        private List<string> testAns;
        User u = new User();

        public Test()
        {
            InitializeComponent();
        }

        private void Test_Load(object sender, EventArgs e)
        {
            Random rand = new Random();
            List<int> randomIndexes = new List<int>();
            List<int> indexes = new List<int>() { 0, 1, 2, 3, 4 };

            for (int j = 0; j < 5; j++)
            {
                int random = rand.Next(0, indexes.Count - 1);
                randomIndexes.Add(indexes[random]);
                indexes.Remove(indexes[random]);
            }

            List<string> testQues = Lesson.GenTestQuestions(randomIndexes, MainForm.lesson);
            testAns = Lesson.GenTestAnswers(randomIndexes);

            label1.Text = testQues[0];
            label2.Text = testQues[1];
            label3.Text = testQues[2];
            label4.Text = testQues[3];
            label5.Text = testQues[4];
            label6.Text = testQues[5];
            label7.Text = testQues[6];
            label8.Text = testQues[7];
            label9.Text = testQues[8];
            label10.Text = testQues[9];
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            List<string> userAnswers = new List<string>();
            userAnswers.Add(textBox1.Text);
            userAnswers.Add(textBox2.Text);
            userAnswers.Add(textBox3.Text);
            userAnswers.Add(textBox4.Text);
            userAnswers.Add(textBox5.Text);
            userAnswers.Add(textBox6.Text);
            userAnswers.Add(textBox7.Text);
            userAnswers.Add(textBox8.Text);
            userAnswers.Add(textBox9.Text);
            userAnswers.Add(textBox10.Text);
            
            int score = 0;
            string summary = "";

            for (int j = 0; j < 5; j++)
            {
                //Marks test questions and adds score
                if (Lesson.MarkTestQues(j, userAnswers[j], testAns))
                {
                    summary += $"{j + 1}. Correct";
                    score++;
                }
                else
                {
                    summary += $"{j + 1}. Incorrect. The correct answer is {testAns[j]}.\n";
                }
            }

            
            u.UpdateScores(score, MainForm.lesson);

            summary += $"Score: {score}/5\n" +
                $"Average Score: {u.CalculateAvgScore(MainForm.lesson)}\n" +
                $"Number of attempts: {u.NumberOfAttempts(MainForm.lesson)}";


            MessageBox.Show(summary);

            this.Hide();
            Info i = new Info();
            i.FormClosed += (s, args) => this.Close();
            i.Show();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm m = new MainForm();
            m.FormClosed += (s, args) => this.Close();
            m.Show();
        }

        private void btnLesson_Click(object sender, EventArgs e)
        {
            this.Hide();
            Info i = new Info();
            i.FormClosed += (s, args) => this.Close();
            i.Show();
        }
    }
}
