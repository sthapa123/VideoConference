using System;
using System.Net.Configuration;
using System.Windows.Forms;
using NLog;
using VideoConferenceConnection;

namespace VideoConference
{
    /// <summary>
    /// Главное окно программы
    /// </summary>
    public partial class MainForm : Form
    {
        #region Логгирование
        private static Logger log = LogManager.GetCurrentClassLogger();
        #endregion

        private ConnectConfiguration con;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, System.EventArgs e)
        {
            try
            {
                var receiver = new ContentReceiver(textBox1);
                con = new ConnectConfiguration(receiver);
                button1.Text = con._userName;
            }
            catch (Exception ex)
            {
                log.Error("MainForm_Load. Ошибка при начальной загрузке", ex);
                Application.Exit();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.ReloadPeers();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.SendMessage(textBox2.Text);
            textBox1.Text += "\n " + sender + ": " + textBox2.Text;
            textBox2.Clear();
        }
    }
}
