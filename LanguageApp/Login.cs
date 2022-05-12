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
    public partial class Login : Form
    {
        UserManager u = new UserManager();
        public Login(UserManager u)
        {
            this.u = u;
            InitializeComponent();
           
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            string username = txtUserName.Text;

            foreach (string name in u.GetUsernames())
            {
                if (username == name)
                {
                    MessageBox.Show("Username already taken.");
                    return;
                }
            }


            string password = txtPassword.Text;

            foreach (string word in u.GetPasswords())
            {
                if (password == word)
                {
                    MessageBox.Show("Password already taken.");
                    return;
                }
            }
            List<int> totalScores = new List<int>() {0,0,0 };
            List<int> attempts = new List<int>() {0,0,0 };

            MessageBox.Show(u.AddUser(username, password, totalScores, attempts));

            this.Hide();
            MainForm m = new MainForm(u);
            m.FormClosed += (s, args) => this.Close();
            m.Show();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUserName.Text;
            string password = txtPassword.Text;

            
        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
