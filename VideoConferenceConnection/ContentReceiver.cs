using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace VideoConferenceConnection
{
    /// <summary>
    /// WCF сервис
    /// </summary>
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class ContentReceiver : IContentReceiver
    {
        private string _username;

        public ContentReceiver(string username)
        {
            _username = username;
        }

        public string GetName()
        {
            return _username;
        }

        public void SendMessage(string message, string from)
        {
            
        }
    }
}
