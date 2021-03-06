﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using AForge.Controls;
using VideoConferenceCommon;
using VideoConferenceGui.Interfaces;
using VideoConferenceObjects;
using VideoConferenceObjects.Interfaces;
using VideoConferenceUtils.Audio;
using VideoConferenceUtils.Interfaces;
using VideoConferenceUtils.Video;

namespace VideoConferenceUtils
{
    /// <summary>
    /// Класс, отвечающий за воспроизведение информации
    /// </summary>
    public class ContentPlayer : IContentPlayer
    {
        #region Закрытые переменные
        /// <summary>
        /// Экземпляр класса
        /// </summary>
        private static IContentPlayer _contentPlayer;

        /// <summary>
        /// Аудиоплеер
        /// </summary>
        private IAudioPresenter _audioPresenter;

        /// <summary>
        /// Видеоплеер
        /// </summary>
        private IVideoPresenter _videoPresenter;

        /// <summary>
        /// Коллекция 
        /// </summary>
        private SortedDictionary<DateTime, IPackage> _packages; 

        /// <summary>
        /// Поток воспроизведения
        /// </summary>
        private Thread _playThread;
        #endregion

        private ContentPlayer()
        {
            _packages = new SortedDictionary<DateTime, IPackage>();
            _audioPresenter = new AudioPresenter();
        }

        public static IContentPlayer Instance
        {
            get { return _contentPlayer ?? (_contentPlayer = new ContentPlayer()); }
        }

        /// <summary>
        /// Начать процесс воспроизведения
        /// </summary>
        public void StartPlay(IVideoScreen videoScreen)
        {
            _videoPresenter = new VideoPresenter(videoScreen);
            _playThread = new Thread(Playing);
            _playThread.Start();
        }

        /// <summary>
        /// Остановить процесс воспроизведения
        /// </summary>
        public void StopPlay()
        {
            if (_playThread != null && _playThread.IsAlive)
                _playThread.Abort();
        }

        /// <summary>
        /// Добавить полученный пакет к коллекции
        /// </summary>
        /// <param name="package"></param>
        public void AddPackage(IPackage package)
        {
            lock (_packages)
            {
                var time = DateTime.FromBinary(package.RecordTime);
                _packages.Add(time, package);
                OnCollectionChanged();
            }
        }

        /// <summary>
        /// Отдельный поток воспроизведения информации
        /// </summary>
        private void Playing()
        {
            while (true)
            {
                if (_packages.Count < 2)
                {
                    Thread.Sleep(Constants.FragmentLenght);
                    continue;
                }

                TimeSpan sleepTime;

                lock (_packages)
                {

                    var firstFragment = _packages.First();
                    sleepTime = _packages.ElementAt(1).Key - firstFragment.Key;

                    var audioData = firstFragment.Value.AudioData;
                    if (audioData != null)
                        _audioPresenter.SetPlayFragment(
                            new AudioFragment(AudioCodec.Decode(audioData, 0, audioData.Length)));

                    var videoData = firstFragment.Value.VideoData;
                    if (videoData != null)
                        _videoPresenter.SetPlayFragment(new VideoFragment(videoData));

                    _packages.Remove(firstFragment.Key);
                }
                Thread.Sleep(sleepTime);
            }
        }

        public void Dispose()
        {
            if (_playThread != null && _playThread.IsAlive)
                _playThread.Abort();

            if (_audioPresenter != null)
            {
                _audioPresenter.Dispose();
                _audioPresenter = null;
            }

            if (_videoPresenter != null)
            {
                _videoPresenter.Dispose();
                _videoPresenter = null;
            }
        }

        /// <summary>
        /// Событие изменения количества элементов
        /// </summary>
        private void OnCollectionChanged()
        {
            while (_packages.Count > Constants.MaxFragmentCount)
                _packages.Remove(_packages.First().Key);
        }
    }
}
