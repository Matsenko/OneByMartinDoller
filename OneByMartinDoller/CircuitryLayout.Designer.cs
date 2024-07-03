namespace OneByMartinDoller
{
    partial class CircuitryLayout
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
            dataGridView1 = new DataGridView();
            BOk = new Button();
            BCancel = new Button();
            CheckBox = new DataGridViewCheckBoxColumn();
            Area = new DataGridViewTextBoxColumn();
            Room = new DataGridViewTextBoxColumn();
            Fixture = new DataGridViewTextBoxColumn();
            Quantity = new DataGridViewTextBoxColumn();
            CircuitNo = new DataGridViewTextBoxColumn();
            FirstFIx = new DataGridViewComboBoxColumn();
            Notes = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { CheckBox, Area, Room, Fixture, Quantity, CircuitNo, FirstFIx, Notes });
            dataGridView1.Location = new Point(1, 12);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1003, 426);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // BOk
            // 
            BOk.Location = new Point(385, 444);
            BOk.Name = "BOk";
            BOk.Size = new Size(94, 29);
            BOk.TabIndex = 1;
            BOk.Text = "Ok";
            BOk.UseVisualStyleBackColor = true;
            BOk.Click += BOk_Click;
            // 
            // BCancel
            // 
            BCancel.Location = new Point(512, 444);
            BCancel.Name = "BCancel";
            BCancel.Size = new Size(94, 29);
            BCancel.TabIndex = 2;
            BCancel.Text = "Cancel";
            BCancel.UseVisualStyleBackColor = true;
            BCancel.Click += BCancel_Click;
            // 
            // CheckBox
            // 
            CheckBox.HeaderText = "";
            CheckBox.MinimumWidth = 6;
            CheckBox.Name = "CheckBox";
            CheckBox.Width = 125;
            // 
            // Area
            // 
            Area.HeaderText = "Area";
            Area.MinimumWidth = 6;
            Area.Name = "Area";
            Area.Width = 125;
            // 
            // Room
            // 
            Room.HeaderText = "Room";
            Room.MinimumWidth = 6;
            Room.Name = "Room";
            Room.Width = 125;
            // 
            // Fixture
            // 
            Fixture.HeaderText = "Fixture";
            Fixture.MinimumWidth = 6;
            Fixture.Name = "Fixture";
            Fixture.Width = 125;
            // 
            // Quantity
            // 
            Quantity.HeaderText = "Quantity";
            Quantity.MinimumWidth = 6;
            Quantity.Name = "Quantity";
            Quantity.Width = 125;
            // 
            // CircuitNo
            // 
            CircuitNo.HeaderText = "Circuit No.";
            CircuitNo.MinimumWidth = 6;
            CircuitNo.Name = "CircuitNo";
            CircuitNo.Width = 125;
            // 
            // FirstFIx
            // 
            FirstFIx.HeaderText = "FirstFIx";
            FirstFIx.Items.AddRange(new object[] { "Yes", "No" });
            FirstFIx.MinimumWidth = 6;
            FirstFIx.Name = "FirstFIx";
            FirstFIx.Width = 125;
            // 
            // Notes
            // 
            Notes.HeaderText = "Notes";
            Notes.MinimumWidth = 6;
            Notes.Name = "Notes";
            Notes.Width = 125;
            // 
            // CircuitryLayout
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1016, 478);
            Controls.Add(BCancel);
            Controls.Add(BOk);
            Controls.Add(dataGridView1);
            Name = "CircuitryLayout";
            Text = "CircuitryLayout";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private Button BOk;
        private Button BCancel;
        private DataGridViewCheckBoxColumn CheckBox;
        private DataGridViewTextBoxColumn Area;
        private DataGridViewTextBoxColumn Room;
        private DataGridViewTextBoxColumn Fixture;
        private DataGridViewTextBoxColumn Quantity;
        private DataGridViewTextBoxColumn CircuitNo;
        private DataGridViewComboBoxColumn FirstFIx;
        private DataGridViewTextBoxColumn Notes;
    }
}