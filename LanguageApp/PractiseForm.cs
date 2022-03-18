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
        private string answer1, answer2, answer3, answer4, answer5;
        
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

        private void btnGrammarTest_Click(object sender, EventArgs e)
        {
            this.Hide();
            PractiseForm p = new PractiseForm();
            p.FormClosed += (s, args) => this.Close();
            p.Show();
        }

        private void btnVocabTest_Click(object sender, EventArgs e)
        {

        }

        private void PractiseForm_Load(object sender, EventArgs e)
        {
            lblEnglisch.Text = "";
            lblDeutsch.Text = "";
            foreach(string word in Info.englishWords)
            {
               
                lblEnglisch.Text += $"\n{word}";
            }
            foreach (string word in Info.germanWords)
            {
                lblDeutsch.Text += $"\n{word}";
            }

            List<string> sentences = Info.sentences;
            List<string> answers = Info.answers;

            Random rand = new Random();
            int random = rand.Next(0, sentences.Count-1);
            label1.Text = sentences[random];
            sentences.Remove(sentences[random]);
            answer1 = answers[random];
            answers.Remove(answers[random]);

          
            random = rand.Next(0, sentences.Count-1);
            label2.Text = sentences[random];
            sentences.Remove(sentences[random]);
            answer2 = answers[random];
            answers.Remove(answers[random]);

            random = rand.Next(0, sentences.Count-1);
            label3.Text = sentences[random];
            sentences.Remove(sentences[random]);
            answer3 = answers[random];
            answers.Remove(answers[random]);

         
            random = rand.Next(0, sentences.Count-1);
            label4.Text = sentences[random];
            sentences.Remove(sentences[random]);
            answer4 = answers[random];
            answers.Remove(answers[random]);

            random = rand.Next(0, sentences.Count-1);
            label5.Text = sentences[random];
            sentences.Remove(sentences[random]);
            answer5 = answers[random];
            answers.Remove(answers[random]);

        }

        private void btnCheck1_Click(object sender, EventArgs e)
        {
            string userAnswer = txtAnswer1.Text;
           if (userAnswer == answer1)
            {
                MessageBox.Show("Correct!");
            }
           else
            {
                MessageBox.Show($"Incorrect\n\nCorrect Answer:\n{answer1}");
            }

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

        private void btnMoreQuestions_Click(object sender, EventArgs e)
        {
            if (Info.sentences.Count == 0)
            {
                MessageBox.Show("No more new example questions.");
                this.Hide();
                Info i = new Info();
                i.FormClosed += (s, args) => this.Close();
                i.Show();
            }
            else
            {
                this.Hide();
                PractiseForm p = new PractiseForm();
                p.FormClosed += (s, args) => this.Close();
                p.Show();
            }
  

        }

        private void btnCheck2_Click(object sender, EventArgs e)
        {
            string userAnswer = txtAnswer2.Text;
            if (userAnswer == answer2)
            {
                MessageBox.Show("Correct!");
            }
            else
            {
                MessageBox.Show($"Incorrect\n\nCorrect Answer:\n{answer2}");
            }
        }

        private void btnCheck3_Click(object sender, EventArgs e)
        {
            string userAnswer = txtAnswer3.Text;
            if (userAnswer == answer3)
            {
                MessageBox.Show("Correct!");
            }
            else
            {
                MessageBox.Show($"Incorrect\n\nCorrect Answer:\n{answer3}");
            }
        }

        private void btnCheck4_Click(object sender, EventArgs e)
        {
            string userAnswer = txtAnswer4.Text;
            if (userAnswer == answer4)
            {
                MessageBox.Show("Correct!");
            }
            else
            {
                MessageBox.Show($"Incorrect\n\nCorrect Answer:\n{answer4}");
            }
        }

        private void btnCheck5_Click(object sender, EventArgs e)
        {
            string userAnswer = txtAnswer5.Text;
            if (userAnswer == answer5)
            {
                MessageBox.Show("Correct!");
            }
            else
            {
                MessageBox.Show($"Incorrect\n\nCorrect Answer:\n{answer5}");
            }
        }
    }
}
