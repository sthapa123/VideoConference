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
        /// Коллексия фрагментов
        /// </summary>
        private Dictionary<DateTime, IAudioFragment> _audioFragmentsCollection;

        private IContentSender _sender;
        #endregion
        
        private AudioManager()
        {
            _recorder = new AudioRecorder(this, TimeSpan.FromMilliseconds(FragmentLenght));
            _recorder.DataAvailable += _recorder_DataAvailable;
            _player = new AudioPlayer(this);
            _audioFragmentsCollection = new Dictionary<DateTime, IAudioFragment>();
        }

        private void _recorder_DataAvailable(object sender, WaveInEventArgs e)
        {
            
        }

        public static IAudioManager Instance
        {
            get { return _audioManager ?? (_audioManager = new AudioManager()); }
        }

        public void SendFragment(IAudioFragment fragment)
        {
            var package = new Package(fragment);
            _sender.SendPackage(package);
        }

        /// <summary>
        /// Добавить фрагмент аудио в коллекцию
        /// </summary>
        /// <param name="fragment">Аудио фрагмент</param>
        public void AddFragment(IAudioFragment fragment)
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
        public IAudioFragment GetAndRemoveFragment()
        {
            lock (_audioFragmentsCollection)
            {
                if (_audioFragmentsCollection.Count == 0)
                    return null;
                var fragment = _audioFragmentsCollection.First().Value;
                _audioFragmentsCollection.Remove(_audioFragmentsCollection.First().Key);

                return fragment;
            }
        }

        /// <summary>
        /// Начать процесс записи аудио
        /// </summary>
        public void StartAudioRecord(IContentSender sender)
        {
            _sender = sender;
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
        private void OnCollectionChanged()
        {
            while (_audioFragmentsCollection.Count > MaxFragmentCount)
                _audioFragmentsCollection.Remove(_audioFragmentsCollection.First().Key);
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
