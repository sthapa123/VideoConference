using System;
using NAudio.Wave;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VideoConferenceObjects.Interfaces;

namespace VideoConferenceObjects
{
    /// <summary>
    /// Пакет для отправки
    /// </summary>
    
    public class Package : IPackage
    {
        /// <summary>
        /// Фрагмент аудио
        /// </summary>
        private IAudioFragment _audioFragment;

        public Package(IAudioFragment audioFragment)
        {
            _audioFragment = audioFragment;
        }

        /// <summary>
        /// Получить аудио, готовое к воспроизведению
        /// </summary>
        /// <returns>Готовый к воспроизведению аудиофрагмент</returns>
        public byte[] GetAudio()
        {
            return _audioFragment.GetDecodedData();
        }
    }
}
