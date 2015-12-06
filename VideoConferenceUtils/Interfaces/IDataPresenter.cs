using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VideoConferenceObjects.Interfaces;

namespace VideoConferenceUtils.Interfaces
{
    public interface IDataPresenter
    {
        /// <summary>
        /// Добавить фрагмент в список воспроизведения
        /// </summary>
        /// <param name="data">Информация, для воспроизведения</param>
        void SetPlayFragment(IDataFragment fragment);
    }
}
