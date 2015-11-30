using System.Linq;
using NLog;
using VideoConference.Interfaces;
using VideoConferenceConnection;
using VideoConferenceConnection.Interfaces;
using VideoConferenceUtils;
using VideoConferenceUtils.Audio;

namespace VideoConferenceGui.FormsLogic
{
    public class MainFormPresenter
    {
        #region Логгирование
        private static Logger log = LogManager.GetCurrentClassLogger();
        #endregion

        private IPeersResolver _resolver;
        private IContentSender _sender;
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
            _resolver.ReloadPeers(RefreshPeersList);
        }

        public void StartRecording()
        {
            var peer = _resolver.Peers.First();
            _sender = new ContentSender(peer);
            AudioManager.Instance.StartAudioRecord(_sender);
        }
        
        /// <summary>
        /// Callback обновления списка
        /// </summary>
        private void RefreshPeersList()
        {
            _view.SetPeersList(_resolver.Peers);
        }
    }
}
