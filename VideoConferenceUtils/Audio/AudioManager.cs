using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NAudio;
using NAudio.Wave;
using NLog;
using VideoConferenceCommon;
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
        /// Экземпляр класа
        /// </summary>
        private static IAudioManager _audioManager;

        /// <summary>
        /// Класс записи аудио
        /// </summary>
        private IAudioRecorder _recorder;

        private bool _recording;

        /// <summary>
        /// Коллексия фрагментов, записанных локально
        /// </summary>
        private IDataFragmentCollection _localAudio;
        #endregion
        
        private AudioManager()
        {
            _recorder = new AudioRecorder(this, TimeSpan.FromMilliseconds(Constants.FragmentLenght));
            _localAudio = new DataFragmentCollection();

            _recorder.DataAvailable += recorder_DataAvailable;
        }

        public static IAudioManager Instance
        {
            get { return _audioManager ?? (_audioManager = new AudioManager()); }
        }

        /// <summary>
        /// Возвращает локальный фрагмент, удаляет его
        /// </summary>
        /// <returns>Фрагмент</returns>
        public KeyValuePair<DateTime, IDataFragment> GetAndRemoveLocalFragment(DateTime curTime)
        {
            //Сделать проверку текущего времени curTime с фрагментами, если слишком большой расснихрон, то что то делать

            return _localAudio.GetAndRemoveFirstFragment();
        }

        /// <summary>
        /// Начать процесс записи аудио
        /// </summary>
        public void StartRecord()
        {
            if (!_recording)
            {
                _localAudio.Clear();
                _recorder.StartRecording();
            }
            _recording = true;
        }

        /// <summary>
        /// Остановить процесс записи аудио
        /// </summary>
        public void StopRecord()
        {
            if (_recording)
                _recorder.StopRecording();
            _recording = false;
        }

        /// <summary>
        /// Событий готовности аудио фрагмента
        /// </summary>
        private void recorder_DataAvailable(object sender, WaveInEventArgs e)
        {
            _localAudio.Add(DateTime.Now, new AudioFragment(e.Buffer));
        }

        #region IDisposable

        public void Dispose()
        {
            if (_recorder != null)
            {
                _recorder.Dispose();
                _recorder = null;
            }
        }
        #endregion
    }
}
