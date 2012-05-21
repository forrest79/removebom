using System;
using System.IO;

namespace RemoveBOM
{
    /// <summary>
    /// RemoveBOM class.
    /// </summary>
    public class RemoveBOM
    {
        /// <summary>
        /// Extension for all files.
        /// </summary>
        public const string EXTENSION_ALL = "*";

        /// <summary>
        /// Program form.
        /// </summary>
        private MainForm form;

        /// <summary>
        /// Paths to execute.
        /// </summary>
        private string[] paths;

        /// <summary>
        /// Extension filter.
        /// </summary>
        private string extension;

        /// <summary>
        /// Test BOM only.
        /// </summary>
        private bool test;

        /// <summary>
        /// Make backup file.
        /// </summary>
        private bool backup;

        /// <summary>
        /// Cancel execution.
        /// </summary>
        private volatile bool cancel;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="form">Program form.</param>
        public RemoveBOM(MainForm form)
        {
            this.form = form;
            this.test = false;
            this.backup = false;
        }

        /// <summary>
        /// Set paths to execute.
        /// </summary>
        /// <param name="paths">Paths to execute.</param>
        public void SetPaths(string[] paths)
        {
            this.paths = paths;
        }

        /// <summary>
        /// Set extension filter.
        /// </summary>
        /// <param name="extension">Extension filter (with or without starting ".")</param>
        public void SetExtension(string extension)
        {
            if (extension.Length == 0)
            {
                extension = EXTENSION_ALL;
            }
            else if (!extension.Equals(EXTENSION_ALL) && !extension.StartsWith("."))
            {
                extension = "." + extension;
            }

            this.extension = extension;
        }

        /// <summary>
        /// Set testing BOM only.
        /// </summary>
        public void SetTest()
        {
            this.test = true;
        }

        /// <summary>
        /// Set remove BOM.
        /// </summary>
        public void SetRemove()
        {
            this.test = false;
        }

        /// <summary>
        /// Set make backup file if remove BOM.
        /// </summary>
        /// <param name="makeBackup">Make backup Yes=true, No=false.</param>
        public void SetMakeBackup(bool makeBackup)
        {
            this.backup = makeBackup;
        }

        /// <summary>
        /// Start execution.
        /// </summary>
        public void Execute()
        {
            form.Running();

            cancel = false;

            foreach (string path in paths)
            {
                if (cancel)
                {
                    break;
                }

                checkPath(path);
            }

            form.Stop();
        }

        /// <summary>
        /// Cancel execution.
        /// </summary>
        public void Cancel()
        {
            cancel = true;
        }

        /// <summary>
        /// Check path for files and directories.
        /// </summary>
        /// <param name="path">Path to check.</param>
        private void checkPath(string path)
        {
            Console.WriteLine(path);
            if (cancel)
            {
                return;
            }

            if (Directory.Exists(path))
            {
                form.AddDirectory(path + " [DIR]");

                string[][] paths = new string[2][] { Directory.GetFiles(path), Directory.GetDirectories(path) };

                foreach (string[] files in paths)
                {
                    foreach (string file in files)
                    {
                        if (cancel)
                        {
                            return;
                        }

                        checkPath(file);
                    }
                }

            }
            else if (File.Exists(path))
            {
                if (extension.Equals(EXTENSION_ALL) || extension.ToLower().Equals(Path.GetExtension(path).ToLower()))
                {
                    if (removeBOM(path))
                    {
                        form.AddFile(path + " [" + (test ? "INCLUDE" : "REMOVED") + " BOM]", true);
                    }
                    else
                    {
                        form.AddFile(path + " [NO BOM]", false);
                    }
                }
            }
            else
            {
                form.AddError(path + " [ERROR]");
            }
        }

        /// <summary>
        /// Remove BOM from file.
        /// </summary>
        /// <param name="file">File to remove BOM.</param>
        /// <returns>File has BOM header (Yes=true, No=false).</returns>
        private bool removeBOM(string file)
        {
            bool foundBOM = false;
            byte[] headerBOM = new byte[3];
            FileStream fileReader = null;
            FileStream fileWriter = null;

            try
            {
                fileReader = File.OpenRead(file);

                int bomCount = fileReader.Read(headerBOM, 0, headerBOM.Length);

                if ((bomCount == 3) && (headerBOM[0] == 239) && (headerBOM[1] == 187) && (headerBOM[2] == 191))
                {
                    foundBOM = true;

                    if (!test)
                    {
                        byte[] buffer = new byte[1024];

                        string fileRemovedBOM = findFreeFilename(file, "removedbom");
                        fileWriter = File.OpenWrite(fileRemovedBOM);

                        int readCount = 0;
                        do
                        {
                            readCount = fileReader.Read(buffer, 0, buffer.Length);
                            fileWriter.Write(buffer, 0, readCount);
                        } while (readCount > 0);

                        fileWriter.Close();
                        fileWriter = null;

                        fileReader.Close();
                        fileReader = null;

                        if (backup)
                        {
                            File.Move(file, findFreeFilename(file, "removebom.bak"));
                        }
                        else
                        {
                            File.Delete(file);
                        }

                        File.Move(fileRemovedBOM, file);
                    }
                }
            }
            catch (Exception e)
            {
                form.AddError(file + " [ERROR: " + e.Message + "]");
            }
            finally
            {
                if (fileWriter != null)
                {
                    fileWriter.Close();
                }

                if (fileReader != null)
                {
                    fileReader.Close();
                }
            }


            return foundBOM;
        }

        /// <summary>
        /// Find free filename for file and extension.
        /// </summary>
        /// <param name="file">File.</param>
        /// <param name="extension">Extension without starting ".".</param>
        /// <returns>Free filename.</returns>
        private string findFreeFilename(string file, string extension)
        {
            string backupFile = file + "." + extension;

            if (File.Exists(backupFile))
            {
                int i = 1;
                do
                {
                    backupFile = file + "." + i.ToString() + "." + extension;
                    i++;
                } while (File.Exists(backupFile));
            }

            return backupFile;
        }
    }
}
