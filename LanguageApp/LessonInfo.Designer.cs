
namespace LanguageApp
{
    partial class LessonInfo
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
            this.btnHome = new System.Windows.Forms.Button();
            this.lblLesson = new System.Windows.Forms.Label();
            this.btnPractise = new System.Windows.Forms.Button();
            this.btnVocab = new System.Windows.Forms.Button();
            this.lblEnglisch = new System.Windows.Forms.Label();
            this.lblDeutsch = new System.Windows.Forms.Label();
            this.btnGrammarTest = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblPlace = new System.Windows.Forms.Label();
            this.lblTotalPoints = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.btnLogOut = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblScore = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnHome
            // 
            this.btnHome.BackColor = System.Drawing.Color.SeaGreen;
            this.btnHome.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHome.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHome.Location = new System.Drawing.Point(-1, -2);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(126, 35);
            this.btnHome.TabIndex = 0;
            this.btnHome.Text = "Home ";
            this.btnHome.UseVisualStyleBackColor = false;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // lblLesson
            // 
            this.lblLesson.AutoSize = true;
            this.lblLesson.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLesson.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblLesson.Location = new System.Drawing.Point(37, 89);
            this.lblLesson.Name = "lblLesson";
            this.lblLesson.Size = new System.Drawing.Size(58, 21);
            this.lblLesson.TabIndex = 1;
            this.lblLesson.Text = "Lesson";
            this.lblLesson.Click += new System.EventHandler(this.lblLesson_Click);
            // 
            // btnPractise
            // 
            this.btnPractise.BackColor = System.Drawing.Color.SeaGreen;
            this.btnPractise.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPractise.Location = new System.Drawing.Point(305, 465);
            this.btnPractise.Name = "btnPractise";
            this.btnPractise.Size = new System.Drawing.Size(242, 39);
            this.btnPractise.TabIndex = 2;
            this.btnPractise.Text = "Practise Completing Sentences";
            this.btnPractise.UseVisualStyleBackColor = false;
            this.btnPractise.Click += new System.EventHandler(this.btnPractise_Click);
            // 
            // btnVocab
            // 
            this.btnVocab.BackColor = System.Drawing.Color.SeaGreen;
            this.btnVocab.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVocab.Location = new System.Drawing.Point(12, 465);
            this.btnVocab.Name = "btnVocab";
            this.btnVocab.Size = new System.Drawing.Size(242, 39);
            this.btnVocab.TabIndex = 4;
            this.btnVocab.Text = "Learn Words";
            this.btnVocab.UseVisualStyleBackColor = false;
            this.btnVocab.Click += new System.EventHandler(this.btnVocab_Click);
            // 
            // lblEnglisch
            // 
            this.lblEnglisch.AutoSize = true;
            this.lblEnglisch.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEnglisch.ForeColor = System.Drawing.Color.MediumSeaGreen;
            this.lblEnglisch.Location = new System.Drawing.Point(6, 16);
            this.lblEnglisch.Name = "lblEnglisch";
            this.lblEnglisch.Size = new System.Drawing.Size(109, 21);
            this.lblEnglisch.TabIndex = 20;
            this.lblEnglisch.Text = "English Words";
            // 
            // lblDeutsch
            // 
            this.lblDeutsch.AutoSize = true;
            this.lblDeutsch.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeutsch.ForeColor = System.Drawing.Color.Crimson;
            this.lblDeutsch.Location = new System.Drawing.Point(132, 16);
            this.lblDeutsch.Name = "lblDeutsch";
            this.lblDeutsch.Size = new System.Drawing.Size(115, 21);
            this.lblDeutsch.TabIndex = 21;
            this.lblDeutsch.Text = "German Words";
            // 
            // btnGrammarTest
            // 
            this.btnGrammarTest.BackColor = System.Drawing.Color.SeaGreen;
            this.btnGrammarTest.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGrammarTest.Location = new System.Drawing.Point(602, 465);
            this.btnGrammarTest.Name = "btnGrammarTest";
            this.btnGrammarTest.Size = new System.Drawing.Size(242, 39);
            this.btnGrammarTest.TabIndex = 22;
            this.btnGrammarTest.Text = "Test For This Lesson";
            this.btnGrammarTest.UseVisualStyleBackColor = false;
            this.btnGrammarTest.Click += new System.EventHandler(this.btnGrammarTest_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblPlace);
            this.groupBox1.Controls.Add(this.lblTotalPoints);
            this.groupBox1.Controls.Add(this.lblUsername);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox1.Location = new System.Drawing.Point(703, 33);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(150, 106);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            // 
            // lblPlace
            // 
            this.lblPlace.AutoSize = true;
            this.lblPlace.Location = new System.Drawing.Point(20, 78);
            this.lblPlace.Name = "lblPlace";
            this.lblPlace.Size = new System.Drawing.Size(60, 24);
            this.lblPlace.TabIndex = 10;
            this.lblPlace.Text = "label1";
            // 
            // lblTotalPoints
            // 
            this.lblTotalPoints.AutoSize = true;
            this.lblTotalPoints.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalPoints.Location = new System.Drawing.Point(18, 47);
            this.lblTotalPoints.Name = "lblTotalPoints";
            this.lblTotalPoints.Size = new System.Drawing.Size(87, 20);
            this.lblTotalPoints.TabIndex = 9;
            this.lblTotalPoints.Text = "total points";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsername.Location = new System.Drawing.Point(18, 16);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(80, 20);
            this.lblUsername.TabIndex = 8;
            this.lblUsername.Text = "username";
            // 
            // btnLogOut
            // 
            this.btnLogOut.BackColor = System.Drawing.Color.DarkRed;
            this.btnLogOut.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogOut.Location = new System.Drawing.Point(715, 0);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(138, 33);
            this.btnLogOut.TabIndex = 24;
            this.btnLogOut.Text = "Log Out";
            this.btnLogOut.UseVisualStyleBackColor = false;
            this.btnLogOut.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblDeutsch);
            this.groupBox2.Controls.Add(this.lblEnglisch);
            this.groupBox2.Location = new System.Drawing.Point(591, 138);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(262, 321);
            this.groupBox2.TabIndex = 25;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "groupBox2";
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.lblScore.ForeColor = System.Drawing.Color.White;
            this.lblScore.Location = new System.Drawing.Point(156, 9);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(262, 24);
            this.lblScore.TabIndex = 26;
            this.lblScore.Text = "Average score for this lesson: ";
            // 
            // LessonInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(852, 516);
            this.Controls.Add(this.lblScore);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnLogOut);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnGrammarTest);
            this.Controls.Add(this.btnVocab);
            this.Controls.Add(this.btnPractise);
            this.Controls.Add(this.lblLesson);
            this.Controls.Add(this.btnHome);
            this.Name = "LessonInfo";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Info_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.Label lblLesson;
        private System.Windows.Forms.Button btnPractise;
        private System.Windows.Forms.Button btnVocab;
        private System.Windows.Forms.Label lblEnglisch;
        private System.Windows.Forms.Label lblDeutsch;
        private System.Windows.Forms.Button btnGrammarTest;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblTotalPoints;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Button btnLogOut;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblPlace;
        private System.Windows.Forms.Label lblScore;
    }
}