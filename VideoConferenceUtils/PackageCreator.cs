using System;
using NAudio.Wave;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VideoConferenceCommon;
using VideoConferenceGui.Interfaces;
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
        /// Аудиоменеджер
        /// </summary>
        private IAudioManager _audioManager;

        /// <summary>
        /// Видеоменеджер
        /// </summary>
        private IVideoManager _videoManager;

        public PackageCreator(IAudioManager audioManager, IVideoManager videoManager)
        {
            _audioManager = audioManager;
            _videoManager = videoManager;
        }

        /// <summary>
        /// Возвращает пакет для отправки
        /// </summary>
        /// <returns>Пакет, готовый к отправке</returns>
        public IPackage GetPackage()
        {
            var audioPair = _audioManager.GetAndRemoveLocalFragment(DateTime.Now);
            if (audioPair.Value == null)
                return null;
            var time = audioPair.Key;
            
            var videoPair = _videoManager.GetAndRemoveLocalFragment(time);
            var videoFragment = videoPair.Value == null ? null : videoPair.Value.GetEncodedData();

            return new Package
            {
                RecordTime = time.ToBinary(),
                AudioData = audioPair.Value.GetEncodedData(),
                VideoData = videoFragment
            };
        }
    }
}
