using System;
using System.Windows.Forms;
using Codes.Views;

namespace Codes
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MatrixCreationForm());
        }
    }

    public static class Settings
    {
        public static int M { get; set; }
        public static int R { get; set; }
    }
}
