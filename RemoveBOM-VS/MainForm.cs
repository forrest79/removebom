using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace RemoveBOM
{
    /// <summary>
    /// RemoveBOM main form.
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// RemoveBOM class.
        /// </summary>
        private RemoveBOM removeBOM;
        
        /// <summary>
        /// RemoveBOM worker thread.
        /// </summary>
        private Thread removeThread;

        /// <summary>
        /// Delegate callback for calling from another thread to set controls properties.
        /// </summary>
        public delegate void SetCallback();

        /// <summary>
        /// Delegate callback for calling from another thread to append text.
        /// </summary>
        /// <param name="text">Text.</param>
        /// <param name="color">Text color.</param>
        public delegate void AppendTextCallback(string text, Color color);

        /// <summary>
        /// Delegate callback for calling from another thread to add file.
        /// </summary>
        /// <param name="text">Text.</param>
        /// <param name="hasBOM">Has file BOM header.</param>
        public delegate void AddFileCallback(string text, bool hasBOM);

        /// <summary>
        /// Count BOM files.
        /// </summary>
        private int countBOMFiles;

        /// <summary>
        /// Constructor.
        /// </summary>
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

        /// <summary>
        /// Drag files enter.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Drag files drop.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Cancel thread button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (removeBOM != null)
            {
                removeBOM.Cancel();
                removeThread.Join();
                
                Stop();
                removeThread = null;
            }
        }

        /// <summary>
        /// Clear list button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClearList_Click(object sender, EventArgs e)
        {
            rtbFiles.Text = "";
            lblBOMFilesCount.Text = "0";
            countBOMFiles = 0;
        }

        /// <summary>
        /// Always on top checkbox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkAlwayOnTop_CheckedChanged(object sender, EventArgs e)
        {
            TopMost = chkAlwayOnTop.Checked;
        }

        /// <summary>
        /// Set checkbox start state.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            chkAlwayOnTop.Checked = TopMost;
        }

        /// <summary>
        /// Form closing.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (removeBOM != null)
            {
                if (MessageBox.Show("Removing is in progress. Cancel it?", "Cancel removing?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (removeBOM != null)
                    {
                        removeBOM.Cancel();
                        removeThread.Join();
                    }
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

        /// <summary>
        /// Add file to list.
        /// </summary>
        /// <param name="text">Text.</param>
        /// <param name="hasBOM">Has BOM header.</param>
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

        /// <summary>
        /// Add directory to list.
        /// </summary>
        /// <param name="text">Text.</param>
        public void AddDirectory(string text)
        {
            if (rbListAllFiles.Checked)
            {
                AppendText(text, Color.Blue);
            }
        }

        /// <summary>
        /// Add error to list.
        /// </summary>
        /// <param name="text">Text.</param>
        public void AddError(string text)
        {
            AppendText(text, Color.Red);
        }

        /// <summary>
        /// Set removing is running.
        /// </summary>
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

        /// <summary>
        /// Set removing is stopped.
        /// </summary>
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

        /// <summary>
        /// Append text to list.
        /// </summary>
        /// <param name="text">Text.</param>
        /// <param name="color">Text color.</param>
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

                rtbFiles.SelectionStart = rtbFiles.Text.Length;
                rtbFiles.ScrollToCaret();
            }
        }
    }
}
