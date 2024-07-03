using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OneByMartinDoller
{
    public partial class CircuitryLayout : Form
    {
        public CircuitryLayout()
        {
            InitializeComponent();

            this.MaximizeBox = false;
            this.MinimizeBox = false;

            FillDataGridView1();
        }

        private void FillDataGridView1()
        {

            dataGridView1.Rows.Add(false, "Ground Floor", "Landscape", "FX1", 4, "EX.A1", "Yes", "");
            dataGridView1.Rows.Add(false, "", "B1", "", 3, "EX.A2", "No", "");
            dataGridView1.Rows.Add(false, "", "GB1", "", 6, "EX.A3", "No", "");
            dataGridView1.Rows.Add(false, "Restroom", "AX1", "", 1, "GF.A1", "No", "");
            dataGridView1.Rows.Add(false, "Kitchenette", "AX1", "", 1, "GF.A2", "No", "");
            dataGridView1.Rows.Add(false, "Zoom Room", "A1", "", 2, "GF.A3", "No", "");
            dataGridView1.Rows.Add(false, "Exhibition Room", "B1", "", 2, "GF.B1", "No", "");
            dataGridView1.Rows.Add(false, "", "A1", "", 7, "GF.B2", "No", "");
            dataGridView1.Rows.Add(false, "Entrance", "W1", "", 2, "GF.C1", "Yes", "");
            dataGridView1.Rows.Add(false, "", "A1", "", 2, "GF.C2", "No", "");
            dataGridView1.Rows.Add(false, "First Floor", "Boardroom", "W1", "", 2, "FF.A1", "Yes", "");
            dataGridView1.Rows.Add(false, "", "A1", "", 5, "FF.A2", "No", "");
        }

        private void BOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
