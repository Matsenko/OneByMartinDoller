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

            Random random = new Random();
            for (int i = 0; i < 5; i++)
            {
                dataGridView1.Rows.Add(
                    false,                  // CheckBox
                    $"Area {i + 1}",        // Area
                    $"Room {random.Next(1, 10)}",    // Room (random room number)
                    $"Fixture {random.Next(100, 200)}",  // Fixture (random fixture number)
                    random.Next(1, 10),     // Quantity (random quantity)
                    $"Circuit {i + 1}",     // CircuitNo
                    random.Next(2) == 0 ? "Yes" : "No", // FirstFix (random "Yes" or "No")
                    $"Notes for row {i + 1}" // Notes
                );
            }
            dataGridView1.EditingControlShowing += DataGridView1_EditingControlShowing;
        }
        private void DataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dataGridView1.CurrentCell.ColumnIndex == dataGridView1.Columns["Quantity"].Index)
            {
                e.Control.KeyPress += new KeyPressEventHandler(QuantityColumn_KeyPress);
            }
            else
            {
                e.Control.KeyPress -= new KeyPressEventHandler(QuantityColumn_KeyPress);
            }

        }
        private void QuantityColumn_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void BOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
