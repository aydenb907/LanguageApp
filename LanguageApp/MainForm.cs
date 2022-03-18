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
        
        public static int lesson;
        
        public MainForm()
        {
            InitializeComponent();
        }
        
        private void btnBeginner_Click(object sender, EventArgs e)
        {
            lesson = 0;
            this.Hide();
            Info i = new Info();
            i.FormClosed += (s, args) => this.Close();
            i.Show();
        }
        private void btn1_Click(object sender, EventArgs e)
        {
            lesson = 1;
            this.Hide();
            Info i = new Info();
            i.FormClosed += (s, args) => this.Close();
            i.Show();
        }
        private void btn2_Click(object sender, EventArgs e)
        {
            lesson = 2;
            this.Hide();
           
            Info i = new Info();
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

        private void grammarTerms_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Noun: " +
                "\nVerb: " +
                "");
        }

        private void completeList_Click(object sender, EventArgs e)
        {
            MessageBox.Show("");
        }

        private void motivation_Click(object sender, EventArgs e)
        {
            MessageBox.Show("");
        }
    }
}
