using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NLog;
using VideoConference;
using VideoConference.Interfaces;
using VideoConferenceConnection;

namespace VideoConferenceInitializer
{
    /// <summary>
    /// Класс, инициализирующий приложение
    /// </summary>
    public class Initializer
    {
        #region Логгирование
        private static Logger log = LogManager.GetCurrentClassLogger();
        #endregion

        private Splash _splashForm;
        private MainForm _mainForm;

        public Initializer(Splash splashRef)
        {
            _splashForm = splashRef;
        }

        /// <summary>
        /// Инициализация приложения.
        /// </summary>
        /// <returns>true - если инициализация прошла успешно</returns>
        public bool Initialize()
        {
            _splashForm.StatusText = "Инициализация";

            _splashForm.StatusText = "Загрузка сервиса подключения";
            var receiver = new ContentReceiver(ConnectConfiguration.UserName);
            _splashForm.StatusText = "Регистрация служб";
            var host = new ReceiverServiceHost(receiver);
            host.HostOpen();
            _splashForm.StatusText = "Регистрация в локальном облаке";
            var registrator = new PeerRegistration(host.Port);
            registrator.StartRegistration();
            var resolver = new PeersResolver();

            _splashForm.StatusText = "Загрузка формы";
            _mainForm = new MainForm();
            _splashForm.Hide();
            _mainForm.Show();
            return true;
        }
    }
}
