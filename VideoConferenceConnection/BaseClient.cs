using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Text;
using System.Threading;
using VideoConferenceCommon;
using VideoConferenceConnection.Interfaces;
using VideoConferenceObjects.Interfaces;
using VideoConferenceUtils;

namespace VideoConferenceConnection
{
    public abstract class BaseClient : IClient
    {
        #region Закрытые переменные
        /// <summary>
        /// Активно ли подкючение
        /// </summary>
        private bool _connected;
        
        /// <summary>
        /// Адрес сервера
        /// </summary>
        private IPAddress _ipAddress;

        /// <summary>
        /// Поток подключения
        /// </summary>
        private Thread _tcpThread;

        /// <summary>
        /// Менеджер бинарной информации
        /// </summary>
        protected IBinaryDataManager _binaryDataManager;
        #endregion

        /// <summary>
        /// Подключение к серверу по адресу
        /// </summary>
        /// <param name="port">Порт</param>
        /// <param name="ipAddress">Адрес</param>
        public BaseClient(int port, IPAddress ipAddress)
        {
            Port = port;
            _ipAddress = ipAddress;
        }
        
        /// <summary>
        /// Порт
        /// </summary>
        protected int Port { get; private set; }

        /// <summary>
        /// Адрес сервера, к которому подключились
        /// </summary>
        protected IPAddress ServerAddress
        {
            get { return _ipAddress; }
        }
        
        /// <summary>
        /// Установить соединение
        /// </summary>
        public void StartConnect()
        {
            Connect();
        }

        /// <summary>
        /// Разорвать соединение
        /// </summary>
        public void Disconnect()
        {
            if (_connected)
                CloseConnect();
        }

        /// <summary>
        /// Отправить пакет
        /// </summary>
        /// <param name="package">Пакет информации</param>
        public void SendPackage(IPackage package)
        {
            _binaryDataManager.SendPackage(package);
        }
        
        private void Connect()
        {
            if (_connected)
                return;

            _connected = true;

            _tcpThread = new Thread(SetupConnect);
            _tcpThread.Start();
        }

        /// <summary>
        /// Установить подключение
        /// </summary>
        protected abstract void SetupConnect();

        /// <summary>
        /// Получение информации
        /// </summary>
        protected void StartReceive()
        {
            while (_connected)
            {
                var type = _binaryDataManager.Receive();

                switch (type)
                {
                    case Constants.PackageType.Hello:
                        _binaryDataManager.SendHello();
                        break;
                    case Constants.PackageType.AudioData:
                    case Constants.PackageType.AudioAndVideoData:
                        var package = _binaryDataManager.ReadPackage(type);
                        ContentPlayer.Instance.AddPackage(package);
                        break;
                    default:
                        throw new Exception("Неизвестный тип пакета!");
                }
            }
        }

        /// <summary>
        /// Разорвать подключение
        /// </summary>
        protected virtual void CloseConnect()
        {
            _binaryDataManager.Close();
        }
    } 
}
