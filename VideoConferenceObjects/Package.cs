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
        /// Время начала аудио
        /// </summary>
        private DateTime _starTime;
        /// <summary>
        /// Время конца аудио
        /// </summary>
        private DateTime _endTime;

        public Package()
        {
            
        }
    }
}
