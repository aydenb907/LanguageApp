
namespace LanguageApp
{
    partial class Vocab
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn1 = new System.Windows.Forms.Button();
            this.btn2 = new System.Windows.Forms.Button();
            this.btnHome = new System.Windows.Forms.Button();
            this.btnLesson = new System.Windows.Forms.Button();
            this.btnMemorise = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblTotalScore = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn1
            // 
            this.btn1.BackColor = System.Drawing.Color.DarkTurquoise;
            this.btn1.Location = new System.Drawing.Point(30, 48);
            this.btn1.Name = "btn1";
            this.btn1.Size = new System.Drawing.Size(161, 64);
            this.btn1.TabIndex = 0;
            this.btn1.Text = "German Word";
            this.btn1.UseVisualStyleBackColor = false;
            this.btn1.Click += new System.EventHandler(this.btn1_Click);
            // 
            // btn2
            // 
            this.btn2.BackColor = System.Drawing.Color.DarkTurquoise;
            this.btn2.Location = new System.Drawing.Point(225, 48);
            this.btn2.Name = "btn2";
            this.btn2.Size = new System.Drawing.Size(158, 64);
            this.btn2.TabIndex = 1;
            this.btn2.Text = "German Word";
            this.btn2.UseVisualStyleBackColor = false;
            this.btn2.Click += new System.EventHandler(this.btn2_Click);
            // 
            // btnHome
            // 
            this.btnHome.Location = new System.Drawing.Point(0, -2);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(92, 23);
            this.btnHome.TabIndex = 2;
            this.btnHome.Text = "Home";
            this.btnHome.UseVisualStyleBackColor = true;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // btnLesson
            // 
            this.btnLesson.Location = new System.Drawing.Point(107, -2);
            this.btnLesson.Name = "btnLesson";
            this.btnLesson.Size = new System.Drawing.Size(145, 23);
            this.btnLesson.TabIndex = 3;
            this.btnLesson.Text = "Previous Lesson";
            this.btnLesson.UseVisualStyleBackColor = true;
            this.btnLesson.Click += new System.EventHandler(this.btnLesson_Click);
            // 
            // btnMemorise
            // 
            this.btnMemorise.Location = new System.Drawing.Point(239, 334);
            this.btnMemorise.Name = "btnMemorise";
            this.btnMemorise.Size = new System.Drawing.Size(284, 58);
            this.btnMemorise.TabIndex = 4;
            this.btnMemorise.Text = "Memorise These";
            this.btnMemorise.UseVisualStyleBackColor = true;
            this.btnMemorise.Click += new System.EventHandler(this.btnMemorise_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblTotalScore);
            this.groupBox1.Controls.Add(this.lblUsername);
            this.groupBox1.Location = new System.Drawing.Point(688, -2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(125, 80);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            // 
            // lblTotalScore
            // 
            this.lblTotalScore.AutoSize = true;
            this.lblTotalScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lblTotalScore.Location = new System.Drawing.Point(18, 47);
            this.lblTotalScore.Name = "lblTotalScore";
            this.lblTotalScore.Size = new System.Drawing.Size(78, 18);
            this.lblTotalScore.TabIndex = 9;
            this.lblTotalScore.Text = "total score";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lblUsername.Location = new System.Drawing.Point(18, 16);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(74, 18);
            this.lblUsername.TabIndex = 8;
            this.lblUsername.Text = "username";
            // 
            // Vocab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(816, 450);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnMemorise);
            this.Controls.Add(this.btnLesson);
            this.Controls.Add(this.btnHome);
            this.Controls.Add(this.btn2);
            this.Controls.Add(this.btn1);
            this.Name = "Vocab";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn1;
        private System.Windows.Forms.Button btn2;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.Button btnLesson;
        private System.Windows.Forms.Button btnMemorise;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblTotalScore;
        private System.Windows.Forms.Label lblUsername;
    }
}