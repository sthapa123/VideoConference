using System;
using System.Data;
using System.Windows.Forms;

namespace VideoConferenceControls
{
    public partial class PanelChoiseObject : UserControl
    {
        public PanelChoiseObject()
        {
            InitializeComponent();
        }

        public int RowCount
        {
            get { return dataGridView.RowCount; }
        }

        public int RowHeight
        {
            get
            {
                if (RowCount > 0)
                    return dataGridView.Rows[0].Height;
                else
                    throw new ArgumentOutOfRangeException();
            }
        }

        public DataTable DataSource
        {
            set { dataGridView.DataSource = value; }
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
