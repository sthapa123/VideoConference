using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace VideoConferenceConnection
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class P2PService : IP2PService
    {
        private ContentReceiver _receiver;
        private string _username;

        public P2PService(ContentReceiver receiver, string username)
        {
            _receiver = receiver;
            _username = username;
        }

        public string GetName()
        {
            return _username;
        }

        public void SendMessage(string message, string from)
        {
            _receiver.DisplayMessage(message, from);
        }
    }
}
