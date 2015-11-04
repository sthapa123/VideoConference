using System;
using System.Windows.Forms;
using NLog;

namespace VideoConference
{
    static class StartPoint
    {
        #region Логгирование
        private static Logger log = LogManager.GetCurrentClassLogger();
        #endregion

        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (log.IsInfoEnabled) log.Info("Application start");
            Application.Run(new MainForm());        
        }
    }
}
