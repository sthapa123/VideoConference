using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VideoConferenceGui.Interfaces;

namespace VideoConferenceControls
{
    public partial class VideoScreen : UserControl, IVideoScreen
    {
        public VideoScreen()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Отобразить кадр
        /// </summary>
        /// <param name="image">Кадр</param>
        public void ShowFrame(Image image)
        {
            pictureBox1.Image = image;
        }
    }
}
