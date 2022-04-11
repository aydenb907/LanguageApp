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
        private static List<string> practiceAns;
      
        
        public PractiseForm()
        {
            InitializeComponent();
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

        private void PractiseForm_Load(object sender, EventArgs e)
        {
            

            lblEnglisch.Text = Lesson.GetEnglishWords(MainForm.lesson);
            lblDeutsch.Text = Lesson.GetGermanWords(MainForm.lesson);

            Random rand = new Random();
            List<int> randomIndexes = new List<int>();
            List<int> indexes = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            for (int i = 0; i < indexes.Count; i++)
            {
                int random = rand.Next(0, indexes.Count - 1);
                randomIndexes.Add(indexes[random]);
                indexes.Remove(indexes[random]);
            }

            List<string> practiceQues = Lesson.GenPracQuestions(randomIndexes, MainForm.lesson);
            practiceAns = Lesson.GenPracAns(randomIndexes);

            label1.Text = practiceQues[0];
            label2.Text = practiceQues[1];
            label3.Text = practiceQues[2];
            label4.Text = practiceQues[3];
            label5.Text = practiceQues[4];


        }

        private void btnCheck1_Click(object sender, EventArgs e)
        {
            string userAnswer = txtAnswer1.Text;
            if (Lesson.MarkPracQuestions(0, userAnswer, practiceAns))
            {

                MessageBox.Show("Correct");
            }
            else
            {
                MessageBox.Show($"Incorrect. The correct answer is {practiceAns[0]}.\n");
            }

        }
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
        private void btnMoreQuestions_Click(object sender, EventArgs e)
        {
            this.Hide();
            PractiseForm p = new PractiseForm();
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
