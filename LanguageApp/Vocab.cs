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
    public partial class Vocab : Form
    {
        UserManager u = new UserManager();

        public Vocab(UserManager u)
        {
            this.u = u;
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
         
            btn1.Text = Lesson.GermanWord(0);
            btn2.Text = Lesson.GermanWord(1);

            lblUsername.Text = u.GetUsername();
            lblTotalPoints.Text = u.DisplayTotalPoints();
            lblPlace.Text = u.CalculatePlacingForUser(lblUsername.Text);

        }

        private void btn1_Click(object sender, EventArgs e)
        {

            if (btn1.Text.Equals(Lesson.GermanWord(0)))
            {
                btn1.BackColor = Color.MediumSeaGreen;
                btn1.Text = Lesson.EnglishWord(0);
            }
            else
            {
                btn1.BackColor = Color.DarkCyan;
                btn1.Text = Lesson.GermanWord(0);
            }
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            if (btn2.Text.Equals(Lesson.GermanWord(1)))
            {
                btn2.BackColor = Color.MediumSeaGreen;
                btn2.Text = Lesson.EnglishWord(1);
            }
            else
            {
                btn2.BackColor = Color.DarkCyan;
                btn2.Text = Lesson.GermanWord(1);
            }
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

        private void btnMemorise_Click(object sender, EventArgs e)
        {
           
            this.Hide();
            PractiseForm p = new PractiseForm(u, "words");
            p.FormClosed += (s, args) => this.Close();
            p.Show();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
       
            this.Hide();
            Login l = new Login(u);
            l.FormClosed += (s, args) => this.Close();
            l.Show();
        }
    }
}
