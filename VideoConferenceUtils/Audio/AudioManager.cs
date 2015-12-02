using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NAudio;
using NAudio.Wave;
using NLog;
using VideoConferenceConnection.Interfaces;
using VideoConferenceObjects;
using VideoConferenceObjects.Interfaces;
using VideoConferenceUtils.Interfaces;

namespace VideoConferenceUtils.Audio
{
    /// <summary>
    /// Класс, отвечающий за работу с аудио, синглтон
    /// </summary>
    public class AudioManager : IAudioManager , IDisposable
    {
        #region Логгирование
        private static Logger log = LogManager.GetCurrentClassLogger();
        #endregion

        #region Закрытые переменные
        /// <summary>
        /// Максимальное количество фрагментов в колекции
        /// </summary>
        private const int MaxFragmentCount = 10;

        /// <summary>
        /// Длина аудиофрагмента
        /// </summary>
        private const int FragmentLenght = 50;

        /// <summary>
        /// Экземпляр класа
        /// </summary>
        private static IAudioManager _audioManager;

        /// <summary>
        /// Класс записи аудио
        /// </summary>
        private IAudioRecorder _recorder;

        /// <summary>
        /// Класс воспроизведения аудио
        /// </summary>
        private IAudioPlayer _player;

        /// <summary>
        /// Коллексия фрагментов, записанных локально
        /// </summary>
        private Dictionary<DateTime, IAudioFragment> _localAudio;
        
        /// <summary>
        /// Коллексия фрагментов, полученных из сети
        /// </summary>
        private Dictionary<DateTime, IAudioFragment> _receivedAudio;
        #endregion
        
        private AudioManager()
        {
            _recorder = new AudioRecorder(this, TimeSpan.FromMilliseconds(FragmentLenght));
            _player = new AudioPlayer(this);
            _localAudio = new Dictionary<DateTime, IAudioFragment>();
            _receivedAudio = new Dictionary<DateTime, IAudioFragment>();

            _recorder.DataAvailable += recorder_DataAvailable;
        }

        public static IAudioManager Instance
        {
            get { return _audioManager ?? (_audioManager = new AudioManager()); }
        }

        /// <summary>
        /// Добавить фрагмент аудио в коллекцию полученных по сети
        /// </summary>
        /// <param name="fragment">Аудио фрагмент</param>
        public void AddReceivedFragment(IAudioFragment fragment)
        {
            try
            {
                _receivedAudio.Add(DateTime.Now, fragment);
                OnReceivedCollectionChanged();
            }
            catch (Exception ex)
            {
                log.Warn(ex, "AddReceivedFragment. Фрагмент не был добавлен");
            }
        }

        /// <summary>
        /// Возвращает локальный фрагмент, удаляет его
        /// </summary>
        /// <returns>Фрагмент</returns>
        public IAudioFragment GetAndRemoveLocalFragment()
        {
            lock (_localAudio)
            {
                if (_localAudio.Count == 0)
                    return null;
                var fragment = _localAudio.First().Value;
                _localAudio.Remove(_localAudio.First().Key);

                return fragment;
            }
        }

        /// <summary>
        /// Возвращает полученный фрагмент, удаляет его
        /// </summary>
        /// <returns>Фрагмент</returns>
        public IAudioFragment GetAndRemoveReceivedFragment()
        {
            lock (_receivedAudio)
            {
                if (_receivedAudio.Count == 0)
                    return null;
                var fragment = _receivedAudio.First().Value;
                _receivedAudio.Remove(_receivedAudio.First().Key);

                return fragment;
            }
        }

        /// <summary>
        /// Начать процесс записи аудио
        /// </summary>
        public void StartAudioRecord()
        {
            _localAudio.Clear();
            _receivedAudio.Clear();
            _recorder.StartRecording();
        }

        /// <summary>
        /// Остановить процесс записи аудио
        /// </summary>
        public void StopAudioRecord()
        {
            _recorder.StopRecording();
        }

        /// <summary>
        /// Начать процесс воспроизведения аудио
        /// </summary>
        public void StartAudioPlay()
        {
            _player.StartPlay();
        }

        /// <summary>
        /// Остановить процесс воспроизведения аудио
        /// </summary>
        public void StopAudioPlay()
        {
            _player.StopPlay();
        }

        /// <summary>
        /// Событие изменения количества элементов
        /// </summary>
        private void OnLocalCollectionChanged()
        {
            while (_localAudio.Count > MaxFragmentCount)
                _localAudio.Remove(_localAudio.First().Key);
        }

        /// <summary>
        /// Событие изменения количества элементов
        /// </summary>
        private void OnReceivedCollectionChanged()
        {
            while (_receivedAudio.Count > MaxFragmentCount)
                _localAudio.Remove(_localAudio.First().Key);
        }

        /// <summary>
        /// Событий готовности фрагмента
        /// </summary>
        private void recorder_DataAvailable(object sender, WaveInEventArgs e)
        {
            _localAudio.Add(DateTime.Now, new AudioFragment(e.Buffer));
            OnLocalCollectionChanged();
        }

        #region IDisposable

        public void Dispose()
        {
            if (_recorder != null)
            {
                _recorder.Dispose();
                _recorder = null;
            }

            if (_player != null)
            {
                _player.Dispose();
                _player = null;
            }
        }
        #endregion
    }
}
