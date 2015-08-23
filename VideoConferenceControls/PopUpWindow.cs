using System;
using System.Data;
using System.Windows.Forms;

namespace VideoConferenceControls
{
    public partial class PopUpWindow : Form
    {
        public PopUpWindow()
        {
            InitializeComponent();
            this.Location = PointToScreen(MousePosition);
        }

        public DataTable DataSource
        {
            set { panelChoiseObject1.DataSource = value; }
        }

        private void PopUpWindow_Leave(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

    }
}
