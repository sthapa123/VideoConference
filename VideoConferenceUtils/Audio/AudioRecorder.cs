using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using NAudio.Codecs;
using NAudio.MediaFoundation;
using NAudio.Wave;
using VideoConferenceUtils.Interfaces;


namespace VideoConferenceUtils.Audio
{
    /// <summary>
    /// Класс, выполнающий запись аудио
    /// </summary>
    public class AudioRecorder : IAudioRecorder
    {
        private IAudioManager _audioManager;
        private WaveIn _waveIn;
        private Stream _stream;

        private WaveFileWriter _writer;
        
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="audioManager">Ссылка на менеджер</param>
        /// <param name="timeSpan">Длина записываемого фрагмента</param>
        public AudioRecorder(IAudioManager audioManager, TimeSpan timeSpan)
        {
            _audioManager = audioManager;
            _stream = new MemoryStream();
            _writer = new WaveFileWriter(_stream, AudioCodec.RecordFormat);
            InitRecorder(timeSpan);

        }

        private void InitRecorder(TimeSpan timeSpan)
        {
            _waveIn = new WaveIn();
            _waveIn.BufferMilliseconds = timeSpan.Milliseconds;
            _waveIn.DeviceNumber = 0;
            _waveIn.WaveFormat = AudioCodec.RecordFormat;
            _waveIn.DataAvailable += _waveIn_DataAvailable;
            _waveIn.RecordingStopped += _waveIn_RecordingStopped;
        }
        
        private void _waveIn_DataAvailable(object sender, WaveInEventArgs e)
        {
            //todo Сделать класс фрагмента аудио, в котором будет кодирование и декодирование. Кодирование при созданииы
            //_audioManager.AddFragment(AudioCodec.Encode(e.Buffer, 0, e.BytesRecorded));
            _writer.Write(e.Buffer, 0, e.BytesRecorded);
        }

        private void _waveIn_RecordingStopped(object sender, StoppedEventArgs e)
        {

        }

        public void Play()
        {
            var _waveOut = new WaveOut();
            _stream.Position = 0;
            IWaveProvider provider = new RawSourceWaveStream(_stream, AudioCodec.RecordFormat);

            _waveOut.Init(provider);
            _waveOut.Play();
        }

        /// <summary>
        /// Начать запись
        /// </summary>
        public void StartRecording()
        {
            _waveIn.StartRecording();
        }
        
        /// <summary>
        /// Закончить запись
        /// </summary>
        public void StopRecording()
        {
            _waveIn.StopRecording();
        }
    }
}
