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
            this.lblInfo = new System.Windows.Forms.Label();
            this.rbRemoveBOM = new System.Windows.Forms.RadioButton();
            this.rbTestBOM = new System.Windows.Forms.RadioButton();
            this.panelList = new System.Windows.Forms.Panel();
            this.rbListBOMFiles = new System.Windows.Forms.RadioButton();
            this.rbListAllFiles = new System.Windows.Forms.RadioButton();
            this.btnClearList = new System.Windows.Forms.Button();
            this.lblBOMFiles = new System.Windows.Forms.Label();
            this.lblBOMFilesCount = new System.Windows.Forms.Label();
            this.lblExtension = new System.Windows.Forms.Label();
            this.txtExtension = new System.Windows.Forms.TextBox();
            this.chkAlwayOnTop = new System.Windows.Forms.CheckBox();
            this.pbWorking = new System.Windows.Forms.PictureBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.rtbFiles = new System.Windows.Forms.RichTextBox();
            this.panelList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbWorking)).BeginInit();
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
            this.chkBackup.TabIndex = 5;
            this.chkBackup.Text = "&Make backup";
            this.chkBackup.UseVisualStyleBackColor = true;
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblInfo.Location = new System.Drawing.Point(12, 9);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(451, 13);
            this.lblInfo.TabIndex = 11;
            this.lblInfo.Text = "Drag files or directories to the list to remove/test BOM header from UTF-8 files";
            // 
            // rbRemoveBOM
            // 
            this.rbRemoveBOM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rbRemoveBOM.AutoSize = true;
            this.rbRemoveBOM.Checked = true;
            this.rbRemoveBOM.Location = new System.Drawing.Point(15, 307);
            this.rbRemoveBOM.Name = "rbRemoveBOM";
            this.rbRemoveBOM.Size = new System.Drawing.Size(92, 17);
            this.rbRemoveBOM.TabIndex = 4;
            this.rbRemoveBOM.TabStop = true;
            this.rbRemoveBOM.Text = "&Remove BOM";
            this.rbRemoveBOM.UseVisualStyleBackColor = true;
            // 
            // rbTestBOM
            // 
            this.rbTestBOM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rbTestBOM.AutoSize = true;
            this.rbTestBOM.Location = new System.Drawing.Point(15, 330);
            this.rbTestBOM.Name = "rbTestBOM";
            this.rbTestBOM.Size = new System.Drawing.Size(73, 17);
            this.rbTestBOM.TabIndex = 6;
            this.rbTestBOM.TabStop = true;
            this.rbTestBOM.Text = "&Test BOM";
            this.rbTestBOM.UseVisualStyleBackColor = true;
            // 
            // panelList
            // 
            this.panelList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panelList.Controls.Add(this.rbListBOMFiles);
            this.panelList.Controls.Add(this.rbListAllFiles);
            this.panelList.Controls.Add(this.btnClearList);
            this.panelList.Location = new System.Drawing.Point(346, 303);
            this.panelList.Name = "panelList";
            this.panelList.Size = new System.Drawing.Size(226, 59);
            this.panelList.TabIndex = 11;
            // 
            // rbListBOMFiles
            // 
            this.rbListBOMFiles.AutoSize = true;
            this.rbListBOMFiles.Checked = true;
            this.rbListBOMFiles.Location = new System.Drawing.Point(3, 9);
            this.rbListBOMFiles.Name = "rbListBOMFiles";
            this.rbListBOMFiles.Size = new System.Drawing.Size(111, 17);
            this.rbListBOMFiles.TabIndex = 7;
            this.rbListBOMFiles.TabStop = true;
            this.rbListBOMFiles.Text = "List &BOM files only";
            this.rbListBOMFiles.UseVisualStyleBackColor = true;
            // 
            // rbListAllFiles
            // 
            this.rbListAllFiles.AutoSize = true;
            this.rbListAllFiles.Location = new System.Drawing.Point(3, 32);
            this.rbListAllFiles.Name = "rbListAllFiles";
            this.rbListAllFiles.Size = new System.Drawing.Size(75, 17);
            this.rbListAllFiles.TabIndex = 8;
            this.rbListAllFiles.TabStop = true;
            this.rbListAllFiles.Text = "List &all files";
            this.rbListAllFiles.UseVisualStyleBackColor = true;
            // 
            // btnClearList
            // 
            this.btnClearList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearList.Location = new System.Drawing.Point(130, 3);
            this.btnClearList.Name = "btnClearList";
            this.btnClearList.Size = new System.Drawing.Size(93, 53);
            this.btnClearList.TabIndex = 9;
            this.btnClearList.Text = "Clear &list";
            this.btnClearList.UseVisualStyleBackColor = true;
            this.btnClearList.Click += new System.EventHandler(this.btnClearList_Click);
            // 
            // lblBOMFiles
            // 
            this.lblBOMFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBOMFiles.AutoSize = true;
            this.lblBOMFiles.Location = new System.Drawing.Point(346, 287);
            this.lblBOMFiles.Name = "lblBOMFiles";
            this.lblBOMFiles.Size = new System.Drawing.Size(55, 13);
            this.lblBOMFiles.TabIndex = 10;
            this.lblBOMFiles.Text = "BOM files:";
            // 
            // lblBOMFilesCount
            // 
            this.lblBOMFilesCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBOMFilesCount.AutoSize = true;
            this.lblBOMFilesCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblBOMFilesCount.Location = new System.Drawing.Point(407, 287);
            this.lblBOMFilesCount.Name = "lblBOMFilesCount";
            this.lblBOMFilesCount.Size = new System.Drawing.Size(14, 13);
            this.lblBOMFilesCount.TabIndex = 9;
            this.lblBOMFilesCount.Text = "0";
            this.lblBOMFilesCount.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblExtension
            // 
            this.lblExtension.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblExtension.AutoSize = true;
            this.lblExtension.Location = new System.Drawing.Point(16, 276);
            this.lblExtension.Name = "lblExtension";
            this.lblExtension.Size = new System.Drawing.Size(56, 13);
            this.lblExtension.TabIndex = 10;
            this.lblExtension.Text = "Extension:";
            // 
            // txtExtension
            // 
            this.txtExtension.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtExtension.Location = new System.Drawing.Point(78, 273);
            this.txtExtension.Name = "txtExtension";
            this.txtExtension.Size = new System.Drawing.Size(54, 20);
            this.txtExtension.TabIndex = 3;
            // 
            // chkAlwayOnTop
            // 
            this.chkAlwayOnTop.AutoSize = true;
            this.chkAlwayOnTop.Location = new System.Drawing.Point(480, 8);
            this.chkAlwayOnTop.Name = "chkAlwayOnTop";
            this.chkAlwayOnTop.Size = new System.Drawing.Size(92, 17);
            this.chkAlwayOnTop.TabIndex = 0;
            this.chkAlwayOnTop.Text = "Always &on top";
            this.chkAlwayOnTop.UseVisualStyleBackColor = true;
            this.chkAlwayOnTop.CheckedChanged += new System.EventHandler(this.chkAlwayOnTop_CheckedChanged);
            // 
            // pbWorking
            // 
            this.pbWorking.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pbWorking.Image = global::RemoveBOM.Properties.Resources.Loading;
            this.pbWorking.Location = new System.Drawing.Point(484, 263);
            this.pbWorking.Name = "pbWorking";
            this.pbWorking.Size = new System.Drawing.Size(20, 18);
            this.pbWorking.TabIndex = 13;
            this.pbWorking.TabStop = false;
            this.pbWorking.Visible = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(507, 260);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(62, 24);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Visible = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // rtbFiles
            // 
            this.rtbFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbFiles.Location = new System.Drawing.Point(17, 29);
            this.rtbFiles.Name = "rtbFiles";
            this.rtbFiles.Size = new System.Drawing.Size(555, 231);
            this.rtbFiles.TabIndex = 1;
            this.rtbFiles.Text = "";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 366);
            this.Controls.Add(this.rtbFiles);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.pbWorking);
            this.Controls.Add(this.chkAlwayOnTop);
            this.Controls.Add(this.txtExtension);
            this.Controls.Add(this.lblExtension);
            this.Controls.Add(this.lblBOMFilesCount);
            this.Controls.Add(this.lblBOMFiles);
            this.Controls.Add(this.panelList);
            this.Controls.Add(this.rbTestBOM);
            this.Controls.Add(this.rbRemoveBOM);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.chkBackup);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(600, 400);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RemoveBOM";
            this.TopMost = true;
            this.panelList.ResumeLayout(false);
            this.panelList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbWorking)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkBackup;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.RadioButton rbRemoveBOM;
        private System.Windows.Forms.RadioButton rbTestBOM;
        private System.Windows.Forms.Panel panelList;
        private System.Windows.Forms.Button btnClearList;
        private System.Windows.Forms.RadioButton rbListBOMFiles;
        private System.Windows.Forms.RadioButton rbListAllFiles;
        private System.Windows.Forms.Label lblBOMFiles;
        private System.Windows.Forms.Label lblBOMFilesCount;
        private System.Windows.Forms.Label lblExtension;
        private System.Windows.Forms.TextBox txtExtension;
        private System.Windows.Forms.CheckBox chkAlwayOnTop;
        private System.Windows.Forms.PictureBox pbWorking;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.RichTextBox rtbFiles;
    }
}

