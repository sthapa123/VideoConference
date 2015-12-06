using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AForge.Controls;
using VideoConferenceCommon;

namespace VideoConferenceUtils.Interfaces
{
    public interface IContentPlayer
    {
        /// <summary>
        /// Начать процесс воспроизведения информации
        /// </summary>
        void StartPlay(PictureBox videoViewRef);
        /// <summary>
        /// Остановить процесс воспроизведения информации
        /// </summary>
        void StopPlay();
        /// <summary>
        /// Добавить полученный пакет в список воспроизведения
        /// </summary>
        /// <param name="package">Пакет</param>
        void AddPackage(Package package);
    }
}
