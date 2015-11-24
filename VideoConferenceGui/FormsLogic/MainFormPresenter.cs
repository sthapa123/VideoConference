using NLog;
using VideoConference.Interfaces;
using VideoConferenceConnection.Interfaces;
using VideoConferenceUtils;

namespace VideoConferenceGui.FormsLogic
{
    public class MainFormPresenter
    {
        #region Логгирование
        private static Logger log = LogManager.GetCurrentClassLogger();
        #endregion

        private IPeersResolver _resolver;
        private IMainForm _view;

        public MainFormPresenter(IMainForm mainForm, IPeersResolver resolver)
        {
            _view = mainForm;
            _resolver = resolver;
        }

        /// <summary>
        /// Обновить список пиров
        /// </summary>
        public void ResolvePeers()
        {
            var callback = new VoidCallback(RefreshPeersList);
            _resolver.ReloadPeers(callback);
        }

        private void RefreshPeersList()
        {
            _view.SetPeersList(_resolver.Peers);
        }
    }
}
