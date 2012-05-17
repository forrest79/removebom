using System;
using System.Windows.Forms;

namespace RemoveBOM
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void listFiles_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false))
            {
                e.Effect = DragDropEffects.All;
            }
        }

        private void listFiles_DragDrop(object sender, DragEventArgs e)
        {
            string[] paths = (string[])e.Data.GetData(DataFormats.FileDrop);

            RemoveBOM removeBOM = new RemoveBOM(this);
            removeBOM.SetPaths(paths);
            // Create thread a run
        }

        private void btnClearList_Click(object sender, EventArgs e)
        {
            this.listFiles.Items.Clear();
            this.lblBOMFiles.Text = "0";
        }

        private void chkAlwayOnTop_CheckedChanged(object sender, EventArgs e)
        {
            TopMost = chkAlwayOnTop.Checked;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            chkAlwayOnTop.Checked = TopMost;
        }

        public void AddFileClear(string file)
        {
        }

        public void AddFileBOM(string file)
        {
        }

        public void AddFileError(string file)
        {
        }

        private void AddFile(string file, Color color)
        {
        }

        public void Running()
        {
        }

        public void Stop()
        {
        }

    }
}
