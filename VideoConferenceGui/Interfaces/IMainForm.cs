using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VideoConferenceConnection;

namespace VideoConference.Interfaces
{
    public interface IMainForm
    {
        /// <summary>
        /// Обновить список получателей
        /// </summary>
        /// <param name="peers">Список</param>
        void SetPeersList(IEnumerable<Peer> peers);
    }
}
