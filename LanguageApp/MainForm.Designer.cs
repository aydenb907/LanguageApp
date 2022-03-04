
namespace LanguageApp
{
    partial class MainForm
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
            this.btnArticles = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.grammarTermsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.completeVocabularyListOfThisAppToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btn2 = new System.Windows.Forms.Button();
            this.btn3 = new System.Windows.Forms.Button();
            this.btnBeginner = new System.Windows.Forms.Button();
            this.btn5 = new System.Windows.Forms.Button();
            this.btn4 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnArticles
            // 
            this.btnArticles.Location = new System.Drawing.Point(267, 127);
            this.btnArticles.Name = "btnArticles";
            this.btnArticles.Size = new System.Drawing.Size(122, 36);
            this.btnArticles.TabIndex = 0;
            this.btnArticles.Text = "Lesson 1: Articles";
            this.btnArticles.UseVisualStyleBackColor = true;
            this.btnArticles.Click += new System.EventHandler(this.btn1_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuInfo,
            this.grammarTermsToolStripMenuItem,
            this.completeVocabularyListOfThisAppToolStripMenuItem,
            this.dToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(902, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuInfo
            // 
            this.menuInfo.Name = "menuInfo";
            this.menuInfo.Size = new System.Drawing.Size(148, 20);
            this.menuInfo.Text = "What is This App About?";
            this.menuInfo.Click += new System.EventHandler(this.menuInfo_Click);
            // 
            // grammarTermsToolStripMenuItem
            // 
            this.grammarTermsToolStripMenuItem.Name = "grammarTermsToolStripMenuItem";
            this.grammarTermsToolStripMenuItem.Size = new System.Drawing.Size(103, 20);
            this.grammarTermsToolStripMenuItem.Text = "Grammar Terms";
            // 
            // completeVocabularyListOfThisAppToolStripMenuItem
            // 
            this.completeVocabularyListOfThisAppToolStripMenuItem.Name = "completeVocabularyListOfThisAppToolStripMenuItem";
            this.completeVocabularyListOfThisAppToolStripMenuItem.Size = new System.Drawing.Size(153, 20);
            this.completeVocabularyListOfThisAppToolStripMenuItem.Text = "Complete Vocabulary List";
            // 
            // dToolStripMenuItem
            // 
            this.dToolStripMenuItem.Name = "dToolStripMenuItem";
            this.dToolStripMenuItem.Size = new System.Drawing.Size(120, 20);
            this.dToolStripMenuItem.Text = "Why Learn German";
            // 
            // btn2
            // 
            this.btn2.Location = new System.Drawing.Point(418, 127);
            this.btn2.Name = "btn2";
            this.btn2.Size = new System.Drawing.Size(122, 36);
            this.btn2.TabIndex = 2;
            this.btn2.Text = "Lesson 2:";
            this.btn2.UseVisualStyleBackColor = true;
            this.btn2.Click += new System.EventHandler(this.btn2_Click);
            // 
            // btn3
            // 
            this.btn3.Location = new System.Drawing.Point(113, 190);
            this.btn3.Name = "btn3";
            this.btn3.Size = new System.Drawing.Size(122, 36);
            this.btn3.TabIndex = 3;
            this.btn3.Text = "3";
            this.btn3.UseVisualStyleBackColor = true;
            // 
            // btnBeginner
            // 
            this.btnBeginner.Location = new System.Drawing.Point(113, 127);
            this.btnBeginner.Name = "btnBeginner";
            this.btnBeginner.Size = new System.Drawing.Size(122, 36);
            this.btnBeginner.TabIndex = 4;
            this.btnBeginner.Text = "Absolute Beginner";
            this.btnBeginner.UseVisualStyleBackColor = true;
            this.btnBeginner.Click += new System.EventHandler(this.btnBeginner_Click);
            // 
            // btn5
            // 
            this.btn5.Location = new System.Drawing.Point(418, 190);
            this.btn5.Name = "btn5";
            this.btn5.Size = new System.Drawing.Size(122, 36);
            this.btn5.TabIndex = 5;
            this.btn5.Text = "5";
            this.btn5.UseVisualStyleBackColor = true;
            // 
            // btn4
            // 
            this.btn4.Location = new System.Drawing.Point(267, 190);
            this.btn4.Name = "btn4";
            this.btn4.Size = new System.Drawing.Size(122, 36);
            this.btn4.TabIndex = 6;
            this.btn4.Text = "4";
            this.btn4.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(902, 378);
            this.Controls.Add(this.btn4);
            this.Controls.Add(this.btn5);
            this.Controls.Add(this.btnBeginner);
            this.Controls.Add(this.btn3);
            this.Controls.Add(this.btn2);
            this.Controls.Add(this.btnArticles);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Home";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnArticles;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuInfo;
        private System.Windows.Forms.ToolStripMenuItem grammarTermsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem completeVocabularyListOfThisAppToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dToolStripMenuItem;
        private System.Windows.Forms.Button btn2;
        private System.Windows.Forms.Button btn3;
        private System.Windows.Forms.Button btnBeginner;
        private System.Windows.Forms.Button btn5;
        private System.Windows.Forms.Button btn4;
    }
}

