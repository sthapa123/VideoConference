
using System.Net.PeerToPeer;

namespace VideoConferenceConnection
{
    /// <summary>
    /// Класс, представляющий пользователя
    /// </summary>
    public class Peer
    {
        /// <summary>
        /// Имя пользователя
        /// </summary>
        public PeerName PeerName { get; set; }

        /// <summary>
        /// Приёмник информации
        /// </summary>
        public IContentReceiver ContentReceiver { get; set; }
    }
}
