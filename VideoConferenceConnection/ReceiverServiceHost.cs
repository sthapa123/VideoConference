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
        private int _port;

        public ReceiverServiceHost(ContentReceiver receiver)
        {
            _port = ConnectConfiguration.Port;

            foreach (var ipAddress in Dns.GetHostAddresses(Dns.GetHostName()))
            {
                if (ipAddress.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    _serviceUrl = string.Format("net.tcp://{0}:{1}/ContentReceiver", ipAddress, _port);
                    break;
                }
            }

            if (_serviceUrl == null)
                throw new Exception();

            _host = new ServiceHost(receiver, new Uri(_serviceUrl));
            var binding = new NetTcpBinding {Security = {Mode = SecurityMode.None}};

            _host.AddServiceEndpoint(typeof(IContentReceiver), binding, _serviceUrl);
        }

        public int Port
        {
            get { return _port; }
        }

        public void HostOpen()
        {
            _host.Open();
        }

        public void Dispose()
        {
            _host.Close();
        }
    }
}
