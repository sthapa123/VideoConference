using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VideoConferenceCommon;
using VideoConferenceConnection.Interfaces;
using VideoConferenceObjects.Interfaces;
using VideoConferenceUtils.Interfaces;

namespace VideoConferenceConnection
{
    /// <summary>
    /// Передатчик информации TLS
    /// </summary>
    public class ContentSenderTls : BaseSender
    {
        private IClient _client;

        public ContentSenderTls(IPackageCreator creator, IClient client) : base(creator)
        {
            _client = client;
        }

        /// <summary>
        /// Передача фрагмента по сети
        /// </summary>
        protected override void SendPackage(IPackage package)
        {
            _client.SendPackage(package);
        }
    }
}
