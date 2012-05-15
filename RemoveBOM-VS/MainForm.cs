using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

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
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            foreach (string file in files)
            {
                applyTo(file);
            }
        }

        private void readDirectory(string dirPath)
        {
            this.listFiles.Items.Add(dirPath + " [DIR]");

            string[] files = Directory.GetFiles(dirPath);

            foreach (string file in files)
            {
                applyTo(file);
            }

            string[] dirs = Directory.GetDirectories(dirPath);

            foreach (string dir in dirs)
            {
                applyTo(dir);
            }
        }

        private void applyTo(string file)
        {
            if (Directory.Exists(file))
            {
                readDirectory(file);
            }
            else if (File.Exists(file))
            {
                this.listFiles.Items.Add(file + " [" + removeBOMFromFile(file) + "]");
            }
            else
            {
                this.listFiles.Items.Add(file + " [ERROR]");
            }
        }

        private string removeBOMFromFile(string file)
        {
            FileStream read = File.OpenRead(file);

            byte[] bufferBOM = new byte[3];

            string info = "";

            int bomCount = read.Read(bufferBOM, 0, bufferBOM.Length);

            if (bomCount == 3)
            {
                if ((bufferBOM[0] == 239) && (bufferBOM[1] == 187) && (bufferBOM[2] == 191))
                {
                    byte[] buffer = new byte[1024];

                    FileStream write = File.OpenWrite(file + ".utf8");

                    int readCount = read.Read(buffer, 0, buffer.Length); ;

                    while (readCount > 0)
                    {
                        write.Write(buffer, 0, readCount);
                        readCount = read.Read(buffer, 0, buffer.Length);
                    }

                    write.Close();

                    read.Close();
                    
                    if (this.chkBackup.Checked)
                    {
                        System.IO.File.Move(file, file + ".bak");
                    }
                    else
                    {
                        System.IO.File.Delete(file);
                    }

                    System.IO.File.Move(file + ".utf8", file);

                    info = "BOM";
                }
                else
                {
                    read.Close();

                    info = "NO BOM";
                }
            }
            else
            {
                read.Close();

                info = "NO BOM";
            }

            return info;
        }

        private void lnkForrest79_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://forrest79.net");
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.listFiles.Items.Clear();
        }
    }
}
