using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VideoConferenceObjects.Interfaces
{
    public interface IDataFragment
    {
        /// <summary>
        /// Возвращает фрагмент информации, готовый к передаче по сети (закодированный)
        /// </summary>
        /// <returns></returns>
        byte[] GetEncodedData();

        /// <summary>
        /// Получить фрагмент информации, готовый к воспроизведению (раскодированный)
        /// </summary>
        /// <returns>Фрагмент</returns>
        byte[] GetDecodedData();
    }
}
