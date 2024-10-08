﻿using ACadSharp;
using OneByMartinDoller.GoogleSheet;
using OneByMartinDoller.GoogleSheet.Shared;
using OneByMartinDoller.Shared.Services;


namespace OneByMartinDoller
{
    public partial class OneByMartinDoller : Form
    {
        public OneByMartinDoller()
        {
            InitializeComponent();
        }
		private List<string> selectedFilePaths = new List<string>();
		private DwgProccesingService dwgProccesingService = new DwgProccesingService();
		private static List<DwgProcessingModel> DwgProcessingModels = new List<DwgProcessingModel>();
		private  static string _spreadSheetId = "1iZJhM7jzW5cY60JQpOG4YAAadLCbelkus5ebTnxSiVQ";
		private static string _sheetName = "Лист1";
		private  static string _credentialsPath = "credentials.json";
		private  static  string _projectName = "My Project 39375";
		//private GoogleSheetInit _googleSheetInit = new GoogleSheetInit(_spreadSheetId, _sheetName, _credentialsPath, _projectName, DwgProcessingModels);
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
				selectedFilePaths.Clear();
				foreach (string file in openFileDialog.FileNames)
				{
					string fileName = Path.GetFileName(file);
					filesListBox.Items.Add(fileName);
					selectedFilePaths.Add(file); 
				}
				syncButton.Enabled = true;
			}
		}

		private void filesListBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (filesListBox.SelectedItem != null)
            {

                CircuitryLayout circuitryLayout = new CircuitryLayout();
                circuitryLayout.ShowDialog();
            }
        }

       
 private async void syncButton_Click(object sender, EventArgs e)
        {
            syncButton.Enabled = false;
            selectFilesButton.Enabled = false;

            foreach (string file in filesListBox.Items)
            {
                progressBar.Value = 0;
				foreach(string filePath in selectedFilePaths)
				{
					try
					{
						CadDocument cadDocument;
						using (var reader = new ACadSharp.IO.DwgReader(filePath))
						{
							cadDocument = reader.Read();
						}
						var processingResult = dwgProccesingService.GetProccessing(cadDocument);
						foreach (var room in processingResult)
						{
							var cleanedKey = ACadSharp.Examples.Program.ExtractLastValue(room.Key);
							Dictionary<string, int> cleanedValue = new Dictionary<string, int>();
							foreach (var pBlock in room.Value)
							{
								var cleanedPBlockKey = ACadSharp.Examples.Program.ExtractLastValue(pBlock.Key);
								cleanedValue.Add(cleanedPBlockKey, pBlock.Value);
							}
							var cleanedRoomName = ACadSharp.Examples.Program.CleanRoomName(room.Key);
							var viewModel = new DwgProcessingModel
							{
								RoomName = cleanedRoomName,
								PBlocks = cleanedValue
							};

							DwgProcessingModels.Add(viewModel);
						}
						

						for (int i = 0; i < 100; i += 10)
						{

							await Task.Delay(200);
							progressBar.Value += 10;
							this.Text = $"Processing: {Path.GetFileName(file)}";
						}

					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				

				}
				//_googleSheetInit._processingModels=DwgProcessingModels;
				//_googleSheetInit.WriteToGoogleSheet();

			}
            progressBar.Value = 0;
            this.Text = "One by Martin Doller";
            MessageBox.Show("All files synced with Google Sheet", "Sync Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            syncButton.Enabled = true;
            selectFilesButton.Enabled = true;
        }

    }
}
