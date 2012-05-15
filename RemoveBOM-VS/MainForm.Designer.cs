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
            this.lnkForrest79 = new System.Windows.Forms.LinkLabel();
            this.listFiles = new System.Windows.Forms.ListBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // chkBackup
            // 
            this.chkBackup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkBackup.AutoSize = true;
            this.chkBackup.Checked = true;
            this.chkBackup.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBackup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.chkBackup.Location = new System.Drawing.Point(15, 260);
            this.chkBackup.Name = "chkBackup";
            this.chkBackup.Size = new System.Drawing.Size(92, 17);
            this.chkBackup.TabIndex = 0;
            this.chkBackup.Text = "Make backup";
            this.chkBackup.UseVisualStyleBackColor = true;
            // 
            // lblHelp
            // 
            this.lblHelp.AutoSize = true;
            this.lblHelp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblHelp.Location = new System.Drawing.Point(12, 9);
            this.lblHelp.Name = "lblHelp";
            this.lblHelp.Size = new System.Drawing.Size(292, 13);
            this.lblHelp.TabIndex = 1;
            this.lblHelp.Text = "Drag files or directories to the list to remove BOM from UTF-8";
            // 
            // lnkForrest79
            // 
            this.lnkForrest79.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lnkForrest79.AutoSize = true;
            this.lnkForrest79.Location = new System.Drawing.Point(459, 9);
            this.lnkForrest79.Name = "lnkForrest79";
            this.lnkForrest79.Size = new System.Drawing.Size(97, 13);
            this.lnkForrest79.TabIndex = 2;
            this.lnkForrest79.TabStop = true;
            this.lnkForrest79.Text = "http://forrest79.net";
            this.lnkForrest79.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkForrest79_LinkClicked);
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
            this.listFiles.Size = new System.Drawing.Size(541, 225);
            this.listFiles.TabIndex = 3;
            this.listFiles.DragDrop += new System.Windows.Forms.DragEventHandler(this.listFiles_DragDrop);
            this.listFiles.DragEnter += new System.Windows.Forms.DragEventHandler(this.listFiles_DragEnter);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(462, 260);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(93, 29);
            this.btnClear.TabIndex = 4;
            this.btnClear.Text = "&Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(568, 296);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.listFiles);
            this.Controls.Add(this.lnkForrest79);
            this.Controls.Add(this.lblHelp);
            this.Controls.Add(this.chkBackup);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "RemoveBOM";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkBackup;
        private System.Windows.Forms.Label lblHelp;
        private System.Windows.Forms.LinkLabel lnkForrest79;
        private System.Windows.Forms.ListBox listFiles;
        private System.Windows.Forms.Button btnClear;
    }
}

