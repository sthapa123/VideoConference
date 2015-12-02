using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VideoConferenceConnection.Interfaces;
using VideoConferenceObjects.Interfaces;

namespace VideoConferenceUtils.Interfaces
{
    public interface IAudioManager : IAudioWorker
    {
        /// <summary>
        /// Начать процесс записи звука
        /// </summary>
        void StartAudioRecord();
        /// <summary>
        /// Остановить процесс записи звука
        /// </summary>
        void StopAudioRecord();
        /// <summary>
        /// Начать процесс воспроизведения аудио
        /// </summary>
        void StartAudioPlay();
        /// <summary>
        /// Остановить процесс воспроизведения аудио
        /// </summary>
        void StopAudioPlay();
        /// <summary>
        /// Добавить полученный фрагмент в коллекцию
        /// </summary>
        /// <param name="fragment"></param>
        void AddReceivedFragment(IAudioFragment fragment);
        /// <summary>
        /// Возвращает локальный фрагмент, удаляет его
        /// </summary>
        /// <returns>Фрагмент</returns>
        IAudioFragment GetAndRemoveLocalFragment();
        /// <summary>
        /// Возвращает полученный фрагмент, удаляет его
        /// </summary>
        /// <returns>Фрагмент</returns>
        IAudioFragment GetAndRemoveReceivedFragment();
    }
}
