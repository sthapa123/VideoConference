using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VideoConferenceUtils.Interfaces
{
    public interface IAudioRecorder
    {
        /// <summary>
        /// Начать запись
        /// </summary>
        void StartRecording();

        /// <summary>
        /// Остановить запись
        /// </summary>
        void StopRecording();

        void Play();
    }
}
