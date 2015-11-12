using System.Windows.Forms;
using VideoConferenceUtils;

namespace VideoConference
{
    /// <summary>
    /// Главное окно программы
    /// </summary>
    public partial class MainForm : Form
    {
        #region Логгирование
        
        #endregion

        public MainForm()
        {
            InitializeComponent();
            FileHelper.RemoveFile("615616.txt");
            //log.Info("First_test");
        }
    }
}
