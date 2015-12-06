using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using NAudio.Wave;
using VideoConferenceCommon;
using VideoConferenceObjects;
using VideoConferenceObjects.Interfaces;
using VideoConferenceUtils.Interfaces;

namespace VideoConferenceUtils.Audio
{
    /// <summary>
    /// Класс, воспроизводящий аудио
    /// </summary>
    public class AudioPresenter : IAudioPresenter
    {
        private BufferedWaveProvider _provider;
        private WaveOut _waveOut;
        
        public AudioPresenter()
        {
            _waveOut = new WaveOut();
            _provider = new BufferedWaveProvider(AudioCodec.RecordFormat);
            _waveOut.Init(_provider);
            _waveOut.Play();
        }

        /// <summary>
        /// Добавить фрагмент в список воспроизведения
        /// </summary>
        /// <param name="fragment">Информация, для воспроизведения</param>
        public void SetPlayFragment(IDataFragment fragment)
        {
            var decodedData = fragment.GetDecodedData();
            _provider.AddSamples(decodedData, 0, decodedData.Length);
        }
        
        #region IDisposable

        public void Dispose()
        {
            _waveOut.Stop();
            _waveOut.Dispose();
            _waveOut = null;
        }
        #endregion
    }
}
