using System;
using System.Net.Configuration;
using System.Windows.Forms;
using NLog;
using VideoConference.Interfaces;
using VideoConferenceConnection;
using VideoConferenceGui.FormsLogic;

namespace VideoConference
{
    /// <summary>
    /// Главное окно программы
    /// </summary>
    public partial class MainForm : Form , IMainForm
    {
        #region Логгирование
        private static Logger log = LogManager.GetCurrentClassLogger();
        #endregion

        private MainFormPresenter _presenter;
        
        public MainForm()
        {
            InitializeComponent();
            _presenter = new MainFormPresenter(this);
        }

        private void MainForm_Load(object sender, System.EventArgs e)
        {
            try
            {
                ConnectConfiguration con = new ConnectConfiguration(new ContentReceiver());
                
            }
            catch (Exception ex)
            {
                log.Error("MainForm_Load. Ошибка при начальной загрузке", ex);
                Application.Exit();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }
    }
}
