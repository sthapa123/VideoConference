using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VideoConferenceObjects.Interfaces
{
    public interface IPackage
    {
        /// <summary>
        /// Время записи фрагментов на передающей стороне
        /// </summary>
        long RecordTime { get; set; }

        /// <summary>
        /// Аудио
        /// </summary>
        byte[] AudioData { get; set; }

        /// <summary>
        /// Видео
        /// </summary>
        byte[] VideoData { get; set; }
    }
}
