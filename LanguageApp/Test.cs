﻿using System;
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
        private List<string> correctAnswers = new List<string>();
        private static List<int> totalScores = new List<int>() {0, 0, 0, 0, 0, 0 };
        public static List<int> attempts = new List<int>() { 0, 0, 0, 0, 0, 0 };
        public static List<float> avgScores = new List<float>() { 0, 0, 0, 0, 0, 0 };

        public Test()
        {
            InitializeComponent();
        }

        private void Test_Load(object sender, EventArgs e)
        {
            List<string> testQuestions = Info.testQuestions;
            List<string> testAnswers = Info.testAnswers;
        

            Random rand = new Random();
            int random = rand.Next(0, testQuestions.Count - 1);
            label1.Text = testQuestions[random];
            testQuestions.Remove(testQuestions[random]);
            correctAnswers.Add(testAnswers[random]);
            testAnswers.Remove(testAnswers[random]);

            random = rand.Next(0, testQuestions.Count - 1);
            label2.Text = testQuestions[random];
            testQuestions.Remove(testQuestions[random]);
            correctAnswers.Add(testAnswers[random]);
            testAnswers.Remove(testAnswers[random]);

            random = rand.Next(0, testQuestions.Count - 1);
            label3.Text = testQuestions[random];
            testQuestions.Remove(testQuestions[random]);
            correctAnswers.Add(testAnswers[random]);
            testAnswers.Remove(testAnswers[random]);

            random = rand.Next(0, testQuestions.Count - 1);
            label4.Text = testQuestions[random];
            testQuestions.Remove(testQuestions[random]);
            correctAnswers.Add(testAnswers[random]);
            testAnswers.Remove(testAnswers[random]);

            random = rand.Next(0, testQuestions.Count - 1);
            label5.Text = testQuestions[random];
            testQuestions.Remove(testQuestions[random]);
            correctAnswers.Add(testAnswers[random]);
            testAnswers.Remove(testAnswers[random]);

            random = rand.Next(0, testQuestions.Count - 1);
            label6.Text = testQuestions[random];
            testQuestions.Remove(testQuestions[random]);
            correctAnswers.Add(testAnswers[random]);
            testAnswers.Remove(testAnswers[random]);

            random = rand.Next(0, testQuestions.Count - 1);
            label7.Text = testQuestions[random];
            testQuestions.Remove(testQuestions[random]);
            correctAnswers.Add(testAnswers[random]);
            testAnswers.Remove(testAnswers[random]);

            random = rand.Next(0, testQuestions.Count - 1);
            label8.Text = testQuestions[random];
            testQuestions.Remove(testQuestions[random]);
            correctAnswers.Add(testAnswers[random]);
            testAnswers.Remove(testAnswers[random]);

            random = rand.Next(0, testQuestions.Count - 1);
            label9.Text = testQuestions[random];
            testQuestions.Remove(testQuestions[random]);
            correctAnswers.Add(testAnswers[random]);
            testAnswers.Remove(testAnswers[random]);

            random = rand.Next(0, testQuestions.Count - 1);
            label10.Text = testQuestions[random];
            testQuestions.Remove(testQuestions[random]);
            correctAnswers.Add(testAnswers[random]);
            testAnswers.Remove(testAnswers[random]);

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {

            List<string> userAnswers = new List<string>();

            userAnswers.Add(textBox1.Text.ToLower());
            userAnswers.Add(textBox2.Text.ToLower());
            userAnswers.Add(textBox3.Text.ToLower());
            userAnswers.Add(textBox4.Text.ToLower());
            userAnswers.Add(textBox5.Text.ToLower());
            userAnswers.Add(textBox6.Text.ToLower());
            userAnswers.Add(textBox7.Text.ToLower());
            userAnswers.Add(textBox8.Text.ToLower());
            userAnswers.Add(textBox9.Text.ToLower());
            userAnswers.Add(textBox10.Text.ToLower());

            int score = 0;
            for(int a = 0; a < userAnswers.Count; a++)
            {
                if(userAnswers[a].Equals(correctAnswers[a]))
                {
                    score += 1;
                }
            }

            int n = MainForm.lesson;
            totalScores[n] += score;
            attempts[n]++;

            avgScores[n] = totalScores[n] / attempts[n];

            MessageBox.Show($"Score: {score} \nAverage Score: {avgScores[n]}");

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
