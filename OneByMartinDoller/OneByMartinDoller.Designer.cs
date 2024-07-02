namespace OneByMartinDoller
{
    partial class OneByMartinDoller
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            selectFilesButton = new Button();
            syncButton = new Button();
            progressBar = new ProgressBar();
            filesListBox = new ListBox();
            SuspendLayout();
            // 
            // selectFilesButton
            // 
            selectFilesButton.Location = new Point(31, 352);
            selectFilesButton.Name = "selectFilesButton";
            selectFilesButton.Size = new Size(153, 29);
            selectFilesButton.TabIndex = 0;
            selectFilesButton.Text = "Select files";
            selectFilesButton.UseVisualStyleBackColor = true;
            selectFilesButton.Click += selectFilesButton_Click;
            // 
            // syncButton
            // 
            syncButton.Enabled = false;
            syncButton.Location = new Point(583, 352);
            syncButton.Name = "syncButton";
            syncButton.Size = new Size(153, 29);
            syncButton.TabIndex = 1;
            syncButton.Text = "Sync";
            syncButton.UseVisualStyleBackColor = true;
            syncButton.Click += syncButton_Click;
            // 
            // progressBar
            // 
            progressBar.Location = new Point(199, 352);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(378, 29);
            progressBar.TabIndex = 2;
            // 
            // filesListBox
            // 
            filesListBox.FormattingEnabled = true;
            filesListBox.Location = new Point(31, 12);
            filesListBox.Name = "filesListBox";
            filesListBox.Size = new Size(218, 224);
            filesListBox.TabIndex = 3;
            filesListBox.MouseDoubleClick += filesListBox_MouseDoubleClick;
            // 
            // OneByMartinDoller
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(filesListBox);
            Controls.Add(progressBar);
            Controls.Add(syncButton);
            Controls.Add(selectFilesButton);
            Name = "OneByMartinDoller";
            Text = "OneByMartinDoller";
            Load += OneByMartinDoller_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button selectFilesButton;
        private Button syncButton;
        private ProgressBar progressBar;
        private ListBox filesListBox;
    }
}
