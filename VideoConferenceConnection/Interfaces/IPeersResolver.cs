
using System.Collections.Generic;
using VideoConferenceCommon;
using VideoConferenceUtils;

namespace VideoConferenceConnection.Interfaces
{
    public interface IPeersResolver
    {
        /// <summary>
        /// Список пиров
        /// </summary>
        List<Peer> Peers { get; }
        /// <summary>
        /// Обновить список пиров
        /// </summary>
        void ReloadPeers();
        /// <summary>
        /// Обновить список пиров, с методом обратного вызова
        /// </summary>
        /// <param name="callback">Метод обратного вызова</param>
        void ReloadPeers(Constants.VoidCallback callback);
    }
}
