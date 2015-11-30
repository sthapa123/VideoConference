using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VideoConferenceObjects.Interfaces;

namespace VideoConferenceObjects
{
    /// <summary>
    /// Фрагмент аудио, входящий в пакет
    /// </summary>
    public class AudioFragment : IAudioFragment
    {
        private const int Offset = 0;

        /// <summary>
        /// Основная аудиоинформация
        /// </summary>
        private byte[] data;

        public AudioFragment(byte[] buffer)
        {
            data = AudioCodec.Encode(buffer, 0, buffer.Length);
        }

        /// <summary>
        /// Получить фрагмент аудио, готовый к воспроизведению
        /// </summary>
        /// <returns>Фрагмент</returns>
        public byte[] GetDecodedData()
        {
            return AudioCodec.Decode(data, 0, data.Length);
        }
    }
}
