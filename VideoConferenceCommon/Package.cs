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
        /// Аудио
        /// </summary>
        [DataMember]
        public byte[] AudioData { get; set; }
    }
}
