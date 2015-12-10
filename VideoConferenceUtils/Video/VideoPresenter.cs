using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using AForge.Controls;
using VideoConferenceCommon;
using VideoConferenceObjects;
using VideoConferenceObjects.Interfaces;
using VideoConferenceUtils.Interfaces;

namespace VideoConferenceUtils.Video
{
    public class VideoPresenter : IVideoPresenter
    {
        private PictureBox _viewer;
        
        public VideoPresenter(PictureBox pictureBoxRef)
        {
            _viewer = pictureBoxRef;
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
            _viewer.Image = image;
        }

        public void Dispose()
        {
            
        }
    }
}
