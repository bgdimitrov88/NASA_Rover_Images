using NASA_Rover_Images.Unity;
using Microsoft.Practices.Unity;
using System;
using System.Windows.Forms;
using NASA_Rover_Images.Views;

namespace NASA_Rover_Images
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.ApplicationExit += OnExit;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(UnityConfig.GetConfiguredContainer().Resolve<MainForm>());
        }

        private static void OnExit(object sender, EventArgs e)
        {
            UnityConfig.GetConfiguredContainer().Dispose();
        }
    }
}
