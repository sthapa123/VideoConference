using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.PeerToPeer;

namespace VideoConferenceConnection
{
    class Peer
    {
        public PeerName PeerName { get; set; }
        public IP2PService ServiceProxy { get; set; }
        public string DisplayString { get; set; }
    }
}
