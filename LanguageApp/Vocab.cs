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
    public partial class Vocab : Form
    {
        UserManager u = new UserManager();
        public Vocab(UserManager u )
        {
            this.u = u;
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lblUsername.Text = u.GetUsername();
            lblTotalScore.Text = u.CalcTotalPoints();

            btn1.Text = Lesson.GetGermanWord(0);
            btn2.Text = Lesson.GetGermanWord(1);
        }

        private void btn1_Click(object sender, EventArgs e)
        {

            if (btn1.Text.Equals(Lesson.GetGermanWord(0)))
            {
                btn1.BackColor = Color.MediumSeaGreen;
                btn1.Text = Lesson.GetEnglishWord(0);
            }
            else
            {
                btn1.BackColor = Color.DarkCyan;
                btn1.Text = Lesson.GetGermanWord(0);
            }
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            if (btn2.Text.Equals(Lesson.GetGermanWord(1)))
            {
                btn2.BackColor = Color.MediumSeaGreen;
                btn2.Text = Lesson.GetEnglishWord(1);
            }
            else
            {
                btn2.BackColor = Color.DarkCyan;
                btn2.Text = Lesson.GetGermanWord(1);
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
            PractiseForm p = new PractiseForm(u);
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
