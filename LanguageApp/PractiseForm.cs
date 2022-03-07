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
        private int random, random2, random3, random4, random5;
        
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

            Random rand = new Random();        
            random = rand.Next(0,sentences.Count-1);
            label1.Text = sentences[random];  
            sentences.Remove(sentences[random]);

            Random rand2 = new Random();
            random2 = rand2.Next(0, sentences.Count-1);   
            label2.Text = sentences[random2];
            sentences.Remove(sentences[random2]);

            Random rand3 = new Random();
            random3 = rand3.Next(0, sentences.Count-1);
            label3.Text = sentences[random3];
            sentences.Remove(sentences[random3]);

            Random rand4 = new Random();
            random4 = rand4.Next(0, sentences.Count-1);
            label4.Text = sentences[random4];
            sentences.Remove(sentences[random4]);

            Random rand5 = new Random();
            random5 = rand5.Next(0, sentences.Count-1);
            label5.Text = sentences[random5];
            sentences.Remove(sentences[random5]);

        }

        private void btnCheck1_Click(object sender, EventArgs e)
        {
            string userAnswer = txtAnswer1.Text;
           if (userAnswer == Info.answers[random])
            {
                MessageBox.Show("Correct!");
            }
           else
            {
                MessageBox.Show($"Incorrect\n\nCorrect Answer:\n{Info.answers[random]}");
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
            if (userAnswer == Info.answers[random2])
            {
                MessageBox.Show("Correct!");
            }
            else
            {
                MessageBox.Show($"Incorrect\n\nCorrect Answer:\n{Info.answers[random2]}");
            }
        }

        private void btnCheck3_Click(object sender, EventArgs e)
        {
            string userAnswer = txtAnswer3.Text;
            if (userAnswer == Info.answers[random3])
            {
                MessageBox.Show("Correct!");
            }
            else
            {
                MessageBox.Show($"Incorrect\n\nCorrect Answer:\n{Info.answers[random3]}");
            }
        }

        private void btnCheck4_Click(object sender, EventArgs e)
        {
            string userAnswer = txtAnswer4.Text;
            if (userAnswer == Info.answers[random4])
            {
                MessageBox.Show("Correct!");
            }
            else
            {
                MessageBox.Show($"Incorrect\n\nCorrect Answer:\n{Info.answers[random4]}");
            }
        }

        private void btnCheck5_Click(object sender, EventArgs e)
        {
            string userAnswer = txtAnswer5.Text;
            if (userAnswer == Info.answers[random5])
            {
                MessageBox.Show("Correct!");
            }
            else
            {
                MessageBox.Show($"Incorrect\n\nCorrect Answer:\n{Info.answers[random5]}");
            }
        }
    }
}
