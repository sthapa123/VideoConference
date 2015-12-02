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

        /// <summary>
        /// Начать запись аудио
        /// </summary>
        public void StartRecording()
        {
            AudioManager.Instance.StartAudioRecord();
        }

        /// <summary>
        /// Начать передачу аудио
        /// </summary>
        public void StartSending()
        {
            var peer = _resolver.Peers.First();
            var packageCreator = new PackageCreator(AudioManager.Instance);
            _sender = new ContentSender(peer, packageCreator);
            _sender.StartSending();
        }

        /// <summary>
        /// Остановить передачуи запись
        /// </summary>
        public void StopRecordAndSending()
        {
            if (_sender != null)
                _sender.StopSending();
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
