using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VideoConferenceUtils.Interfaces
{
    public interface IAudioManager
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
        /// Добавить фрагмент в коллекцию
        /// </summary>
        /// <param name="fragment"></param>
        void AddFragment(byte [] fragment);
        /// <summary>
        /// Возвращает фрагмент, удаляет его
        /// </summary>
        /// <returns>Фрагмент</returns>
        byte[] GetAndRemoveFragment();

    }
}
