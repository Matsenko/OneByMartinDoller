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

            for (int i = 1; i <= 15; i++)
            {
                CheckBox checkBox = new CheckBox();
                checkBox.Text = $"circuit_{i}";
                checkBox.Location = new System.Drawing.Point(10, 20 * i);
                this.Controls.Add(checkBox);
            }
        }

        #endregion
    }
}