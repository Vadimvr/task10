using Presenter.MessageBox;
using System;
using System.IO;
using System.Windows.Forms;

namespace BL
{
    public class OpeFileService
    {
        private IMessageService message;
        public event EventHandler LoadExcelFile;

        public OpeFileService(IMessageService message)
        {
            this.message = message;
        }
        public void Open()
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "E:\\";
                openFileDialog.Filter = "xlsx files (*.xlsx)|*.xlsx";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;
                    if (LoadExcelFile != null) LoadExcelFile(filePath, EventArgs.Empty);
                    message.Show("File Content at path: " + filePath);
                }
            }

        }
    }
}
