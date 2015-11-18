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

        
        private void PopUpWindow_Load(object sender, EventArgs e)
        {
            //if (panelChoiseObject1.RowCount > 0)
            //    this.Height = panelChoiseObject1.RowHeight * panelChoiseObject1.RowCount;
            //else
            //    this.Height = Constants.PopUpWindowDefaultHeight;
        }

        private void PopUpWindow_Deactivate(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

    }
}
