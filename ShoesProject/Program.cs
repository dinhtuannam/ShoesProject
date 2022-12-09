using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ShoesProject
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.sasaasas
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run( new Home("tuannam"));
        }
    }
}
