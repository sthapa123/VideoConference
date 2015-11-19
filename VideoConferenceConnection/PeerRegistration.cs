using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.PeerToPeer;
using System.Text;
using NLog;
using VideoConferenceResources;

namespace VideoConferenceConnection
{
    /// <summary>
    /// Класс, отвечающий за регистрацию равноправного участника в локальном облаке
    /// </summary>
    public class PeerRegistration : IDisposable
    {
        #region Логгирование
        private static Logger log = LogManager.GetCurrentClassLogger();
        #endregion


        private static readonly PeerName PeerName = new PeerName(ConnectionConstants.MainPeerName, PeerNameType.Unsecured);
        private PeerNameRegistration _nameRegistrator;

        public PeerRegistration(int port)
        {
            _nameRegistrator = new PeerNameRegistration(PeerName, port);
            _nameRegistrator.Cloud = Cloud.AllLinkLocal;
        }

        /// <summary>
        /// Запуск процесса регистрации. Если порт занят - пробует другой порт
        /// </summary>
        public void StartRegistration()
        {
            _nameRegistrator.Start();
        }

        public void Dispose()
        {
            _nameRegistrator.Stop();
        }
    }
}
