using System;
using System.Collections.Generic;
using VideoConferenceObjects.Interfaces;

namespace VideoConferenceGui.Interfaces
{
    public interface IContentManager
    {
        /// <summary>
        /// Начать процесс записи информации
        /// </summary>
        void StartRecord();

        /// <summary>
        /// Остановить процесс записи информации
        /// </summary>
        void StopRecord();

        /// <summary>
        /// Возвращает локальный фрагмент информации, удаляет его.
        /// Используется во время передачи информации
        /// </summary>
        /// <returns>Фрагмент</returns>
        KeyValuePair<DateTime, IDataFragment> GetAndRemoveLocalFragment(DateTime curTime);
    }
}
