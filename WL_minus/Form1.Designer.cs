namespace WL_minus
{
    partial class Form1
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
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.btnFirst = new System.Windows.Forms.Button();
            this.btnSecond = new System.Windows.Forms.Button();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.chkHighest = new System.Windows.Forms.CheckBox();
            this.lblyear = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnFirst
            // 
            this.btnFirst.Location = new System.Drawing.Point(13, 12);
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new System.Drawing.Size(75, 23);
            this.btnFirst.TabIndex = 0;
            this.btnFirst.Text = "First Folder";
            this.btnFirst.UseVisualStyleBackColor = true;
            this.btnFirst.Click += new System.EventHandler(this.btnFirstClick);
            // 
            // btnSecond
            // 
            this.btnSecond.Location = new System.Drawing.Point(94, 12);
            this.btnSecond.Name = "btnSecond";
            this.btnSecond.Size = new System.Drawing.Size(96, 23);
            this.btnSecond.TabIndex = 1;
            this.btnSecond.Text = "Second Folder";
            this.btnSecond.UseVisualStyleBackColor = true;
            this.btnSecond.Click += new System.EventHandler(this.btnSecondClick);
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(150, 106);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(75, 23);
            this.btnGenerate.TabIndex = 3;
            this.btnGenerate.Text = "Generate CSVs";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerateClick);
            // 
            // chkHighest
            // 
            this.chkHighest.AutoSize = true;
            this.chkHighest.Location = new System.Drawing.Point(94, 52);
            this.chkHighest.Name = "chkHighest";
            this.chkHighest.Size = new System.Drawing.Size(86, 17);
            this.chkHighest.TabIndex = 4;
            this.chkHighest.Text = "Only Highest";
            this.chkHighest.UseVisualStyleBackColor = true;
            // 
            // lblyear
            // 
            this.lblyear.AutoSize = true;
            this.lblyear.Location = new System.Drawing.Point(12, 56);
            this.lblyear.Name = "lblyear";
            this.lblyear.Size = new System.Drawing.Size(58, 13);
            this.lblyear.TabIndex = 5;
            this.lblyear.Text = "Year name";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(237, 141);
            this.Controls.Add(this.lblyear);
            this.Controls.Add(this.chkHighest);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.btnSecond);
            this.Controls.Add(this.btnFirst);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button btnFirst;
        private System.Windows.Forms.Button btnSecond;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.CheckBox chkHighest;
        private System.Windows.Forms.Label lblyear;
    }
}

