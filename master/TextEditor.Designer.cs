﻿namespace TTG_Tools
{
    partial class TextEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TextEditor));
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.firstFilePath = new System.Windows.Forms.TextBox();
            this.readyFilePath = new System.Windows.Forms.TextBox();
            this.firstFileBtn = new System.Windows.Forms.Button();
            this.readyFileBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.mergeSeveralRB = new System.Windows.Forms.RadioButton();
            this.mergeSingleRB = new System.Windows.Forms.RadioButton();
            this.tabPagesControl = new System.Windows.Forms.TabControl();
            this.mergeTextTabPage = new System.Windows.Forms.TabPage();
            this.sortStrsCB = new System.Windows.Forms.CheckBox();
            this.checkDuplicatedStrsBtn = new System.Windows.Forms.Button();
            this.mergeBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.secondFilePath = new System.Windows.Forms.TextBox();
            this.secondFileBtn = new System.Windows.Forms.Button();
            this.replaceTextTabPage = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.sortTranslatedRB = new System.Windows.Forms.RadioButton();
            this.sortOriginalRB = new System.Windows.Forms.RadioButton();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.replaceSeveralRB = new System.Windows.Forms.RadioButton();
            this.replaceSingleRB = new System.Windows.Forms.RadioButton();
            this.readyDoubledFileBtn = new System.Windows.Forms.Button();
            this.secondDoubledFileBtn = new System.Windows.Forms.Button();
            this.firstDoubledFileBtn = new System.Windows.Forms.Button();
            this.readyDoubledFilePath = new System.Windows.Forms.TextBox();
            this.secondDoubledFilePath = new System.Windows.Forms.TextBox();
            this.firstDoubledFilePath = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.sortDoubledCB = new System.Windows.Forms.CheckBox();
            this.button3 = new System.Windows.Forms.Button();
            this.progressBar2 = new System.Windows.Forms.ProgressBar();
            this.groupBox1.SuspendLayout();
            this.tabPagesControl.SuspendLayout();
            this.mergeTextTabPage.SuspendLayout();
            this.replaceTextTabPage.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(31, 237);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(709, 23);
            this.progressBar1.TabIndex = 8;
            // 
            // firstFilePath
            // 
            this.firstFilePath.Location = new System.Drawing.Point(78, 22);
            this.firstFilePath.Name = "firstFilePath";
            this.firstFilePath.Size = new System.Drawing.Size(447, 20);
            this.firstFilePath.TabIndex = 9;
            // 
            // readyFilePath
            // 
            this.readyFilePath.Location = new System.Drawing.Point(78, 96);
            this.readyFilePath.Name = "readyFilePath";
            this.readyFilePath.Size = new System.Drawing.Size(447, 20);
            this.readyFilePath.TabIndex = 10;
            // 
            // firstFileBtn
            // 
            this.firstFileBtn.Location = new System.Drawing.Point(537, 20);
            this.firstFileBtn.Name = "firstFileBtn";
            this.firstFileBtn.Size = new System.Drawing.Size(33, 23);
            this.firstFileBtn.TabIndex = 11;
            this.firstFileBtn.Text = "...";
            this.firstFileBtn.UseVisualStyleBackColor = true;
            this.firstFileBtn.Click += new System.EventHandler(this.firstFileBtn_Click);
            // 
            // readyFileBtn
            // 
            this.readyFileBtn.Location = new System.Drawing.Point(537, 94);
            this.readyFileBtn.Name = "readyFileBtn";
            this.readyFileBtn.Size = new System.Drawing.Size(33, 23);
            this.readyFileBtn.TabIndex = 12;
            this.readyFileBtn.Text = "...";
            this.readyFileBtn.UseVisualStyleBackColor = true;
            this.readyFileBtn.Click += new System.EventHandler(this.readyFileBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "First file:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Ready file:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.mergeSeveralRB);
            this.groupBox1.Controls.Add(this.mergeSingleRB);
            this.groupBox1.Location = new System.Drawing.Point(597, 20);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(122, 77);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Merge";
            // 
            // mergeSeveralRB
            // 
            this.mergeSeveralRB.AutoSize = true;
            this.mergeSeveralRB.Location = new System.Drawing.Point(18, 48);
            this.mergeSeveralRB.Name = "mergeSeveralRB";
            this.mergeSeveralRB.Size = new System.Drawing.Size(82, 17);
            this.mergeSeveralRB.TabIndex = 1;
            this.mergeSeveralRB.TabStop = true;
            this.mergeSeveralRB.Text = "Several files";
            this.mergeSeveralRB.UseVisualStyleBackColor = true;
            // 
            // mergeSingleRB
            // 
            this.mergeSingleRB.AutoSize = true;
            this.mergeSingleRB.Location = new System.Drawing.Point(18, 19);
            this.mergeSingleRB.Name = "mergeSingleRB";
            this.mergeSingleRB.Size = new System.Drawing.Size(70, 17);
            this.mergeSingleRB.TabIndex = 0;
            this.mergeSingleRB.TabStop = true;
            this.mergeSingleRB.Text = "Single file";
            this.mergeSingleRB.UseVisualStyleBackColor = true;
            this.mergeSingleRB.CheckedChanged += new System.EventHandler(this.mergeSingleRB_CheckedChanged);
            // 
            // tabPagesControl
            // 
            this.tabPagesControl.Controls.Add(this.mergeTextTabPage);
            this.tabPagesControl.Controls.Add(this.replaceTextTabPage);
            this.tabPagesControl.Location = new System.Drawing.Point(15, 12);
            this.tabPagesControl.Name = "tabPagesControl";
            this.tabPagesControl.SelectedIndex = 0;
            this.tabPagesControl.Size = new System.Drawing.Size(743, 206);
            this.tabPagesControl.TabIndex = 16;
            // 
            // mergeTextTabPage
            // 
            this.mergeTextTabPage.BackColor = System.Drawing.Color.Transparent;
            this.mergeTextTabPage.Controls.Add(this.button3);
            this.mergeTextTabPage.Controls.Add(this.sortStrsCB);
            this.mergeTextTabPage.Controls.Add(this.checkDuplicatedStrsBtn);
            this.mergeTextTabPage.Controls.Add(this.mergeBtn);
            this.mergeTextTabPage.Controls.Add(this.label3);
            this.mergeTextTabPage.Controls.Add(this.secondFilePath);
            this.mergeTextTabPage.Controls.Add(this.secondFileBtn);
            this.mergeTextTabPage.Controls.Add(this.firstFileBtn);
            this.mergeTextTabPage.Controls.Add(this.groupBox1);
            this.mergeTextTabPage.Controls.Add(this.firstFilePath);
            this.mergeTextTabPage.Controls.Add(this.label2);
            this.mergeTextTabPage.Controls.Add(this.readyFilePath);
            this.mergeTextTabPage.Controls.Add(this.label1);
            this.mergeTextTabPage.Controls.Add(this.readyFileBtn);
            this.mergeTextTabPage.Location = new System.Drawing.Point(4, 22);
            this.mergeTextTabPage.Name = "mergeTextTabPage";
            this.mergeTextTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.mergeTextTabPage.Size = new System.Drawing.Size(735, 180);
            this.mergeTextTabPage.TabIndex = 0;
            this.mergeTextTabPage.Text = "Merge texts";
            // 
            // sortStrsCB
            // 
            this.sortStrsCB.AutoSize = true;
            this.sortStrsCB.Location = new System.Drawing.Point(591, 132);
            this.sortStrsCB.Name = "sortStrsCB";
            this.sortStrsCB.Size = new System.Drawing.Size(130, 17);
            this.sortStrsCB.TabIndex = 21;
            this.sortStrsCB.Text = "Sort duplicated strings";
            this.sortStrsCB.UseVisualStyleBackColor = true;
            // 
            // checkDuplicatedStrsBtn
            // 
            this.checkDuplicatedStrsBtn.Location = new System.Drawing.Point(114, 132);
            this.checkDuplicatedStrsBtn.Name = "checkDuplicatedStrsBtn";
            this.checkDuplicatedStrsBtn.Size = new System.Drawing.Size(239, 23);
            this.checkDuplicatedStrsBtn.TabIndex = 20;
            this.checkDuplicatedStrsBtn.Text = "Check on duplicated origianl strings";
            this.checkDuplicatedStrsBtn.UseVisualStyleBackColor = true;
            // 
            // mergeBtn
            // 
            this.mergeBtn.Location = new System.Drawing.Point(18, 132);
            this.mergeBtn.Name = "mergeBtn";
            this.mergeBtn.Size = new System.Drawing.Size(75, 23);
            this.mergeBtn.TabIndex = 19;
            this.mergeBtn.Text = "Merge files";
            this.mergeBtn.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Second file:";
            // 
            // secondFilePath
            // 
            this.secondFilePath.Location = new System.Drawing.Point(78, 59);
            this.secondFilePath.Name = "secondFilePath";
            this.secondFilePath.Size = new System.Drawing.Size(447, 20);
            this.secondFilePath.TabIndex = 16;
            // 
            // secondFileBtn
            // 
            this.secondFileBtn.Location = new System.Drawing.Point(537, 57);
            this.secondFileBtn.Name = "secondFileBtn";
            this.secondFileBtn.Size = new System.Drawing.Size(33, 23);
            this.secondFileBtn.TabIndex = 17;
            this.secondFileBtn.Text = "...";
            this.secondFileBtn.UseVisualStyleBackColor = true;
            this.secondFileBtn.Click += new System.EventHandler(this.secondFileBtn_Click);
            // 
            // replaceTextTabPage
            // 
            this.replaceTextTabPage.BackColor = System.Drawing.Color.Transparent;
            this.replaceTextTabPage.Controls.Add(this.sortDoubledCB);
            this.replaceTextTabPage.Controls.Add(this.groupBox3);
            this.replaceTextTabPage.Controls.Add(this.button2);
            this.replaceTextTabPage.Controls.Add(this.button1);
            this.replaceTextTabPage.Controls.Add(this.groupBox2);
            this.replaceTextTabPage.Controls.Add(this.readyDoubledFileBtn);
            this.replaceTextTabPage.Controls.Add(this.secondDoubledFileBtn);
            this.replaceTextTabPage.Controls.Add(this.firstDoubledFileBtn);
            this.replaceTextTabPage.Controls.Add(this.readyDoubledFilePath);
            this.replaceTextTabPage.Controls.Add(this.secondDoubledFilePath);
            this.replaceTextTabPage.Controls.Add(this.firstDoubledFilePath);
            this.replaceTextTabPage.Controls.Add(this.label6);
            this.replaceTextTabPage.Controls.Add(this.label5);
            this.replaceTextTabPage.Controls.Add(this.label4);
            this.replaceTextTabPage.Location = new System.Drawing.Point(4, 22);
            this.replaceTextTabPage.Name = "replaceTextTabPage";
            this.replaceTextTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.replaceTextTabPage.Size = new System.Drawing.Size(735, 180);
            this.replaceTextTabPage.TabIndex = 1;
            this.replaceTextTabPage.Text = "Replace texts";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.sortTranslatedRB);
            this.groupBox3.Controls.Add(this.sortOriginalRB);
            this.groupBox3.Location = new System.Drawing.Point(597, 101);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(122, 69);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Sort by";
            // 
            // sortTranslatedRB
            // 
            this.sortTranslatedRB.AutoSize = true;
            this.sortTranslatedRB.Location = new System.Drawing.Point(13, 43);
            this.sortTranslatedRB.Name = "sortTranslatedRB";
            this.sortTranslatedRB.Size = new System.Drawing.Size(108, 17);
            this.sortTranslatedRB.TabIndex = 1;
            this.sortTranslatedRB.TabStop = true;
            this.sortTranslatedRB.Text = "Translated strings";
            this.sortTranslatedRB.UseVisualStyleBackColor = true;
            // 
            // sortOriginalRB
            // 
            this.sortOriginalRB.AutoSize = true;
            this.sortOriginalRB.Location = new System.Drawing.Point(13, 17);
            this.sortOriginalRB.Name = "sortOriginalRB";
            this.sortOriginalRB.Size = new System.Drawing.Size(93, 17);
            this.sortOriginalRB.TabIndex = 0;
            this.sortOriginalRB.TabStop = true;
            this.sortOriginalRB.Text = "Original strings";
            this.sortOriginalRB.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(197, 131);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(105, 36);
            this.button2.TabIndex = 11;
            this.button2.Text = "Check on duplicated strings";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(33, 131);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(136, 36);
            this.button1.TabIndex = 10;
            this.button1.Text = "Replace strings from first duplicated file";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.replaceSeveralRB);
            this.groupBox2.Controls.Add(this.replaceSingleRB);
            this.groupBox2.Location = new System.Drawing.Point(597, 20);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(122, 77);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Replace";
            // 
            // replaceSeveralRB
            // 
            this.replaceSeveralRB.AutoSize = true;
            this.replaceSeveralRB.Location = new System.Drawing.Point(13, 47);
            this.replaceSeveralRB.Name = "replaceSeveralRB";
            this.replaceSeveralRB.Size = new System.Drawing.Size(82, 17);
            this.replaceSeveralRB.TabIndex = 1;
            this.replaceSeveralRB.TabStop = true;
            this.replaceSeveralRB.Text = "Several files";
            this.replaceSeveralRB.UseVisualStyleBackColor = true;
            // 
            // replaceSingleRB
            // 
            this.replaceSingleRB.AutoSize = true;
            this.replaceSingleRB.Location = new System.Drawing.Point(13, 19);
            this.replaceSingleRB.Name = "replaceSingleRB";
            this.replaceSingleRB.Size = new System.Drawing.Size(70, 17);
            this.replaceSingleRB.TabIndex = 0;
            this.replaceSingleRB.TabStop = true;
            this.replaceSingleRB.Text = "Single file";
            this.replaceSingleRB.UseVisualStyleBackColor = true;
            // 
            // readyDoubledFileBtn
            // 
            this.readyDoubledFileBtn.Location = new System.Drawing.Point(548, 94);
            this.readyDoubledFileBtn.Name = "readyDoubledFileBtn";
            this.readyDoubledFileBtn.Size = new System.Drawing.Size(32, 23);
            this.readyDoubledFileBtn.TabIndex = 8;
            this.readyDoubledFileBtn.Text = "...";
            this.readyDoubledFileBtn.UseVisualStyleBackColor = true;
            // 
            // secondDoubledFileBtn
            // 
            this.secondDoubledFileBtn.Location = new System.Drawing.Point(548, 57);
            this.secondDoubledFileBtn.Name = "secondDoubledFileBtn";
            this.secondDoubledFileBtn.Size = new System.Drawing.Size(32, 23);
            this.secondDoubledFileBtn.TabIndex = 7;
            this.secondDoubledFileBtn.Text = "...";
            this.secondDoubledFileBtn.UseVisualStyleBackColor = true;
            // 
            // firstDoubledFileBtn
            // 
            this.firstDoubledFileBtn.Location = new System.Drawing.Point(548, 20);
            this.firstDoubledFileBtn.Name = "firstDoubledFileBtn";
            this.firstDoubledFileBtn.Size = new System.Drawing.Size(32, 23);
            this.firstDoubledFileBtn.TabIndex = 6;
            this.firstDoubledFileBtn.Text = "...";
            this.firstDoubledFileBtn.UseVisualStyleBackColor = true;
            // 
            // readyDoubledFilePath
            // 
            this.readyDoubledFilePath.Location = new System.Drawing.Point(122, 96);
            this.readyDoubledFilePath.Name = "readyDoubledFilePath";
            this.readyDoubledFilePath.Size = new System.Drawing.Size(411, 20);
            this.readyDoubledFilePath.TabIndex = 5;
            // 
            // secondDoubledFilePath
            // 
            this.secondDoubledFilePath.Location = new System.Drawing.Point(122, 59);
            this.secondDoubledFilePath.Name = "secondDoubledFilePath";
            this.secondDoubledFilePath.Size = new System.Drawing.Size(411, 20);
            this.secondDoubledFilePath.TabIndex = 4;
            // 
            // firstDoubledFilePath
            // 
            this.firstDoubledFilePath.Location = new System.Drawing.Point(122, 22);
            this.firstDoubledFilePath.Name = "firstDoubledFilePath";
            this.firstDoubledFilePath.Size = new System.Drawing.Size(411, 20);
            this.firstDoubledFilePath.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 99);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Ready doubled file:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Second doubled file:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "First doubled file:";
            // 
            // sortDoubledCB
            // 
            this.sortDoubledCB.AutoSize = true;
            this.sortDoubledCB.Location = new System.Drawing.Point(403, 142);
            this.sortDoubledCB.Name = "sortDoubledCB";
            this.sortDoubledCB.Size = new System.Drawing.Size(130, 17);
            this.sortDoubledCB.TabIndex = 13;
            this.sortDoubledCB.Text = "Sort duplicated strings";
            this.sortDoubledCB.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(372, 132);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(198, 23);
            this.button3.TabIndex = 22;
            this.button3.Text = "Add new strings from original file";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // progressBar2
            // 
            this.progressBar2.Location = new System.Drawing.Point(31, 275);
            this.progressBar2.Name = "progressBar2";
            this.progressBar2.Size = new System.Drawing.Size(709, 23);
            this.progressBar2.TabIndex = 17;
            // 
            // TextEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(766, 310);
            this.Controls.Add(this.progressBar2);
            this.Controls.Add(this.tabPagesControl);
            this.Controls.Add(this.progressBar1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "TextEditor";
            this.Text = "Text editor";
            this.Load += new System.EventHandler(this.TextEditor_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPagesControl.ResumeLayout(false);
            this.mergeTextTabPage.ResumeLayout(false);
            this.mergeTextTabPage.PerformLayout();
            this.replaceTextTabPage.ResumeLayout(false);
            this.replaceTextTabPage.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.TextBox firstFilePath;
        private System.Windows.Forms.TextBox readyFilePath;
        private System.Windows.Forms.Button firstFileBtn;
        private System.Windows.Forms.Button readyFileBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton mergeSeveralRB;
        private System.Windows.Forms.RadioButton mergeSingleRB;
        private System.Windows.Forms.TabControl tabPagesControl;
        private System.Windows.Forms.TabPage mergeTextTabPage;
        private System.Windows.Forms.TabPage replaceTextTabPage;
        private System.Windows.Forms.Button checkDuplicatedStrsBtn;
        private System.Windows.Forms.Button mergeBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox secondFilePath;
        private System.Windows.Forms.Button secondFileBtn;
        private System.Windows.Forms.TextBox readyDoubledFilePath;
        private System.Windows.Forms.TextBox secondDoubledFilePath;
        private System.Windows.Forms.TextBox firstDoubledFilePath;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox sortStrsCB;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton replaceSeveralRB;
        private System.Windows.Forms.RadioButton replaceSingleRB;
        private System.Windows.Forms.Button readyDoubledFileBtn;
        private System.Windows.Forms.Button secondDoubledFileBtn;
        private System.Windows.Forms.Button firstDoubledFileBtn;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton sortTranslatedRB;
        private System.Windows.Forms.RadioButton sortOriginalRB;
        private System.Windows.Forms.CheckBox sortDoubledCB;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ProgressBar progressBar2;
    }
}