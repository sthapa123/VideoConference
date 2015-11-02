using System.Windows.Forms;
using VideoConferenceUtils;
using VideoConferenceUtils.Interfaces;

namespace VideoConference
{
    /// <summary>
    /// Главное окно программы
    /// </summary>
    public partial class MainForm : Form
    {
        //ILogHelper log = new LogHelper("MainForm");

        public MainForm()
        {
            InitializeComponent();
            //log.Info("Конструктор");
        }
    }
}
