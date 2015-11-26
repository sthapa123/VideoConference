using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NAudio;
using NAudio.Wave;

namespace VideoConferenceUtils.Audio
{
    public class AudioManager
    {
        private AudioRecorder _recorder ;
        private Dictionary<DateTime, WaveIn> _audioFragmentsCollection;

        /// <summary>
        /// Флаг активной записи
        /// </summary>
        private bool _record;

        /// <summary>
        /// Максимальное количество фрагментов в колекции
        /// </summary>
        private const int maxFragmentCount = 10;

        public AudioManager()
        {
            _recorder = new AudioRecorder();
            _audioFragmentsCollection = new Dictionary<DateTime, WaveIn>();
        }

        public void StartRecord()
        {
            _record = true;
        }

        public void StopRecord()
        {
            _record = false;
        }


        /// <summary>
        /// Процесс записи
        /// </summary>
        private void Recording()
        {
            while (_record)
            {
                var fragment = _recorder.GetFragment(TimeSpan.FromSeconds(1));
                _audioFragmentsCollection.Add(DateTime.Now, fragment);
                OnCollectionChanged();
            }
        }

        /// <summary>
        /// Событие изменения количества элементов
        /// </summary>
        private void OnCollectionChanged()
        {
            while (_audioFragmentsCollection.Count > maxFragmentCount)
                _audioFragmentsCollection.Remove(_audioFragmentsCollection.First().Key);
        }
    }
}
