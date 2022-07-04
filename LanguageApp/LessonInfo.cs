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
    public partial class LessonInfo : Form
    {
        UserManager u = new UserManager();
      
       
        public LessonInfo(UserManager u)
        {
            this.u = u;
            InitializeComponent();
            
        }

        //return to mainform
        private void btnHome_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm m = new MainForm(u);
            m.FormClosed += (s, args) => this.Close();
            m.Show();
        }

        private void lblLesson_Click(object sender, EventArgs e)
        {
           
        }


        private void Info_Load(object sender, EventArgs e)
        {
            //Displays username, total points, vocabulary lists and lesson text when form loads
            lblUsername.Text = u.GetUsername();
            lblTotalPoints.Text = u.DisplayTotalPoints();

            lblEnglisch.Text = Lesson.EnglishWordsList();
          
            lblDeutsch.Text = Lesson.GermanWordsList();

            lblLesson.Text = Lesson.GetLessonText(MainForm.lesson);

            lblScore.Text += $"{u.GetAvgScore(MainForm.lesson)}%";

            lblPlace.Text = u.CalculatePlacingForUser(lblUsername.Text);

        }

        private void btnVocab_Click(object sender, EventArgs e)
        {
     
            this.Hide();
            Vocab v = new Vocab(u);
            v.FormClosed += (s, args) => this.Close();
            v.Show();
        }

        private void btnPractise_Click(object sender, EventArgs e)
        {
           
            this.Hide();
            PractiseForm p = new PractiseForm(u, "practice");
            p.FormClosed += (s, args) => this.Close();
            p.Show();

        }
        private void btnGrammarTest_Click(object sender, EventArgs e)
        {
            this.Hide();
            Test t = new Test(u);
            t.FormClosed += (s, args) => this.Close();
            t.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
      
            this.Hide();
            Login l = new Login(u);
            l.FormClosed += (s, args) => this.Close();
            l.Show();
        }
    }
}
