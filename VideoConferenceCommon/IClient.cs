using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using VideoConferenceObjects.Interfaces;

namespace VideoConferenceCommon
{
    public interface IClient
    {
        /// <summary>
        /// Установить соединение
        /// </summary>
        void StartConnect();

        /// <summary>
        /// Разорвать соединение
        /// </summary>
        void Disconnect();

        /// <summary>
        /// Отправить пакет
        /// </summary>
        /// <param name="package"></param>
        void SendPackage(IPackage package);
    }
}
