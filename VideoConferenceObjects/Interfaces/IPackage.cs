using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VideoConferenceObjects.Interfaces
{
    public interface IPackage
    {
        /// <summary>
        /// Получить аудио, готовое к воспроизведению
        /// </summary>
        /// <returns>Готовый к воспроизведению аудиофрагмент</returns>
        byte[] GetAudio();
    }
}
