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
using VideoConferenceObjects;
using VideoConferenceUtils.Interfaces;


namespace VideoConferenceUtils.Audio
{
    /// <summary>
    /// Класс, выполнающий запись аудио
    /// </summary>
    public class AudioRecorder : WaveIn, IAudioRecorder
    {
        private bool _recording;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="audioManager">Ссылка на менеджер</param>
        /// <param name="timeSpan">Длина записываемого фрагмента</param>
        public AudioRecorder(IAudioManager audioManager, TimeSpan timeSpan)
        {
            BufferMilliseconds = timeSpan.Milliseconds;
            DeviceNumber = 0;
            WaveFormat = AudioCodec.RecordFormat;
        }
    }
}
