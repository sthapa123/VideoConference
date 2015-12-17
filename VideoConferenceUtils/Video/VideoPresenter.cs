using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using AForge.Controls;
using VideoConferenceCommon;
using VideoConferenceGui.Interfaces;
using VideoConferenceObjects;
using VideoConferenceObjects.Interfaces;
using VideoConferenceUtils.Interfaces;

namespace VideoConferenceUtils.Video
{
    public class VideoPresenter : IVideoPresenter
    {
        private IVideoScreen _viewer;

        public VideoPresenter(IVideoScreen videoScreen)
        {
            _viewer = videoScreen;
        }

        /// <summary>
        /// Добавить фрагмент в список воспроизведения
        /// </summary>
        /// <param name="fragment">Информация, для воспроизведения</param>
        public void SetPlayFragment(IDataFragment fragment)
        {
            var videoImage = VideoCoder.Decode(fragment.GetDecodedData());
            ShowImage(videoImage);
        }

        /// <summary>
        /// Показать кадр
        /// </summary>
        /// <param name="image"></param>
        private void ShowImage(Image image)
        {
            _viewer.ShowFrame(image);
        }

        public void Dispose()
        {
            
        }
    }
}
