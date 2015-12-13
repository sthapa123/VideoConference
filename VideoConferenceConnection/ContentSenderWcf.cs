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
    /// Передатчик информации WCF
    /// </summary>
    public class ContentSenderWcf : BaseSender
    {
        /// <summary>
        /// Получатель
        /// </summary>
        private readonly Peer _peer;
        
        public ContentSenderWcf(Peer peer, IPackageCreator creator) : base(creator)
        {
            _peer = peer;
        }

        /// <summary>
        /// Передача фрагмента по сети
        /// </summary>
        protected override void SendPackage(IPackage package)
        {
            //Отправляем информацию при WCF
            //_peer.ContentReceiver.SendMessage(package, ConnectConfiguration.UserName);

            //Отправляем информацию самому себе, сразу в плеер
            ContentPlayer.Instance.AddPackage(package);
        }
    }
}
