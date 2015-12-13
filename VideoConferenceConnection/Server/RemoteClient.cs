using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Authentication;
using System.Text;
using VideoConferenceCommon;
using VideoConferenceConnection.Interfaces;
using VideoConferenceObjects.Interfaces;

namespace VideoConferenceConnection.Server
{
    public class RemoteClient : BaseClient
    {
        /// <summary>
        /// Сервер
        /// </summary>
        private IMainServer _server;

        /// <summary>
        /// Подключение сетевых служб
        /// </summary>
        private TcpClient _tcpClient;

        /// <summary>
        /// Основной поток данных
        /// </summary>
        private NetworkStream _netStream;

        /// <summary>
        /// Защищенный поток данных
        /// </summary>
        private SslStream _sslStream;

        public RemoteClient(IMainServer server, TcpClient client) :
            base(server.Port, server.Address)
        {
            _server = server;
            _tcpClient = client;
        }

        /// <summary>
        /// Установление соединения
        /// </summary>
        protected override void SetupConnect()
        {
            _netStream = _tcpClient.GetStream();
            _sslStream = new SslStream(_netStream, false);
            _sslStream.AuthenticateAsServer(_server.Certificate, false, SslProtocols.Tls, true);
            _binaryDataManager = new BinaryDataManager(_sslStream);

            if (!_binaryDataManager.CheckConnection())
            {
                CloseConnect();
                throw new Exception("Отсутствует подключение к клиенту");
            }

            StartReceive();
        }

        /// <summary>
        /// Разрыв соединения
        /// </summary>
        protected override void CloseConnect()
        {
            base.CloseConnect();
            _sslStream.Close();
            _netStream.Close();
            _tcpClient.Close();
        }
    }
}
