using System;
using System.ServiceModel;
using System.Text;
using VideoConferenceCommon;
using VideoConferenceConnection.Interfaces;
using VideoConferenceObjects;
using VideoConferenceObjects.Interfaces;
using VideoConferenceUtils;
using VideoConferenceUtils.Audio;
using VideoConferenceUtils.Video;

namespace VideoConferenceConnection
{
    /// <summary>
    /// WCF сервис, приёмник
    /// </summary>
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class ContentReceiver : IContentReceiver
    {
        private readonly string _username;
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

        /// <summary>
        /// Принять информацию
        /// </summary>
        /// <param name="package">Инфопакет</param>
        /// <param name="from">От кого</param>
        public void SendMessage(IPackage package, string from)
        {
            ContentPlayer.Instance.AddPackage(package);
        }
    }
}
