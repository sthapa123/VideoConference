using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NLog;
using VideoConferenceResources;

namespace VideoConferenceInitializer
{
    public partial class Splash : Form
    {
        #region Логгирование
        private static Logger log = LogManager.GetCurrentClassLogger();
        #endregion

        public Splash()
        {
            InitializeComponent();
        }

        private void Splash_Load(object sender, EventArgs e)
        {
            statusLabel.Text = ControlsConstants.SplashInicialization;
            var initializer = new Initializer();

            try
            {
                log.Info("asdasd");
                var result = initializer.Initialize();
                throw new Exception("Тест");
            }
            catch (Exception ex)
            {
                log.Fatal(ex, "Splash_Load. Ошибка во время инициализации! Приложение не может быть запущено.");
                //Application.Exit();
            }
        }
    }
}
