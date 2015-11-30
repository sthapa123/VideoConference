using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VideoConferenceObjects.Interfaces;

namespace VideoConferenceConnection.Interfaces
{
    public interface IContentSender
    {
        //todo удалить ссылку на Objects
        /// <summary>
        /// Отправить пакет информации
        /// </summary>
        /// <param name="package"></param>
        void SendPackage(IPackage package);
    }
}
