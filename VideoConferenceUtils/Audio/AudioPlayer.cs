using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using NAudio.Wave;
using VideoConferenceObjects;
using VideoConferenceUtils.Interfaces;

namespace VideoConferenceUtils.Audio
{
    /// <summary>
    /// Класс, воспроизводящий аудио
    /// </summary>
    public class AudioPlayer : IAudioPlayer
    {
        private IAudioManager _audioManager;

        private Thread _playThread;
        
        private BufferedWaveProvider _provider;
        private WaveOut _waveOut;


        public AudioPlayer(IAudioManager audioManager)
        {
            _audioManager = audioManager;
        }

        /// <summary>
        /// Начать процесс воспроизведения аудио
        /// </summary>
        public void StartPlay()
        {
            _waveOut = new WaveOut();
            _provider = new BufferedWaveProvider(AudioCodec.RecordFormat);
            _waveOut.Init(_provider);
            _waveOut.Play();
            _playThread = new Thread(Playing);
            _playThread.Start();
        }

        /// <summary>
        /// Остановить процесс воспроизведения аудио
        /// </summary>
        public void StopPlay()
        {
            _playThread.Abort();
        }
        
        private void Playing()
        {
            while (true)
            {
                var fragment = _audioManager.GetAndRemoveFragment();
                if (fragment == null)
                {
                    Thread.Sleep(50);
                    continue;
                }
                var audioFragment = fragment.GetDecodedData();

                _provider.AddSamples(audioFragment, 0, audioFragment.Length);
            }
        }

        #region IDisposable

        public void Dispose()
        {
            if (_playThread != null)
            {
                _playThread.Abort();
                _playThread = null;
            }
            _waveOut.Stop();
            _waveOut.Dispose();
            _waveOut = null;
        }
        #endregion
    }
}
