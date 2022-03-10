
namespace LanguageApp
{
    partial class Info
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
            this.SuspendLayout();
            // 
            // btnHome
            // 
            this.btnHome.Location = new System.Drawing.Point(0, 0);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(159, 27);
            this.btnHome.TabIndex = 0;
            this.btnHome.Text = "Home ";
            this.btnHome.UseVisualStyleBackColor = true;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // lblLesson
            // 
            this.lblLesson.AutoSize = true;
            this.lblLesson.Location = new System.Drawing.Point(94, 56);
            this.lblLesson.Name = "lblLesson";
            this.lblLesson.Size = new System.Drawing.Size(41, 13);
            this.lblLesson.TabIndex = 1;
            this.lblLesson.Text = "Lesson";
            this.lblLesson.Click += new System.EventHandler(this.lblLesson_Click);
            // 
            // btnPractise
            // 
            this.btnPractise.Location = new System.Drawing.Point(221, 219);
            this.btnPractise.Name = "btnPractise";
            this.btnPractise.Size = new System.Drawing.Size(242, 37);
            this.btnPractise.TabIndex = 2;
            this.btnPractise.Text = "Practise Completing Sentences";
            this.btnPractise.UseVisualStyleBackColor = true;
            this.btnPractise.Click += new System.EventHandler(this.btnPractise_Click);
            // 
            // btnVocab
            // 
            this.btnVocab.Location = new System.Drawing.Point(221, 160);
            this.btnVocab.Name = "btnVocab";
            this.btnVocab.Size = new System.Drawing.Size(242, 39);
            this.btnVocab.TabIndex = 4;
            this.btnVocab.Text = "Learn Words";
            this.btnVocab.UseVisualStyleBackColor = true;
            this.btnVocab.Click += new System.EventHandler(this.btnVocab_Click);
            // 
            // lblEnglisch
            // 
            this.lblEnglisch.AutoSize = true;
            this.lblEnglisch.Location = new System.Drawing.Point(514, 14);
            this.lblEnglisch.Name = "lblEnglisch";
            this.lblEnglisch.Size = new System.Drawing.Size(75, 13);
            this.lblEnglisch.TabIndex = 20;
            this.lblEnglisch.Text = "English Words";
            // 
            // lblDeutsch
            // 
            this.lblDeutsch.AutoSize = true;
            this.lblDeutsch.Location = new System.Drawing.Point(677, 14);
            this.lblDeutsch.Name = "lblDeutsch";
            this.lblDeutsch.Size = new System.Drawing.Size(78, 13);
            this.lblDeutsch.TabIndex = 21;
            this.lblDeutsch.Text = "German Words";
            // 
            // btnGrammarTest
            // 
            this.btnGrammarTest.Location = new System.Drawing.Point(221, 275);
            this.btnGrammarTest.Name = "btnGrammarTest";
            this.btnGrammarTest.Size = new System.Drawing.Size(242, 37);
            this.btnGrammarTest.TabIndex = 22;
            this.btnGrammarTest.Text = "Test For This Lesson";
            this.btnGrammarTest.UseVisualStyleBackColor = true;
            this.btnGrammarTest.Click += new System.EventHandler(this.btnGrammarTest_Click);
            // 
            // Info
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(826, 345);
            this.Controls.Add(this.btnGrammarTest);
            this.Controls.Add(this.lblDeutsch);
            this.Controls.Add(this.lblEnglisch);
            this.Controls.Add(this.btnVocab);
            this.Controls.Add(this.btnPractise);
            this.Controls.Add(this.lblLesson);
            this.Controls.Add(this.btnHome);
            this.Name = "Info";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Info_Load);
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
    }
}