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
    public partial class MainForm : Form
    {
        UserManager u = new UserManager();
        public static int lesson;
        
        public MainForm(UserManager u)
        {
            this.u = u;
            InitializeComponent();
        }
        
        private void btnBeginner_Click(object sender, EventArgs e)
        {
            lesson = 0;
            this.Hide();
            Info i = new Info(u);
            i.FormClosed += (s, args) => this.Close();
            i.Show();
        }
        private void btn1_Click(object sender, EventArgs e)
        {
            lesson = 1;
            this.Hide();
            Info i = new Info(u);
            i.FormClosed += (s, args) => this.Close();
            i.Show();
        }
        private void btn2_Click(object sender, EventArgs e)
        {
            lesson = 2;
            this.Hide();
           
            Info i = new Info(u);
            i.FormClosed += (s, args) => this.Close();
            i.Show();
        }

        private void menuInfo_Click(object sender, EventArgs e)
        {
            MessageBox.Show("");
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login l = new Login(u);
            l.FormClosed += (s, args) => this.Close();
            l.Show();
        }
    }
}
