using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VideoConferenceConnection
{
    /// <summary>
    /// Приёмник
    /// </summary>
    public class ContentReceiver
    {
        private TextBox _textBox;

        //todo Удалить ссылку на формы
        public ContentReceiver(TextBox textBox)
        {
            _textBox = textBox;
        }

        public void DisplayMessage(string sender, string message)
        {
            _textBox.Text += "\n " + sender + ": " + message;
        }
    }
}
