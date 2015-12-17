using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VideoConferenceCommon;
using VideoConferenceObjects.Interfaces;

namespace VideoConferenceGui.Interfaces
{
    public interface IContentPlayer : IDisposable
    {
        /// <summary>
        /// Начать процесс воспроизведения информации
        /// </summary>
        void StartPlay(IVideoScreen player);
        /// <summary>
        /// Остановить процесс воспроизведения информации
        /// </summary>
        void StopPlay();
        /// <summary>
        /// Добавить полученный пакет в список воспроизведения
        /// </summary>
        /// <param name="package">Пакет</param>
        void AddPackage(IPackage package);
    }
}
