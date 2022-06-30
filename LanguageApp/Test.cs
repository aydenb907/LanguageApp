﻿using System;
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
    public partial class Test : Form
    {
        private List<string> testAns;
        SqlConnection connection;
        string connectionString;

        private static List<int> indexes = new List<int>();

        UserManager u = new UserManager();
        public Test(UserManager u)
        {
            this.u = u;
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["LanguageApp.Properties.Settings.Database1ConnectionString"].ConnectionString;
        }

        private void Test_Load(object sender, EventArgs e)
        {
            lblUsername.Text = u.GetUsername();
       

            Random rand = new Random();
            List<int> randomIndexes = new List<int>();

            if (indexes.Count < 10)
            {

                indexes = new List<int>();
                for (int n = 0; n < Lesson.QuestionsNumber("test"); n++)
                {
                    indexes.Add(n);
                }

            }

            for (int j = 0; j < 10; j++)
            {
                int random = rand.Next(0, indexes.Count - 1);
                randomIndexes.Add(indexes[random]);
                indexes.Remove(indexes[random]);
            }

            List<string> testQues = Lesson.GenQuestions(randomIndexes, "test");
            testAns = Lesson.GenAnswers(randomIndexes, "test");

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

            for (int j = 0; j < 10; j++)
            {
                //Marks test questions and adds score
                if (Lesson.MarkQuestions(j, userAnswers[j], testAns))
                {
                    summary += $"{j + 1}. Correct. \n";
                    score++;
                }
                else
                {
                    summary += $"{j + 1}. Incorrect. The correct answer is {testAns[j]}.\n";
                }
            }

            

            string query = "INSERT INTO TestTable VALUES (@LessonID, @UserID, @score)";
            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();

                command.Parameters.AddWithValue("@LessonID", MainForm.lesson);
                command.Parameters.AddWithValue("@UserID", u.GetId());
                command.Parameters.AddWithValue("@score", score);

                command.ExecuteScalar();

            }

            summary += $"\nScore: {score} \nAverage Score: {u.GetAvgScore(MainForm.lesson)}%";

            MessageBox.Show(summary);

            this.Hide();
            LessonInfo i = new LessonInfo(u);
            i.FormClosed += (s, args) => this.Close();
            i.Show();
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

        private void btnLogOut_Click(object sender, EventArgs e)
        {
     
            this.Hide();
            Login l = new Login(u);
            l.FormClosed += (s, args) => this.Close();
            l.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
