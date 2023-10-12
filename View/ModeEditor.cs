using Models;
using Presenter;
using Presenter.MessageBox;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace View
{
    public partial class ModeEditor : Form, IEditorWindow
    {
        private MessageService message;
        private ModeDTO mode;
        private string nameOld;

        public event EventHandler SaveEntity;
        public ModeEditor(MessageService message)
        {
            InitializeComponent();
            this.message = message;
            ExitModeButton.Click += (e, s) => this.Hide();
            SaveModeButton.Click += SaveModeClick;
            this.FormClosing += MainForm_Closing;
        }

        private void MainForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void SaveModeClick(object sender, EventArgs e)
        {
            int modeID = this.mode.Mode.ID;
            string name = ModeNameTextBox.Text;
            int maxBottleNumber;
            int maxUsedTips;
            if (!int.TryParse(MaxBottleNumberTextBox.Text, out maxBottleNumber))
            {
                message.Show("Max Bottle Number must be a number");
                return;
            }
            else if (maxBottleNumber < 0)
            {
                message.Show("The maximum number of bottles must be above zero.");
                return;
            }

            if (!int.TryParse(MaxUsedTipsTextBox.Text, out maxUsedTips))
            {
                message.Show("Max Used Tips must be a number");
                return;
            }
            else if (maxUsedTips < 0)
            {
                message.Show("The maximum number of tips used must be greater than zero.");
                return;
            }
            else if (string.IsNullOrWhiteSpace(name))
            {
                message.Show("Type cannot be empty");
                return;
            }
            else if (!nameOld.Equals(name, StringComparison.CurrentCultureIgnoreCase) &&
                    mode.Names.FirstOrDefault(m => m.Equals(name, StringComparison.CurrentCultureIgnoreCase)) != null)
            {
                message.Show("The name must be unique.");
                return;
            }

            else
            {
                var stepNew = new Mode()
                {
                    ID = mode.Mode.ID,
                    Name = name,
                    MaxBottleNumber = maxBottleNumber,
                    MaxUsedTips = maxUsedTips,
                };
                SaveEntity?.Invoke(stepNew, e);
                this.Hide();
            }
        }



        public void ShowEditorWindow(object sender, EventArgs e)
        {
            this.Show();

            if (sender is ModeDTO)
            {

                mode = (ModeDTO)sender;
                this.nameOld = mode.Mode.Name ?? string.Empty;
                ModeIdLabel.Text = mode.Mode.ID.ToString();
                ModeNameTextBox.Text = mode.Mode.Name;
                MaxBottleNumberTextBox.Text = mode.Mode.MaxBottleNumber.ToString();
                MaxUsedTipsTextBox.Text = mode.Mode.MaxBottleNumber.ToString();
            }
        }
    }
}
