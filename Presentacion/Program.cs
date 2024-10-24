using System;
using System.Windows.Forms;


namespace Presentacion
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                Application.Run(new MenuPrincipal());
            }
            catch (MissingMethodException ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
                // Handle the exception as needed
            }
            
        }
    }
}
