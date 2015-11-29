using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VideoConferenceUtils.Interfaces
{
    public interface IAudioPlayer
    {
        /// <summary>
        /// Начать процесс воспроизведения аудио
        /// </summary>
        void StartPlay();
        /// <summary>
        /// Остановить процесс воспроизведения аудио
        /// </summary>
        void StopPlay();
    }
}
