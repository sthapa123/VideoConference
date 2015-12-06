using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AForge.Video.DirectShow;
using VideoConferenceUtils.Interfaces;


namespace VideoConferenceUtils.Video
{
    /// <summary>
    /// Сласс, отвечающий за запись видео
    /// </summary>
    public class VideoRecorder : VideoCaptureDevice, IVideoRecorder
    {
        public VideoRecorder(string deviceMoniker) : base (deviceMoniker)
        {
            
        } 

    }
}
