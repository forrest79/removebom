namespace RemoveBOM
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.chkBackup = new System.Windows.Forms.CheckBox();
            this.lblHelp = new System.Windows.Forms.Label();
            this.listFiles = new System.Windows.Forms.ListBox();
            this.rbRemove = new System.Windows.Forms.RadioButton();
            this.rbTest = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rbBOM = new System.Windows.Forms.RadioButton();
            this.rbAll = new System.Windows.Forms.RadioButton();
            this.btnClearList = new System.Windows.Forms.Button();
            this.lblBOMFilesText = new System.Windows.Forms.Label();
            this.lblBOMFiles = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.chkAlwayOnTop = new System.Windows.Forms.CheckBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // chkBackup
            // 
            this.chkBackup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkBackup.AutoSize = true;
            this.chkBackup.Checked = true;
            this.chkBackup.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBackup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.chkBackup.Location = new System.Drawing.Point(125, 307);
            this.chkBackup.Name = "chkBackup";
            this.chkBackup.Size = new System.Drawing.Size(92, 17);
            this.chkBackup.TabIndex = 0;
            this.chkBackup.Text = "Make &backup";
            this.chkBackup.UseVisualStyleBackColor = true;
            // 
            // lblHelp
            // 
            this.lblHelp.AutoSize = true;
            this.lblHelp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblHelp.Location = new System.Drawing.Point(12, 9);
            this.lblHelp.Name = "lblHelp";
            this.lblHelp.Size = new System.Drawing.Size(451, 13);
            this.lblHelp.TabIndex = 1;
            this.lblHelp.Text = "Drag files or directories to the list to remove/test BOM header from UTF-8 files";
            // 
            // listFiles
            // 
            this.listFiles.AllowDrop = true;
            this.listFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listFiles.BackColor = System.Drawing.Color.White;
            this.listFiles.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.listFiles.FormattingEnabled = true;
            this.listFiles.Location = new System.Drawing.Point(15, 29);
            this.listFiles.Name = "listFiles";
            this.listFiles.Size = new System.Drawing.Size(557, 225);
            this.listFiles.TabIndex = 3;
            this.listFiles.DragDrop += new System.Windows.Forms.DragEventHandler(this.listFiles_DragDrop);
            this.listFiles.DragEnter += new System.Windows.Forms.DragEventHandler(this.listFiles_DragEnter);
            // 
            // rbRemove
            // 
            this.rbRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rbRemove.AutoSize = true;
            this.rbRemove.Checked = true;
            this.rbRemove.Location = new System.Drawing.Point(15, 307);
            this.rbRemove.Name = "rbRemove";
            this.rbRemove.Size = new System.Drawing.Size(92, 17);
            this.rbRemove.TabIndex = 5;
            this.rbRemove.TabStop = true;
            this.rbRemove.Text = "&Remove BOM";
            this.rbRemove.UseVisualStyleBackColor = true;
            // 
            // rbTest
            // 
            this.rbTest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rbTest.AutoSize = true;
            this.rbTest.Location = new System.Drawing.Point(15, 330);
            this.rbTest.Name = "rbTest";
            this.rbTest.Size = new System.Drawing.Size(73, 17);
            this.rbTest.TabIndex = 6;
            this.rbTest.Text = "&Test BOM";
            this.rbTest.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.rbBOM);
            this.panel1.Controls.Add(this.rbAll);
            this.panel1.Controls.Add(this.btnClearList);
            this.panel1.Location = new System.Drawing.Point(346, 303);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(226, 59);
            this.panel1.TabIndex = 7;
            // 
            // rbBOM
            // 
            this.rbBOM.AutoSize = true;
            this.rbBOM.Checked = true;
            this.rbBOM.Location = new System.Drawing.Point(3, 9);
            this.rbBOM.Name = "rbBOM";
            this.rbBOM.Size = new System.Drawing.Size(111, 17);
            this.rbBOM.TabIndex = 7;
            this.rbBOM.TabStop = true;
            this.rbBOM.Text = "List &BOM files only";
            this.rbBOM.UseVisualStyleBackColor = true;
            // 
            // rbAll
            // 
            this.rbAll.AutoSize = true;
            this.rbAll.Location = new System.Drawing.Point(3, 32);
            this.rbAll.Name = "rbAll";
            this.rbAll.Size = new System.Drawing.Size(75, 17);
            this.rbAll.TabIndex = 6;
            this.rbAll.Text = "List &all files";
            this.rbAll.UseVisualStyleBackColor = true;
            // 
            // btnClearList
            // 
            this.btnClearList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearList.Location = new System.Drawing.Point(130, 3);
            this.btnClearList.Name = "btnClearList";
            this.btnClearList.Size = new System.Drawing.Size(93, 53);
            this.btnClearList.TabIndex = 5;
            this.btnClearList.Text = "&Clear list";
            this.btnClearList.UseVisualStyleBackColor = true;
            this.btnClearList.Click += new System.EventHandler(this.btnClearList_Click);
            // 
            // lblBOMFilesText
            // 
            this.lblBOMFilesText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBOMFilesText.AutoSize = true;
            this.lblBOMFilesText.Location = new System.Drawing.Point(346, 287);
            this.lblBOMFilesText.Name = "lblBOMFilesText";
            this.lblBOMFilesText.Size = new System.Drawing.Size(55, 13);
            this.lblBOMFilesText.TabIndex = 8;
            this.lblBOMFilesText.Text = "BOM files:";
            // 
            // lblBOMFiles
            // 
            this.lblBOMFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBOMFiles.AutoSize = true;
            this.lblBOMFiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblBOMFiles.Location = new System.Drawing.Point(407, 287);
            this.lblBOMFiles.Name = "lblBOMFiles";
            this.lblBOMFiles.Size = new System.Drawing.Size(14, 13);
            this.lblBOMFiles.TabIndex = 9;
            this.lblBOMFiles.Text = "0";
            this.lblBOMFiles.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 276);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Extension:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(78, 273);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(78, 20);
            this.textBox1.TabIndex = 11;
            // 
            // chkAlwayOnTop
            // 
            this.chkAlwayOnTop.AutoSize = true;
            this.chkAlwayOnTop.Location = new System.Drawing.Point(480, 8);
            this.chkAlwayOnTop.Name = "chkAlwayOnTop";
            this.chkAlwayOnTop.Size = new System.Drawing.Size(92, 17);
            this.chkAlwayOnTop.TabIndex = 12;
            this.chkAlwayOnTop.Text = "Always &on top";
            this.chkAlwayOnTop.UseVisualStyleBackColor = true;
            this.chkAlwayOnTop.CheckedChanged += new System.EventHandler(this.chkAlwayOnTop_CheckedChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::RemoveBOM.Properties.Resources.Loading;
            this.pictureBox1.Location = new System.Drawing.Point(489, 260);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(20, 18);
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 366);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.chkAlwayOnTop);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblBOMFiles);
            this.Controls.Add(this.lblBOMFilesText);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.rbTest);
            this.Controls.Add(this.rbRemove);
            this.Controls.Add(this.listFiles);
            this.Controls.Add(this.lblHelp);
            this.Controls.Add(this.chkBackup);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(600, 400);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RemoveBOM";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkBackup;
        private System.Windows.Forms.Label lblHelp;
        private System.Windows.Forms.ListBox listFiles;
        private System.Windows.Forms.RadioButton rbRemove;
        private System.Windows.Forms.RadioButton rbTest;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnClearList;
        private System.Windows.Forms.RadioButton rbBOM;
        private System.Windows.Forms.RadioButton rbAll;
        private System.Windows.Forms.Label lblBOMFilesText;
        private System.Windows.Forms.Label lblBOMFiles;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.CheckBox chkAlwayOnTop;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

