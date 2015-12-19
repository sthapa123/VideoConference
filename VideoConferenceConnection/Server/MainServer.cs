using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using VideoConferenceObjects.Interfaces;

namespace VideoConferenceConnection.Server
{
    public class MainServer : IMainServer
    {
        #region Закрытые переменные
        /// <summary>
        /// Адрес сервера
        /// </summary>
        private IPAddress _ipAddress;

        /// <summary>
        /// Сертификат сервера
        /// </summary>
        private X509Certificate2 _certificate;

        /// <summary>
        /// Порт прослушивания
        /// </summary>
        private int _port;

        /// <summary>
        /// Ожидание подключений к серверу, в отдельном потоке
        /// </summary>
        private TcpListener _listener;

        /// <summary>
        /// Поток ожидания подключений
        /// </summary>
        private Thread _listenThread;
        
        #endregion

        #region Конструкторы
        /// <summary>
        /// Конструктор. Создаёт localhost сервер
        /// </summary>
        /// <param name="port">Порт</param>
        public MainServer(int port) : this(port, IPAddress.Loopback)
        {
        }

        /// <summary>
        /// Конструктор. Создаёт сервер по указанному ip
        /// </summary>
        /// <param name="port">Порт</param>
        /// <param name="ipAddress">ip адрес</param>
        public MainServer(int port, string ipAddress) : this(port, IPAddress.Parse(ipAddress))
        {
        }

        /// <summary>
        /// Конструктор. Создаёт сервер по указанному ip
        /// </summary>
        /// <param name="port">Порт</param>
        /// <param name="ipAddress">ip адрес</param>
        public MainServer(int port, IPAddress ipAddress)
        {
            _port = port;
            _ipAddress = ipAddress;
            _certificate = new X509Certificate2("server.pfx", "instant");
            IsRunning = false;
        }

#endregion

        /// <summary>
        /// Запущен ли сервер
        /// </summary>
        public bool IsRunning { get; private set; }

        /// <summary>
        /// Порт прослушивания
        /// </summary>
        public int Port
        {
            get { return _port; }
        }

        /// <summary>
        /// Адрес сервера
        /// </summary>
        public IPAddress Address
        {
            get { return _ipAddress; }
        }

        /// <summary>
        /// Сертификат
        /// </summary>
        public X509Certificate2 Certificate
        {
            get { return _certificate; }
        }

        /// <summary>
        /// Запустить сервер
        /// </summary>
        public void RunServer()
        {
            _listener = new TcpListener(_ipAddress, _port);
            _listener.Start();

            _listenThread = new Thread(Listen);
            _listenThread.Start();
            IsRunning = true;
        }

        /// <summary>
        /// Остановить сервер
        /// </summary>
        public void StopServer()
        {
            if (!IsRunning)
                return;

            IsRunning = false;

            //foreach (var remoteClient in _clients)
            //    remoteClient.Disconnect();
            ClientsCollection.GetFirstClient().Disconnect();
            _listener.Stop();
        }

        /// <summary>
        /// Ожидание подключения клиентов
        /// </summary>
        private void Listen()
        {
            while (IsRunning)
            {
                try
                {
                    var tcpClient = _listener.AcceptTcpClient();
                    var client = new RemoteClient(this, tcpClient);
                    client.StartConnect();
                    ClientsCollection.Add(client);
                }
                catch (SocketException ex)
                {
                    if (ex.SocketErrorCode == SocketError.Interrupted)
                        return;

                    throw;
                }
            }
        }

        public void Dispose()
        {
            StopServer();
            if (_listenThread.IsAlive)
                _listenThread.Abort();
            _listenThread = null;
            _listener = null;
        }
    }
}
