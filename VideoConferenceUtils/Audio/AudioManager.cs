using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NAudio;
using NAudio.Wave;
using NLog;
using VideoConferenceUtils.Interfaces;

namespace VideoConferenceUtils.Audio
{
    /// <summary>
    /// Класс, отвечающий за работу с аудио, синглтон
    /// </summary>
    public class AudioManager : IAudioManager
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
        /// Коллексия фрагментов
        /// </summary>
        private Dictionary<DateTime, byte[]> _audioFragmentsCollection;
        #endregion

        private AudioManager()
        {
            _recorder = new AudioRecorder(this, TimeSpan.FromMilliseconds(100));
            _player = new AudioPlayer(this);
            _audioFragmentsCollection = new Dictionary<DateTime, byte[]>();
        }

        public static IAudioManager Instance
        {
            get { return _audioManager ?? (_audioManager = new AudioManager()); }
        }

        /// <summary>
        /// Добавить фрагмент аудио в коллекцию
        /// </summary>
        /// <param name="fragment">Аудио фрагмент</param>
        public void AddFragment(byte[] fragment)
        {
            try
            {
                _audioFragmentsCollection.Add(DateTime.Now, fragment);
                OnCollectionChanged();
            }
            catch (Exception ex)
            {
                log.Warn(ex, "AddFragment. Фрагмент не был добавлен");
            }
        }
        
        /// <summary>
        /// Возвращает фрагмент, удаляет его
        /// </summary>
        /// <returns>Фрагмент</returns>
        public byte[] GetAndRemoveFragment()
        {
            //lock (_audioFragmentsCollection)
            //{
                var fragment = _audioFragmentsCollection.First().Value;
                _audioFragmentsCollection.Remove(_audioFragmentsCollection.First().Key);

                return fragment;
           // }
        }

        /// <summary>
        /// Начать процесс записи аудио
        /// </summary>
        public void StartAudioRecord()
        {
            _audioFragmentsCollection.Clear();
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
            _recorder.Play();
            //_player.StartPlay();
        }

        /// <summary>
        /// Событие изменения количества элементов
        /// </summary>
        private void OnCollectionChanged()
        {
            while (_audioFragmentsCollection.Count > MaxFragmentCount)
                _audioFragmentsCollection.Remove(_audioFragmentsCollection.First().Key);
        }
    }
}
