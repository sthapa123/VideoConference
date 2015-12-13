using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VideoConferenceObjects.Interfaces;

namespace VideoConferenceConnection.Interfaces
{
    public interface IContentSender
    {
        /// <summary>
        /// Начать отправку информации
        /// </summary>
        void StartSending();

        /// <summary>
        /// Остановить отправку информации
        /// </summary>
        void StopSending();
    }
}
