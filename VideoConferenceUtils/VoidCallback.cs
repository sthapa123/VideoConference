using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VideoConferenceUtils
{
    public class VoidCallback
    {
        public delegate void CallBack();

        private CallBack _callBack;

        public VoidCallback(CallBack callback)
        {
            _callBack = callback;
        }

        public void Invoke()
        {
            _callBack.Invoke();
        }
    }
}
