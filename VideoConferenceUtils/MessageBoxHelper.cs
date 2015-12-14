using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VideoConferenceUtils
{
    public static class MessageBoxHelper
    {
        public static void ShowMessage(string message, params object[] parameters)
        {
            var showMessage = string.Format(message, parameters);
            MessageBox.Show(showMessage);
        }
    }
}
