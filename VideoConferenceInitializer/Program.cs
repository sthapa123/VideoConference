using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace VideoConferenceInitializer
{
    static class Program
    {
        
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            var splash = new Splash();
            splash.Shown += splash_Shown;

            Application.Run(splash);
        }

        private static void splash_Shown(object sender, EventArgs e)
        {
            var initializer = new Initializer((Splash)sender);
            initializer.Initialize();
        }
    }
}
