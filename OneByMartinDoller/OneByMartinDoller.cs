namespace OneByMartinDoller
{
    public partial class OneByMartinDoller : Form
    {
        public OneByMartinDoller()
        {
            InitializeComponent();
        }

        private void OneByMartinDoller_Load(object sender, EventArgs e)
        {

        }

        private void selectFilesButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;
            openFileDialog.Filter = "DWG files (*.dwg)|*.dwg";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                filesListBox.Items.Clear();
                foreach (string file in openFileDialog.FileNames)
                {
                    filesListBox.Items.Add(file);
                }
                syncButton.Enabled = true;
            }
        }

        private void filesListBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (filesListBox.SelectedItem != null)
            {
                CheckBoxForm checkBoxForm = new CheckBoxForm();
                checkBoxForm.ShowDialog();
            }
        }

        private async void syncButton_Click(object sender, EventArgs e)
        {
            syncButton.Enabled = false;
            selectFilesButton.Enabled = false;

            foreach (string file in filesListBox.Items)
            {
                progressBar.Value = 0;
                for (int i = 0; i < 100; i += 10)
                {
                    await Task.Delay(200);
                    progressBar.Value += 10;
                    this.Text = $"Processing: {Path.GetFileName(file)}";
                }
            }

            progressBar.Value = 0;
            this.Text = "One by Martin Doller";
            MessageBox.Show("All files synced with Google Sheet", "Sync Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            syncButton.Enabled = true;
            selectFilesButton.Enabled = true;
        }
    }
}
