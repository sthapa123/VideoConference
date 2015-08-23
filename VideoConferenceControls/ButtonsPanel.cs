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
    public partial class ButtonsPanel : UserControl
    {
        public ButtonsPanel()
        {
            InitializeComponent();
        }

        private void btnResolution_Click(object sender, EventArgs e)
        {
            DataTable resolutionsTable = new DataTable();
            resolutionsTable.Columns.Add("Resolution");

            foreach (var resolution in Constants.ResolutionsStrings)
            {
                DataRow dataRow = resolutionsTable.NewRow();
                dataRow["Resolution"] = resolution;
                resolutionsTable.Rows.Add(dataRow);
            }


            PopUpWindow resolutionWondow = new PopUpWindow();
            resolutionWondow.DataSource = resolutionsTable;
            resolutionWondow.Show();
        }
    }
}
