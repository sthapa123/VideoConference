using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using NAudio.Wave;
using VideoConferenceUtils.Interfaces;

namespace VideoConferenceUtils.Audio
{
    /// <summary>
    /// Класс, воспроизводящий аудио
    /// </summary>
    public class AudioPlayer : IAudioPlayer
    {
        private IAudioManager _audioManager;

        private Thread playThread;

        public AudioPlayer(IAudioManager audioManager)
        {
            _audioManager = audioManager;
        }

        /// <summary>
        /// Начать процесс воспроизведения аудио
        /// </summary>
        public void StartPlay()
        {
            playThread = new Thread(Playing);
            playThread.Start();
        }

        /// <summary>
        /// Остановить процесс воспроизведения аудио
        /// </summary>
        public void StopPlay()
        {
            playThread.Abort();
        }

        private WaveOut _waveOut;

        private void Playing()
        {
            _waveOut = new WaveOut();
            while (true)
            {
                var fragment = _audioManager.GetAndRemoveFragment();
                var audioFragment = AudioCodec.Decode(fragment, 0, fragment.Length);

                IWaveProvider provider = new RawSourceWaveStream(new MemoryStream(audioFragment), new WaveFormat());

                _waveOut.Init(provider);
                _waveOut.Play();

                while (_waveOut.PlaybackState == PlaybackState.Playing)
                {
                    Thread.Sleep(100);
                }
            }
        }
    }
}
