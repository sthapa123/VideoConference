using NLog;
using VideoConference.Interfaces;

namespace VideoConferenceGui.FormsLogic
{
    public class MainFormPresenter
    {
        #region Логгирование
        private static Logger log = LogManager.GetCurrentClassLogger();
        #endregion

        private IMainForm _view;

        public MainFormPresenter(IMainForm mainForm)
        {
            _view = mainForm;
        }
    }
}
