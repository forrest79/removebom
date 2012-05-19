using System;
using System.Windows.Forms;

namespace RemoveBOM
{
    /// <summary>
    /// RemoveBOM startup.
    /// </summary>
    static class Program
    {
        /// <summary>
        /// RemoveBOM main function.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
