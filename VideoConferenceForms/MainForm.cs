using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Configuration;
using System.Windows.Forms;
using AForge.Video;
using NLog;
using VideoConference.Interfaces;
using VideoConferenceCommon;
using VideoConferenceConnection;
using VideoConferenceConnection.Client;
using VideoConferenceConnection.Interfaces;
using VideoConferenceConnection.Server;
using VideoConferenceGui.FormsLogic;
using VideoConferenceUtils;
using VideoConferenceUtils.Audio;
using VideoConferenceUtils.Interfaces;
using VideoConferenceUtils.Video;

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

        private IMainServer server;

        private IClient client;
        
        public MainForm()
        {
            InitializeComponent();
            _presenter = new MainFormPresenter(this, PeersResolver.Instance);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.Text = ConnectConfiguration.UserName + " " + ConnectConfiguration.Port;
            ContentPlayer.Instance.StartPlay(pictureBox1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _presenter.ResolvePeers();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            AudioManager.Instance.Dispose();
            VideoManager.Instance.Dispose();
            ContentPlayer.Instance.Dispose();
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
            _presenter.StartSending(client);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            _presenter.StopRecordAndSending();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (server != null && server.IsRunning)
            {
                server.StopServer();
                button5.Text = "Запустить сервер";
                return;
            }

            try
            {
                if (server == null)
                    server = new MainServer(ConnectConfiguration.Port, textBox1.Text);
                server.RunServer();
                button5.Text = "Остановить сервер";
            }
            catch (Exception ex)
            {
                var message = String.Format("Во время запуска сервера произошла ошибка: {0}", ex.Message);
                log.Fatal(ex, message);
                MessageBox.Show(message);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {

            client = new Client(ConnectConfiguration.Port, IPAddress.Parse(textBox1.Text));

            try
            {
                client.StartConnect();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Во время подключения к серверу произошла ошибка: ", ex.Message);
            }

        }
    }
}
