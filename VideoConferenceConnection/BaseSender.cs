using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using VideoConferenceCommon;
using VideoConferenceConnection.Interfaces;
using VideoConferenceObjects.Interfaces;
using VideoConferenceUtils.Interfaces;

namespace VideoConferenceConnection
{
    public abstract class BaseSender : IContentSender
    {
        /// <summary>
        /// Создатель пакетов
        /// </summary>
        private IPackageCreator _packageCreator;

        /// <summary>
        /// Поток, занимающийся отправкой
        /// </summary>
        private Thread _sendThread;

        protected BaseSender(IPackageCreator packageCreator)
        {
            _packageCreator = packageCreator;
        }

        /// <summary>
        /// Начать отправку информации
        /// </summary>
        public void StartSending()
        {
            _sendThread = new Thread(Sending);
            _sendThread.Start();
        }

        /// <summary>
        /// Остановить отправку информации
        /// </summary>
        public void StopSending()
        {
            if (_sendThread != null)
                _sendThread.Abort();
        }

        /// <summary>
        /// Процесс передачи
        /// </summary>
        private void Sending()
        {
            while (true)
            {
                var package = _packageCreator.GetPackage();
                if (package == null)
                {
                    Thread.Sleep(Constants.FragmentLenght);
                    continue;
                }

                SendPackage(package);
            }
        }

        /// <summary>
        /// Передача фрагмента по сети
        /// </summary>
        protected abstract void SendPackage(IPackage package);
    }
}
