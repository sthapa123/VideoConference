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
        /// Получить фрагмент аудио, готовый к воспроизведению
        /// </summary>
        /// <returns>Фрагмент</returns>
        byte[] GetDecodedData();
    }
}
