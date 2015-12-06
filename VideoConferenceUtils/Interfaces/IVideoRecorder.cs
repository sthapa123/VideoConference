using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using AForge.Video;

namespace VideoConferenceUtils.Interfaces
{
    public interface IVideoRecorder
    {
        /// <summary>
        /// Начать запись видео
        /// </summary>
        void Start();
        /// <summary>
        /// Остановить запись видео
        /// </summary>
        void Stop();

        /// <summary>
        /// Событие готовности нового кадра
        /// </summary>
        event NewFrameEventHandler NewFrame;
    }
}
