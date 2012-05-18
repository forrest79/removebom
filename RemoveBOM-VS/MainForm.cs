using System;
using System.Windows.Forms;
using System.Threading;
using System.Drawing;

namespace RemoveBOM
{
    public partial class MainForm : Form
    {
        private RemoveBOM removeBOM;
        
        private Thread removeThread;

        public delegate void SetCallback();

        public delegate void AppendTextCallback(string text, Color color);

        public delegate void AddFileCallback(string text, bool hasBOM);

        private int countBOMFiles;

        public MainForm()
        {
            InitializeComponent();
            removeBOM = null;
            countBOMFiles = 0;
            rtbFiles.AllowDrop = true;
            rtbFiles.DragEnter += new DragEventHandler(rtbFiles_DragEnter);
            rtbFiles.DragDrop += new DragEventHandler(rtbFiles_DragDrop);
            txtExtension.Text = RemoveBOM.EXTENSION_ALL;
        }

        private void rtbFiles_DragEnter(object sender, DragEventArgs e)
        {
            if (removeBOM == null)
            {
                if (e.Data.GetDataPresent(DataFormats.FileDrop, false))
                {
                    e.Effect = DragDropEffects.All;
                }
            }
        }

        private void rtbFiles_DragDrop(object sender, DragEventArgs e)
        {
            if (removeBOM == null)
            {
                string[] paths = (string[])e.Data.GetData(DataFormats.FileDrop);

                removeBOM = new RemoveBOM(this);
                removeBOM.SetPaths(paths);
                removeBOM.SetExtension(txtExtension.Text);
                if (rbRemoveBOM.Checked)
                {
                    removeBOM.SetRemove();
                    removeBOM.SetMakeBackup(chkBackup.Checked);
                }
                else
                {
                    removeBOM.SetTest();
                }

                removeThread = new Thread(removeBOM.Execute);
                removeThread.Start();
            }
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (removeBOM != null)
            {
                removeBOM.Cancel();
            }
        }

        private void btnClearList_Click(object sender, EventArgs e)
        {
            rtbFiles.Text = "";
            lblBOMFilesCount.Text = "0";
            countBOMFiles = 0;
        }

        private void chkAlwayOnTop_CheckedChanged(object sender, EventArgs e)
        {
            TopMost = chkAlwayOnTop.Checked;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            chkAlwayOnTop.Checked = TopMost;
        }

        public void AddFile(string text, bool hasBOM)
        {
            if (lblBOMFilesCount.InvokeRequired)
            {
                AddFileCallback callback = new AddFileCallback(AddFile);
                this.Invoke(callback, new Object[] { text, hasBOM });
            }
            else
            {
                if (hasBOM)
                {
                    countBOMFiles++;
                    lblBOMFilesCount.Text = countBOMFiles.ToString();
                }

                if (rbListAllFiles.Checked || (hasBOM))
                {
                    AppendText(text, hasBOM ? Color.Orange : Color.Green);
                }
            }
        }

        public void AddDirectory(string text)
        {
            if (rbListAllFiles.Checked)
            {
                AppendText(text, Color.Blue);
            }
        }

        public void AddError(string text)
        {
            AppendText(text, Color.Red);
        }

        public void Running()
        {
            if (pbWorking.InvokeRequired)
            {
                SetCallback callback = new SetCallback(Running);
                this.Invoke(callback);
            }
            else
            {
                pbWorking.Visible = true;
                btnCancel.Visible = true;

                chkBackup.Enabled = false;
                rbRemoveBOM.Enabled = false;
                rbTestBOM.Enabled = false;
                btnClearList.Enabled = false;
                rbListBOMFiles.Enabled = false;
                rbListAllFiles.Enabled = false;
                txtExtension.Enabled = false;
            }
        }

        public void Stop()
        {
            if (pbWorking.InvokeRequired)
            {
                SetCallback callback = new SetCallback(Stop);
                this.Invoke(callback);
            }
            else
            {
                pbWorking.Visible = false;
                btnCancel.Visible = false;

                chkBackup.Enabled = true;
                rbRemoveBOM.Enabled = true;
                rbTestBOM.Enabled = true;
                btnClearList.Enabled = true;
                rbListBOMFiles.Enabled = true;
                rbListAllFiles.Enabled = true;
                txtExtension.Enabled = true;

                removeBOM = null;
            }
        }

        private void AppendText(string text, Color color)
        {
            if (rtbFiles.InvokeRequired)
            {
                AppendTextCallback callback = new AppendTextCallback(AppendText);
                this.Invoke(callback, new Object[] { text, color });
            }
            else
            {
                rtbFiles.SelectionStart = rtbFiles.TextLength;
                rtbFiles.SelectionLength = 0;

                rtbFiles.SelectionColor = color;
                rtbFiles.AppendText(text);
                rtbFiles.SelectionColor = rtbFiles.ForeColor;
                rtbFiles.AppendText(Environment.NewLine);
            }
        }
    }
}
