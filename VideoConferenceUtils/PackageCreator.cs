using System;
using NAudio.Wave;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VideoConferenceCommon;
using VideoConferenceObjects.Interfaces;
using VideoConferenceUtils.Interfaces;

namespace VideoConferenceUtils
{
    /// <summary>
    /// Класс, создающий пакет для отправки
    /// </summary>
    public class PackageCreator : IPackageCreator
    {
        /// <summary>
        /// Фрагмент аудио
        /// </summary>
        private IAudioFragment _audioFragment;

        /// <summary>
        /// Аудиоменеджер
        /// </summary>
        private IAudioManager _audioManager;

        public PackageCreator(IAudioManager audioManager)
        {
            _audioManager = audioManager;
        }

        /// <summary>
        /// Возвращает пакет для отправки
        /// </summary>
        /// <returns></returns>
        public Package GetPackage()
        {
            var audioFragment = _audioManager.GetAndRemoveLocalFragment();
            if (audioFragment == null)
                return null;

            return new Package {AudioData = audioFragment.GetEncodedData()};
        }
    }
}
