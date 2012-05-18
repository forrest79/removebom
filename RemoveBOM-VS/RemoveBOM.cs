using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace RemoveBOM
{
    class RemoveBOM
    {
        public const string EXTENSION_ALL = "*";

        private MainForm form;

        private string[] paths;

        private string extension;

        private bool test;

        private bool backup;

        private volatile bool cancel;

        public RemoveBOM(MainForm form)
        {
            this.form = form;
            this.test = false;
            this.backup = false;
        }

        public void SetPaths(string[] paths)
        {
            this.paths = paths;
        }

        public void SetExtension(string extension)
        {
            if (!extension.StartsWith("."))
            {
                extension = "." + extension;
            }

            this.extension = extension;
        }

        public void SetTest()
        {
            this.test = true;
        }

        public void SetRemove()
        {
            this.test = false;
        }

        public void SetMakeBackup(bool makeBackup)
        {
            this.backup = makeBackup;
        }

        public void Execute()
        {
            form.Running();

            cancel = false;

            foreach (string path in paths)
            {
                checkPath(path);
            }

            form.Stop();
        }

        public void Cancel()
        {
            // TODO cancel
            cancel = true;
        }

        private void checkPath(string file)
        {
            if (Directory.Exists(file))
            {
                readDirectory(file);
            }
            else if (File.Exists(file))
            {
                Console.WriteLine(Path.GetExtension(file));
                if (extension.Equals(EXTENSION_ALL) || extension.ToLower().Equals(Path.GetExtension(file).ToLower()))
                {
                    if (removeBOM(file))
                    {
                        form.AddFile(file + " [" + (test ? "INCLUDES" : "REMOVE") + " BOM]", true);
                    }
                    else
                    {
                        form.AddFile(file + " [NO BOM]", false);
                    }
                }
            }
            else
            {
                form.AddError(file + " [ERROR]");
            }
        }

        private void readDirectory(string dirPath)
        {
            form.AddDirectory(dirPath + " [DIR]");

            string[] files = Directory.GetFiles(dirPath);

            foreach (string file in files)
            {
                checkPath(file);
            }

            string[] dirs = Directory.GetDirectories(dirPath);

            foreach (string dir in dirs)
            {
                checkPath(dir);
            }
        }

        private bool removeBOM(string file)
        {
            bool foundBOM = false;

            byte[] headerBOM = new byte[3];

            FileStream fileReader = File.OpenRead(file);

            int bomCount = fileReader.Read(headerBOM, 0, headerBOM.Length);

            if ((bomCount == 3) && (headerBOM[0] == 239) && (headerBOM[1] == 187) && (headerBOM[2] == 191))
            {
                foundBOM = true;

                if (!test)
                {
                    byte[] buffer = new byte[1024];

                    FileStream write = File.OpenWrite(file + ".utf8");

                    int readCount = fileReader.Read(buffer, 0, buffer.Length); ;

                    while (readCount > 0)
                    {
                        write.Write(buffer, 0, readCount);
                        readCount = fileReader.Read(buffer, 0, buffer.Length);
                    }

                    write.Close();

                    fileReader.Close();

                    if (backup)
                    {
                        // TODO check backup
                        System.IO.File.Move(file, file + ".bak");
                    }
                    else
                    {
                        System.IO.File.Delete(file);
                    }

                    // TODO better rename solution
                    System.IO.File.Move(file + ".utf8", file);
                }
            }

            fileReader.Close();

            return foundBOM;
        }
    }
}
