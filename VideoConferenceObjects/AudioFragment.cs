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
        private byte[] _data;

        /// <summary>
        /// При создании фрагмента, информация кодируется
        /// </summary>
        /// <param name="buffer">Незакодированная информация</param>
        public AudioFragment(byte[] buffer)
        {
            _data = buffer;
        }

        /// <summary>
        /// Получить фрагмент аудио, готовый к воспроизведению (раскодированный)
        /// </summary>
        /// <returns>Фрагмент</returns>
        public byte[] GetDecodedData()
        {
            return _data;
        }

        /// <summary>
        /// Получить фрагмент аудио, готовый к передаче по сети (закодированный)
        /// </summary>
        /// <returns>Фрагмент</returns>
        public byte[] GetEncodedData()
        {
            return AudioCodec.Encode(_data, 0, _data.Length);
        }
    }
}
