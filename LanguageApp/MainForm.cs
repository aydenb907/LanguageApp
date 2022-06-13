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
    public partial class MainForm : Form
    {
        UserManager u = new UserManager();
        public static int lesson;
     
        public MainForm(UserManager u)
        {
            
            this.u = u;
            InitializeComponent();
           
        }

        //Lesson buttons
        //Same process for each lesson button
        private void btnBeginner_Click(object sender, EventArgs e)
        {
            lesson = 0;
       
       

            //closes mainform and goes onto the lesson's form
            this.Hide();
            LessonInfo i = new LessonInfo(u);
            i.FormClosed += (s, args) => this.Close();
            i.Show();
        }
        //Same for every lesson button
        private void btn1_Click(object sender, EventArgs e)
        {
            lesson = 1; // integer will be used to display the right text for the lesson
           
            
            //Goes to lesson form
            this.Hide();
            LessonInfo i = new LessonInfo(u);
            i.FormClosed += (s, args) => this.Close();
            i.Show();
        }
        private void btn2_Click(object sender, EventArgs e)
        {
            lesson = 2;
          
            this.Hide();
           
            LessonInfo i = new LessonInfo(u);
            i.FormClosed += (s, args) => this.Close();
            i.Show();
        }

        
        private void MainForm_Load(object sender, EventArgs e)
        {
            //Checks which lessons have been done to change the colour of their buttons
            List<int> lessons = u.GetLessons();

            foreach (int l in lessons)
            {
                if (l==1)
                {
                    btn1.BackColor = Color.LightGreen;
                }
                else if (l==2)
                {
                    btn2.BackColor = Color.LightGreen;
                }
                else
                {
                    btnBeginner.BackColor = Color.LightGreen;
                }
            }

        private void menuInfo_Click(object sender, EventArgs e)
        {
            MessageBox.Show("");
        }

        //menu strip

        //Goes to login form
        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            this.Hide();
            Login l = new Login(u);
            l.FormClosed += (s, args) => this.Close();
            l.Show();
        }
        
        //Displays message box when clicked
        private void menuInfo_Click(object sender, EventArgs e)
        {
            MessageBox.Show("");
        }
    }
}
