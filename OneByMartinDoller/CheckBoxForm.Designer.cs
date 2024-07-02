namespace OneByMartinDoller
{
    partial class CheckBoxForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Text = "Select Circuits";
            this.ClientSize = new System.Drawing.Size(200, 300);
            List<string> circuitNames = new List<string> { "circuit_1", "circuit_2", "circuit_3", "circuit_4", "circuit_5", "circuit_6", "circuit_7", "circuit_8", "circuit_9", "circuit_10", "circuit_11", "circuit_12", "circuit_13", "circuit_14", "circuit_15" };
            for (int i = 0; i < circuitNames.Count; i++)
            {
                CheckBox checkBox = new CheckBox();
                checkBox.Text = circuitNames[i];
                checkBox.Location = new System.Drawing.Point(10, 20 * (i + 1));
                this.Controls.Add(checkBox);
            }
        }

        #endregion
    }
}