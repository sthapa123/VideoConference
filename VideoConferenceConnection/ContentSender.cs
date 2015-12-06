using System;
using System.Threading;
using VideoConferenceCommon;
using VideoConferenceConnection.Interfaces;
using VideoConferenceObjects;
using VideoConferenceObjects.Interfaces;
using VideoConferenceUtils;
using VideoConferenceUtils.Audio;
using VideoConferenceUtils.Interfaces;
using VideoConferenceUtils.Video;

namespace VideoConferenceConnection
{
    /// <summary>
    /// Передатчик
    /// </summary>
    public class ContentSender : IContentSender
    {
        /// <summary>
        /// Получатель
        /// </summary>
        private Peer _peer;

        /// <summary>
        /// Поток, занимающийся отправкой
        /// </summary>
        private Thread _sendThread;
        
        /// <summary>
        /// 
        /// </summary>
        private IPackageCreator _packageCreator;

        public ContentSender(Peer peer, IPackageCreator creator)
        {
            _peer = peer;
            _packageCreator = creator;
        }

        /// <summary>
        /// Начать отправку аудио
        /// </summary>
        public void StartSending()
        {
            _sendThread = new Thread(Sending);
            _sendThread.Start();
        }

        /// <summary>
        /// Остановить отправку аудио
        /// </summary>
        public void StopSending()
        {
            if (_sendThread != null)
                _sendThread.Abort();
        }

        /// <summary>
        /// Процесс получения фрагмента и передачи его по сети
        /// </summary>
        private void Sending()
        {
            while (true)
            {
                var package = _packageCreator.GetPackage();
                if (package == null)
                {
                    Thread.Sleep(Constants.FragmentLenght);
                    continue;
                }
                
                //Отправляем информацию
                _peer.ContentReceiver.SendMessage(package, ConnectConfiguration.UserName);
                
                //Пока что тестирую локально, отправляю сразу в плеер
                //ContentPlayer.Instance.AddPackage(package);
            }
        }
    }
}
