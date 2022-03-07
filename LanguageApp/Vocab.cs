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
    public partial class Vocab : Form
    {
        private List<string> germanWords = Info.germanWords;
        private List<string> englishWords = Info.englishWords;
        public Vocab()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btn1.Text = germanWords[0];
            btn2.Text = germanWords[1];
            btn1.BackColor = Color.DarkTurquoise;
            btn2.BackColor = Color.DarkTurquoise;
        }

        private void btn1_Click(object sender, EventArgs e)
        {
           
            if (btn1.Text.Equals(germanWords[0]))
            {
                btn1.BackColor = Color.LightCoral;
                btn1.Text = englishWords[0];
            }
            else
            {
                btn1.BackColor = Color.DarkTurquoise;
                btn1.Text = germanWords[0];
            }
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            if (btn2.Text.Equals(germanWords[1]))
            {
                btn2.BackColor = Color.LightCoral;
                btn2.Text = englishWords[1];
            }
            else
            {
                btn2.BackColor = Color.DarkTurquoise;
                btn2.Text = germanWords[1];
            }
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
