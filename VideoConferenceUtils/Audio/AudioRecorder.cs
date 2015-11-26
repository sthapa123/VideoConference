using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NAudio.Wave;


namespace VideoConferenceUtils.Audio
{
    /// <summary>
    /// Класс, выполнающий запись аудио
    /// </summary>
    public class AudioRecorder
    {
        public AudioRecorder()
        {
            
        }

        /// <summary>
        /// Возвращает аудиозапись заданного интервала. Запись в реальном времени
        /// </summary>
        /// <param name="timeSpan">Период записи</param>
        public WaveIn GetFragment(TimeSpan timeSpan)
        {
            
        }
    }
}
