using System;
using System.Collections.Generic;
using System.Net.Configuration;
using System.Windows.Forms;
using NLog;
using VideoConference.Interfaces;
using VideoConferenceConnection;
using VideoConferenceConnection.Interfaces;
using VideoConferenceGui.FormsLogic;
using VideoConferenceUtils.Audio;
using VideoConferenceUtils.Interfaces;

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
            _presenter = new MainFormPresenter(this, PeersResolver.Instance);
        }

        private void MainForm_Load(object sender, System.EventArgs e)
        {
            this.Text = ConnectConfiguration.UserName + " " + ConnectConfiguration.Port;
            AudioManager.Instance.StartAudioPlay();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _presenter.ResolvePeers();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            AudioManager.Instance.Dispose();
            Application.Exit();
        }

        /// <summary>
        /// Обновить список получателей
        /// </summary>
        /// <param name="peers">Список</param>
        public void SetPeersList(IEnumerable<Peer> peers)
        {
            listView1.Items.Clear();
            foreach (var peer in peers)
            {
                var name = peer.ContentReceiver.GetName();
                var item = new ListViewItem { Name = name, Text = name };
                listView1.Items.Add(item);
            }
        }
        
        /// <summary>
        /// Начать запись
        /// </summary>
        private void button2_Click(object sender, EventArgs e)
        {
            _presenter.StartRecording();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            _presenter.StartSending();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            _presenter.StopRecordAndSending();
        }
    }
}
