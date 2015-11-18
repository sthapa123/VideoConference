using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.PeerToPeer;
using System.ServiceModel;
using System.Text;
using VideoConferenceResources;

namespace VideoConferenceConnection
{
    public class ReceiverServiceHost : IDisposable
    {
        private readonly string _serviceUrl;
        private ServiceHost _host;

        public ReceiverServiceHost(ContentReceiver receiver)
        {
            foreach (var ipAddress in Dns.GetHostAddresses(Dns.GetHostName()))
            {
                if (ipAddress.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    _serviceUrl = string.Format("net.tcp://{0}:{1}/ContentReceiver", ipAddress, port);
                    break;
                }
            }

            _host = new ServiceHost(receiver, new Uri(_serviceUrl));
            var binding = new NetTcpBinding {Security = {Mode = SecurityMode.None}};

            _host.AddServiceEndpoint(typeof(IContentReceiver), binding, _serviceUrl);
            

            // Подготовка процесса регистрации имени равноправного участника в локальном облаке
            peerNameRegistration = new PeerNameRegistration(_peerName, _port);
            peerNameRegistration.Cloud = Cloud.AllLinkLocal;

            // Запуск процесса регистрации
            peerNameRegistration.Start();
        }

        public void HostOpen()
        {
            _host.Open();
        }

        public void Dispose()
        {
            peerNameRegistration.Stop();
            _host.Close();
        }
    }
}
