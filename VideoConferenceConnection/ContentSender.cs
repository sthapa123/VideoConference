using VideoConferenceConnection.Interfaces;
using VideoConferenceObjects.Interfaces;

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

        public ContentSender(Peer peer)
        {
            _peer = peer;
        }

        /// <summary>
        /// Отправить пакет информации
        /// </summary>
        /// <param name="package">Пакет информации</param>
        public void SendPackage(IPackage package)
        {
            _peer.ContentReceiver.SendMessage(package, ConnectConfiguration.UserName);
        }
    }
}
