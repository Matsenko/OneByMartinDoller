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
    public partial class CheckBoxForm : Form
    {
        public CheckBoxForm()
        {
            InitializeComponent();
           
            List<string> circuitNames = new List<string> { "circuit_1", "circuit_2", "circuit_3", "circuit_4", "circuit_5", "circuit_6", "circuit_7", "circuit_8", "circuit_9", "circuit_10", "circuit_11", "circuit_12", "circuit_13", "circuit_14", "circuit_15" };
            for (int i = 0; i < circuitNames.Count; i++)
            {
                CheckBox checkBox = new CheckBox();
                checkBox.Text = circuitNames[i];
                checkBox.Location = new System.Drawing.Point(10, 20 * (i + 1));
                this.Controls.Add(checkBox);
            }
        }

    }
}
