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
        public Vocab()
        {
            InitializeComponent();
        }

        

        private void btn1_Click(object sender, EventArgs e)
        {
            if(btn1.Text.Equals("German Word"))
            {
                btn1.BackColor = Color.LightCoral;
                btn1.Text = "English";
            }
            else
            {
                btn1.BackColor = Color.DarkTurquoise;
                btn1.Text = "German Word";
            }


        }

        private void btn2_Click(object sender, EventArgs e)
        {
            if (btn2.Text.Equals("German Word"))
            {
                btn2.BackColor = Color.LightCoral;
                btn2.Text = "English";
            }
            else
            {
                btn2.BackColor = Color.DarkTurquoise;
                btn2.Text = "German Word";
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

        private void btnTest_Click(object sender, EventArgs e)
        {
          
        }
    }
}
