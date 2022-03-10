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
    public partial class Info : Form
    {
        public static List<string> sentences;
        public static List<string> answers;
        public static List<string> englishWords;
        public static List<string> germanWords;
        public static List<string> testQuestions;
        public static List<string> testAnswers;

        public Info()
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

        private void btnPractise_Click(object sender, EventArgs e)
        {
           
            this.Hide();
            PractiseForm p = new PractiseForm();
            p.FormClosed += (s, args) => this.Close();
            p.Show();
            
        }

        private void lblLesson_Click(object sender, EventArgs e)
        {
           
        }

        private void Info_Load(object sender, EventArgs e)
        {
            if (MainForm.lesson == 1)
            {
                lblLesson.Text = "1";
                englishWords = new List<string>() {"word 1", "word 2", "word 3", "word 4", "word5", "word 6", "word 7", "word 8", "word 9", "word 10" };
                germanWords = new List<string>() { "german 1", "german 2", "german 3", "german 4", "german 5", "german 6", "german 7", "german 8", "german 9", "german 10" };
                sentences = new List<string>() { "sentence 1", "sentence 2", "sentence 3", "sentence 4", "sentence 5", "sentence 6", "sentence 7", "sentence 8", "sentence 9", "sentence 10"};
                answers = new List<string>() { "answer 1", "answer 2", "answer 3", "answer 4", "answer 5", "answer 6", "answer 7", "answer 8", "answer 9", "answer 10" };
                testQuestions = new List<string>() {"q1", "q2", "q3", "q4", "q5", "q6", "q7", "q8", "q9", "q10" };
                testAnswers = new List<string>() { "answer 1", "answer 2", "answer 3", "answer 4", "answer 5", "answer 6", "answer 7", "answer 8", "answer 9", "answer 10" };

            }  
            else if (MainForm.lesson == 2)
            {
                lblLesson.Text = "2";
                englishWords = new List<string>() { "w1", "w2", "w3" };
                germanWords = new List<string>() { "g1", "g2", "g3" };
                sentences = new List<string>() { "s1", "s2", "s3", "s4", "s5", "s6", "s7", "s8" };
                answers = new List<string>() { "a1", "a2", "a3", "a4", "a5", "a6", "a7", "a8" };
            }
            else
            {
                lblLesson.Text = "Beginner";
              
            }

            foreach (string word in englishWords)
            {

                lblEnglisch.Text += $"\n{word}";
            }
            foreach (string word in germanWords)
            {
                lblDeutsch.Text += $"\n{word}";
            }

        }

        private void btnVocab_Click(object sender, EventArgs e)
        {
            this.Hide();
            Vocab v = new Vocab();
            v.FormClosed += (s, args) => this.Close();
            v.Show();
        }

        private void lblList_Click(object sender, EventArgs e)
        {

        }

        private void btnGrammarTest_Click(object sender, EventArgs e)
        {
            this.Hide();
            Test t = new Test();
            t.FormClosed += (s, args) => this.Close();
            t.Show();
        }
    }
}
