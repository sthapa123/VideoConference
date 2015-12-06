using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using VideoConferenceCommon;
using VideoConferenceObjects.Interfaces;

namespace VideoConferenceCommon
{
    /// <summary>
    /// DTO объект передачи
    /// </summary>
    [DataContract]
    public class Package
    {
        /// <summary>
        /// Время записи фрагментов на передающей стороне
        /// </summary>
        [DataMember]
        public long RecordTime { get; set; }

        /// <summary>
        /// Аудио
        /// </summary>
        [DataMember]
        public byte[] AudioData { get; set; }

        /// <summary>
        /// Видео
        /// </summary>
        [DataMember]
        public byte[] VideoData { get; set; }
    }
}
