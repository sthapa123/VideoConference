using System;
using System.Linq;
using NLog;
using VideoConference.Interfaces;
using VideoConferenceCommon;
using VideoConferenceConnection;
using VideoConferenceConnection.Interfaces;
using VideoConferenceUtils;
using VideoConferenceUtils.Audio;
using VideoConferenceUtils.Video;

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
        /// Начать запись информации
        /// </summary>
        public void StartRecording()
        {
            AudioManager.Instance.StartRecord();
            VideoManager.Instance.StartRecord();
        }

        /// <summary>
        /// Начать передачу
        /// </summary>
        public void StartSending(IClient client)
        {
            //var peer = _resolver.Peers.First();
            //var peer = new Peer();
            var packageCreator = new PackageCreator(AudioManager.Instance, VideoManager.Instance);
            //_sender = new ContentSenderWcf(peer, packageCreator);
            _sender = new ContentSenderTls(packageCreator, client);
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
        /// <param name="e">Ошибка во время обновления</param>
        private void RefreshPeersList(Exception e)
        {
            if (e != null)
            {
                log.Error(e, "Ошибка во время обновления списка пиров");
            }
            _view.SetPeersList(_resolver.Peers);
        }
    }
}
