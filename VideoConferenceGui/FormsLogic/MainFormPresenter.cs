using System;
using System.Linq;
using System.Runtime.Remoting.Channels;
using NLog;
using VideoConferenceCommon;
using VideoConferenceConnection;
using VideoConferenceConnection.Interfaces;
using VideoConferenceGui.Interfaces;
using VideoConferenceObjects.Interfaces;
using VideoConferenceUtils.Interfaces;

namespace VideoConferenceGui.FormsLogic
{
    public class MainFormPresenter
    {
        #region Логгирование

        private static Logger log = LogManager.GetCurrentClassLogger();

        #endregion

        //Временно всё так. После будет распределено лучше. Пока тестирование
        private IMainForm _view;
        private IAudioManager _audioManager;
        private IVideoManager _videoManager;
        private IContentPlayer _contentPlayer;
        private IContentSender _sender;
        private IMainServer _server;
        private IClient _client;

        public MainFormPresenter(IMainForm mainForm, IAudioManager audioManager, IVideoManager videoManager,
            IContentPlayer contantPlayer)
        {
            _view = mainForm;
            _audioManager = audioManager;
            _videoManager = videoManager;
            _contentPlayer = contantPlayer;
            //Разобраться с резолвером пиров
        }

        #region Работа с контентом

        /// <summary>
        /// Начать запись информации
        /// </summary>
        public void StartRecording()
        {
            _audioManager.StartRecord();
            _videoManager.StartRecord();
        }

        /// <summary>
        /// Остановить запись информации
        /// </summary>
        public void StopRecord()
        {
            _audioManager.StopRecord();
            _videoManager.StopRecord();
        }

        /// <summary>
        /// Начать воспроизведение информации
        /// </summary>
        /// <param name="pictureBox">Контрол, отображающий видео</param>
        public void StartPlay(IVideoScreen pictureBox)
        {
            _contentPlayer.StartPlay(pictureBox);
        }

        /// <summary>
        /// Остановить воспроизведение информации
        /// </summary>
        public void StopPlay()
        {
            _contentPlayer.StopPlay();
        }

        #endregion

        #region Работа с подключением

        /// <summary>
        /// Запустить сервер
        /// </summary>
        /// <param name="server"></param>
        public void StartServer(IMainServer server)
        {
            _server = server;
            _server.RunServer();
        }

        /// <summary>
        /// Остановить сервер
        /// </summary>
        public void StopServer()
        {
            if (_server != null && _server.IsRunning)
                _server.StopServer();
        }

        /// <summary>
        /// Подключиться к серверу
        /// </summary>
        public void ConnectToServer(IClient client)
        {
            _client = client;
            _client.StartConnect();
        }

        /// <summary>
        /// Разорвать соединение с сервером
        /// </summary>
        public void DisconnectFromServer()
        {
            _sender.StopSending();
            _client.Disconnect();
        }

        #endregion

        #region Работа с передачей

        /// <summary>
        /// Начать передачу
        /// </summary>
        public void StartSending(IContentSender sender)
        {
            _sender = sender;
            _sender.StartSending();
        }

        /// <summary>
        /// Остановить передачу
        /// </summary>
        public void StopSending()
        {
            _sender.StopSending();
        }

        #endregion
    }
}
