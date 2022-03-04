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
    public partial class Info : Form
    {
        public static List<string> sentences;
        public static List<string> answers; 
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
                lblList.Text = "word 1 \nword 2\nword 3";
                sentences = new List<string>() { "sentence 1", "sentence 2", "sentence 3", "sentence 4", "sentence 5" };
                answers = new List<string>() { "answer 1", "answer 2", "answer 3", "answer 4", "answer 5" };
            }  
            else if (MainForm.lesson == 2)
            {
                lblLesson.Text = "2";
                lblList.Text = "word 1 \nword 2\nword 3";
                sentences = new List<string>() { "s1", "s2", "s3", "s4", "s5" };
                answers = new List<string>() { "a1", "a2", "a3", "a", "a5" };
            }
            else
            {
                lblLesson.Text = "Beginner";
                lblList.Text = "word 1 \nword 2\nword 3";
            }
           

        }

        private void btnVocab_Click(object sender, EventArgs e)
        {
            this.Hide();
            Vocab v = new Vocab();
            v.FormClosed += (s, args) => this.Close();
            v.Show();
        }
    }
}
