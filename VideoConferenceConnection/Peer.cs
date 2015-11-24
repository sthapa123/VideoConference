
using System.Net.PeerToPeer;
using VideoConferenceConnection.Interfaces;

namespace VideoConferenceConnection
{
    /// <summary>
    /// Класс, представляющий пользователя
    /// </summary>
    public class Peer
    {
        /// <summary>
        /// Имя пира
        /// </summary>
        public PeerName PeerName { get; set; }

        /// <summary>
        /// Приёмник информации
        /// </summary>
        public IContentReceiver ContentReceiver { get; set; }
        /// <summary>
        /// Имя пользователя
        /// </summary>
        public string ReceiverName { get; set; }
    }
}
