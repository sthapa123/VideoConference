using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using VideoConferenceCommon;
using VideoConferenceConnection.Interfaces;
using VideoConferenceObjects.Interfaces;

namespace VideoConferenceConnection.Client
{
    public class Client : BaseClient
    {
        #region Закрытые переменные

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

        #endregion

        #region Конструкторы

        /// <summary>
        /// Подключение к localhost серверу
        /// </summary>
        /// <param name="port"></param>
        public Client(int port)
            : base(port, IPAddress.Loopback)
        {
        }

        /// <summary>
        /// Подключение к серверу по адресу
        /// </summary>
        /// <param name="port">Порт</param>
        /// <param name="ipAddress">Адрес</param>
        public Client(int port, string ipAddress)
            : this(port, IPAddress.Parse(ipAddress))
        {
        }

        /// <summary>
        /// Подключение к серверу по адресу
        /// </summary>
        /// <param name="port">Порт</param>
        /// <param name="ipAddress">Адрес</param>
        public Client(int port, IPAddress ipAddress)
            : base(port, ipAddress)
        {
        }

        #endregion

        /// <summary>
        /// Установить подключение
        /// </summary>
        protected override void SetupConnect()
        {
            _tcpClient = new TcpClient(new IPEndPoint(ServerAddress, Port));
            //Пока что локалхост
            //_tcpClient = new TcpClient("localhost", Port);
            _netStream = _tcpClient.GetStream();
            _sslStream = new SslStream(_netStream, false, ValidateCert);
            _sslStream.AuthenticateAsClient("InstantServer");
            _binaryDataManager = new BinaryDataManager(_sslStream);

            if (!_binaryDataManager.ReceiveHello())
            {
                CloseConnect();
                throw new Exception("Отсутствует ответ от сервера.");
            }

            _binaryDataManager.SendHello();

            StartReceive();
        }

        /// <summary>
        /// Разорвать подключение
        /// </summary>
        protected override void CloseConnect()
        {
            base.CloseConnect();
            _sslStream.Close();
            _netStream.Close();
            _tcpClient.Close();
        }

        /// <summary>
        /// Валидация сертификата
        /// </summary>
        private static bool ValidateCert(object sender, X509Certificate certificate,
            X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            //Возвращаем true для недоверительных сертификатов
            return true;
        }
    }
}
