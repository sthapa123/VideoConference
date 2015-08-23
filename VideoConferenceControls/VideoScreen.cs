using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VideoConferenceControls
{
    public partial class VideoScreen : UserControl
    {
        public VideoScreen()
        {
            InitializeComponent();
        }


        void VideoScreen_Resize(object sender, System.EventArgs e)
        {
            this.Height = (int)(0.75 * this.Width);
        }

    }
}
