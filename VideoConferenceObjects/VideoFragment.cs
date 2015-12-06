using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using VideoConferenceObjects.Interfaces;

namespace VideoConferenceObjects
{
    public class VideoFragment : IVideoFragment
    {
        private byte[] _data;

        public VideoFragment(Image videoImage)
        {
            _data = VideoCoder.Encode(videoImage);
        }

        public VideoFragment(byte[] videoBytes)
        {
            _data = videoBytes;
        }
        
        /// <summary>
        /// Возвращает раскодированную информацию
        /// </summary>
        /// <returns></returns>
        public byte[] GetDecodedData()
        {
            //Если будет применятся какая либо кодировка, то раскодирование будет происходить здесь
            return _data;
        }

        /// <summary>
        /// Возвращает закодированную информацию
        /// </summary>
        /// <returns></returns>
        public byte[] GetEncodedData()
        {
            return _data;
        }
    }
}
