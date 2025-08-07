using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoftlightMF
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Login());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Application startup error bypassed: " + ex.Message + "\n\nTrying to continue...", "Startup Error");
                // Try to continue anyway - the app might still work
                try 
                {
                    Application.Run(new Login());
                }
                catch
                {
                    MessageBox.Show("Could not start application. Please check database configuration.", "Error");
                }
            }
        }
    }
}
