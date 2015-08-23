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
    public partial class PanelChoiseObject : UserControl
    {
        public PanelChoiseObject()
        {
            InitializeComponent();
        }

        public DataTable DataSource
        {
            set { dataGridView.DataSource = value; }
        }
    }
}
