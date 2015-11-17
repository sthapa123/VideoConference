using System;
using System.Collections.Generic;
using System.Linq;
using NLog;
using System.Net;
using System.Net.PeerToPeer;
using System.ServiceModel;
using VideoConferenceUtils;

namespace VideoConferenceConnection
{
    /// <summary>
    /// Класс начальных настроек подключения
    /// </summary>
    public class ConnectConfiguration : IDisposable
    {
        #region Логгирование

        private static Logger log = LogManager.GetCurrentClassLogger();

        #endregion

        private P2PService localService;
        public string _userName;
        private int _port;
        private string _machineName;
        private string serviceUrl = null;
        private ServiceHost host;
        private PeerName peerName;
        private PeerNameRegistration peerNameRegistration;
        private List<Peer> _peerList;
        private ContentReceiver _receiver;

        public ConnectConfiguration(ContentReceiver receiver)
            : this(ConfigurationHelper.GetAppConfigurationString("username", String.Empty), receiver)
        {
        }

        public ConnectConfiguration(string userName, ContentReceiver receiver)
            : this(userName, ConfigurationHelper.GetAppConfigurationInt("port", 0), receiver)
        {
        }

        public ConnectConfiguration(string userName, int port, ContentReceiver receiver)
        {
            //todo если порт занят, попробовать другой порт
            if (String.IsNullOrEmpty(userName) || port == 0)
            {
                var message = "Некорректный логин/порт";
                log.Error(message);
                //todo Возможно стоит придумать собвственное исключение
                throw new Exception(message);
            }

            _userName = userName;
            _port = port;
            _machineName = Environment.MachineName;
            _peerList = new List<Peer>();
            _receiver = receiver;

            foreach (var ipAddress in Dns.GetHostAddresses(Dns.GetHostName()))
            {
                if (ipAddress.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    serviceUrl = string.Format("net.tcp://{0}:{1}/P2PService", ipAddress, port);
                    break;
                }
            }
            localService = new P2PService(_receiver, _userName);
            host = new ServiceHost(localService, new Uri(serviceUrl));
            NetTcpBinding binding = new NetTcpBinding();
            binding.Security.Mode = SecurityMode.None;
            host.AddServiceEndpoint(typeof (IP2PService), binding, serviceUrl);

            host.Open();

            peerName = new PeerName("P2P Sample", PeerNameType.Unsecured);

            // Подготовка процесса регистрации имени равноправного участника в локальном облаке
            peerNameRegistration = new PeerNameRegistration(peerName, _port);
            peerNameRegistration.Cloud = Cloud.AllLinkLocal;

            // Запуск процесса регистрации
            peerNameRegistration.Start();
        }

        public void ReloadPeers()
        {
            // Создание распознавателя и добавление обработчиков событий
            PeerNameResolver resolver = new PeerNameResolver();
            resolver.ResolveProgressChanged +=
                new EventHandler<ResolveProgressChangedEventArgs>(resolver_ResolveProgressChanged);
            resolver.ResolveCompleted +=
                new EventHandler<ResolveCompletedEventArgs>(resolver_ResolveCompleted);

            // Подготовка к добавлению новых пиров
            _peerList.Clear();

            // Преобразование незащищенных имен пиров асинхронным образом
            resolver.ResolveAsync(new PeerName("0.P2P Sample"), 1);
        }

        public void SendMessage(string message)
        {
            var peer = _peerList.First();
            peer.ServiceProxy.SendMessage(message, _userName);
        }

        void resolver_ResolveCompleted(object sender, ResolveCompletedEventArgs e)
        {
            
        }

        void resolver_ResolveProgressChanged(object sender, ResolveProgressChangedEventArgs e)
        {
            PeerNameRecord peer = e.PeerNameRecord;

            foreach (IPEndPoint ep in peer.EndPointCollection)
            {
                if (ep.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    try
                    {
                        string endpointUrl = string.Format("net.tcp://{0}:{1}/P2PService", ep.Address, ep.Port);
                        NetTcpBinding binding = new NetTcpBinding();
                        binding.Security.Mode = SecurityMode.None;
                        IP2PService serviceProxy = ChannelFactory<IP2PService>.CreateChannel(
                            binding, new EndpointAddress(endpointUrl));
                        _peerList.Add(
                           new Peer
                           {
                               PeerName = peer.PeerName,
                               ServiceProxy = serviceProxy,
                               DisplayString = serviceProxy.GetName()
                           });
                    }
                    catch (EndpointNotFoundException)
                    {
                        
                    }
                }
            }
        }

        public void Dispose()
        {
            peerNameRegistration.Stop();
            host.Close();
        }
    }
}
