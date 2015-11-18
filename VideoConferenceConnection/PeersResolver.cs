using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.PeerToPeer;
using System.ServiceModel;
using System.Text;
using NLog;
using VideoConferenceResources;

namespace VideoConferenceConnection
{
    /// <summary>
    /// Класс работы со сиском пиров
    /// </summary>
    public class PeersResolver
    {
        #region Логгирование
        private static Logger log = LogManager.GetCurrentClassLogger();
        #endregion

        private PeerNameResolver _resolver;
        private List<Peer> _peerList;

        public PeersResolver()
        {
            _resolver = new PeerNameResolver();
            _resolver.ResolveProgressChanged += resolver_ResolveProgressChanged;
            _resolver.ResolveCompleted += resolver_ResolveCompleted;

            _peerList = new List<Peer>();
        }

        public void ReloadPeers()
        {
            _peerList.Clear();
            _resolver.ResolveAsync(new PeerName("0." + ConnectionConstants.MainPeerName), 10);
        }

        private void resolver_ResolveProgressChanged(object sender, ResolveProgressChangedEventArgs e)
        {
            var peer = e.PeerNameRecord;

            foreach (IPEndPoint ep in peer.EndPointCollection)
            {
                if (ep.Address.AddressFamily != System.Net.Sockets.AddressFamily.InterNetwork) 
                    continue;

                try
                {
                    var endpointUrl = string.Format("net.tcp://{0}:{1}/ContentReceiver", ep.Address, ep.Port);
                    var binding = new NetTcpBinding {Security = {Mode = SecurityMode.None}};
                    
                    var contentReceiver = ChannelFactory<IContentReceiver>.CreateChannel(
                        binding, new EndpointAddress(endpointUrl));

                    _peerList.Add(new Peer {PeerName = peer.PeerName, ContentReceiver = contentReceiver});
                }
                catch (Exception ex)
                {
                    
                }
            }
        }
        
        /// <summary>
        /// Обработка завершения разрешения
        /// </summary>
        void resolver_ResolveCompleted(object sender, ResolveCompletedEventArgs e)
        {

        }
    }
}
