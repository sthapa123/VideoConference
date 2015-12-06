using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VideoConferenceUtils.Audio;

namespace VideoConferenceUtils
{
    public static class ContentSynchronizer
    {
        private static DateTime _currentAudioTime;

        /// <summary>
        /// Возвращает время текущего аудио
        /// </summary>
        /// <returns></returns>
        public static DateTime GetAudioDateTime()
        {
            return _currentAudioTime;
        }

        /// <summary>
        /// Установить время текущего аудио
        /// </summary>
        /// <param name="curTime"></param>
        public static void SetAudioDateTime(DateTime curTime)
        {
            _currentAudioTime = curTime;
        }

    }
}
