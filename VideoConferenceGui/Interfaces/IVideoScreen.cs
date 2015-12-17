using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace VideoConferenceGui.Interfaces
{
    public interface IVideoScreen
    {
        /// <summary>
        /// Отобразить кард
        /// </summary>
        /// <param name="image">Кадр</param>
        void ShowFrame(Image image);
    }
}
