using System.ServiceModel;
using System.Text;
using VideoConferenceConnection.Interfaces;

namespace VideoConferenceConnection
{
    /// <summary>
    /// WCF сервис
    /// </summary>
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class ContentReceiver : IContentReceiver
    {
        private string _username;
        private static IContentReceiver _receiver;

        private ContentReceiver()
        {
            _username = ConnectConfiguration.UserName;
        }

        public static IContentReceiver Instance
        {
            get { return _receiver ?? (_receiver = new ContentReceiver()); }
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
