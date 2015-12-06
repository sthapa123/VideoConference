using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AForge.Controls;
using VideoConferenceObjects.Interfaces;

namespace VideoConferenceUtils.Interfaces
{
    /// <summary>
    /// Менеджер видеофрагментов
    /// </summary>
    public interface IVideoManager : IContentManager, IVideoWorker
    {

    }
}
