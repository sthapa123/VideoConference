using System;
using System.Windows.Forms;
using NLog;
using VideoConferenceConnection;
using VideoConferenceConnection.Server;
using VideoConferenceGui.FormsLogic;
using VideoConferenceGui.Interfaces;
using VideoConferenceUtils;
using VideoConferenceUtils.Audio;
using VideoConferenceUtils.Video;

namespace VideoConferenceForms
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
            _presenter = new MainFormPresenter(this, AudioManager.Instance, VideoManager.Instance,
                ContentPlayer.Instance);
        }

        /// <summary>
        /// Событие загрузки формы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            this.Text = ConnectConfiguration.UserName + " " + ConnectConfiguration.Port;
            textBox1.Text = ConnectConfiguration.CurrentAddress().ToString();
            _presenter.StartRecording();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            AudioManager.Instance.Dispose();
            VideoManager.Instance.Dispose();
            ContentPlayer.Instance.Dispose();
            Application.Exit();
        }

        private void btnStartRecord_Click(object sender, EventArgs e)
        {
            _presenter.StartRecording();
        }

        private void btnStopRecord_Click(object sender, EventArgs e)
        {
            _presenter.StopRecord();
        }

        private void btnStartPlay_Click(object sender, EventArgs e)
        {
            _presenter.StartPlay(videoScreen1);
        }

        private void btnStopPlay_Click(object sender, EventArgs e)
        {
            _presenter.StopPlay();
        }

        private void btnStartServer_Click(object sender, EventArgs e)
        {
            //После откуда нибудь будет доставаться сервак
            _presenter.StartServer(new MainServer(ConnectConfiguration.Port, textBox1.Text));
        }

        private void btnStopServer_Click(object sender, EventArgs e)
        {
            _presenter.StopServer();
        }
    }
}
