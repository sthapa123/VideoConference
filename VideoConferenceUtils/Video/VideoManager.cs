using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using AForge.Controls;
using AForge.Video.DirectShow;
using NLog;
using VideoConferenceCommon;
using VideoConferenceGui.Interfaces;
using VideoConferenceObjects;
using VideoConferenceObjects.Interfaces;
using VideoConferenceUtils.Interfaces;

namespace VideoConferenceUtils.Video
{
    /// <summary>
    /// Менеджер видеофрагментов, синглтон
    /// </summary>
    public class VideoManager : IVideoManager
    {
        #region Логгирование
        private static Logger log = LogManager.GetCurrentClassLogger();
        #endregion

        private static IVideoManager _videoManager;
        private IVideoRecorder _videoRecorder;
        private int _failCount;
        
        /// <summary>
        /// Коллекция локальных кадров
        /// </summary>
        private IDataFragmentCollection _localImages;
        
        private VideoManager()
        {
            _localImages = new DataFragmentCollection();
            _failCount = 0;

            SetRecorderSettings();
        }
        
        public static IVideoManager Instance
        {
            get { return _videoManager ?? (_videoManager = new VideoManager()); }
        }

        /// <summary>
        /// Начать процесс записи видео
        /// </summary>
        public void StartRecord()
        {
            _localImages.Clear();
            _videoRecorder.Start();
        }

        /// <summary>
        /// Остановить процесс записи видео
        /// </summary>
        public void StopRecord()
        {
            _videoRecorder.Stop();
        }

        /// <summary>
        /// Возвращает фрагмент видео, подходящий под заданное время
        /// </summary>
        /// <param name="currentTime">Текущее время</param>
        /// <returns>Фрагмент видео, null - если нет видео, подходящего под текущее время</returns>
        public KeyValuePair<DateTime, IDataFragment> GetAndRemoveLocalFragment(DateTime currentTime)
        {
            foreach (var item in _localImages.Items)
            {
                if (item.Key > currentTime ||
                    item.Key + TimeSpan.FromMilliseconds(Constants.FragmentLenght) < currentTime)
                    continue;
                var videoFragment = item;
                _localImages.Remove(item.Key);
                _failCount = 0;
                return videoFragment;
            }

            if (_failCount++ > 10)
                _localImages.Clear();
            return new KeyValuePair<DateTime, IDataFragment>();
        }

        /// <summary>
        /// Обработка события готовности нового кадра
        /// </summary>
        private void videoRecorder_NewFrame(object sender, AForge.Video.NewFrameEventArgs e)
        {
            _localImages.Add(DateTime.Now, new VideoFragment(e.Frame));
        }

        /// <summary>
        /// Установить настройки записывающего устройства
        /// </summary>
        private void SetRecorderSettings()
        {
            //Позже можно будет настраивать
            var devicesCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            if (devicesCollection.Count == 0)
                throw new Exception("Нет вебки");

            _videoRecorder = new VideoRecorder(devicesCollection[0].MonikerString);
            _videoRecorder.NewFrame += videoRecorder_NewFrame;
        }

        #region IDisposable
        public void Dispose()
        {
            if (_videoRecorder != null)
            {
                _videoRecorder.Stop();
                _videoRecorder = null;
            }
        }
        #endregion
    }
}
