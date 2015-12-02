using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VideoConferenceObjects.Interfaces
{
    /// <summary>
    /// Фрагмент аудио, входящий в пакет
    /// </summary>
    public interface IAudioFragment
    {
        /// <summary>
        /// Получить фрагмент аудио, готовый к воспроизведению (раскодированный)
        /// </summary>
        /// <returns>Фрагмент</returns>
        byte[] GetDecodedData();

        /// <summary>
        /// Получить фрагмент аудио, готовый к передаче по сети (закодированный)
        /// </summary>
        /// <returns>Фрагмент</returns>
        byte[] GetEncodedData();
    }
}
