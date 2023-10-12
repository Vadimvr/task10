using Models;
using Presenter;
using Presenter.MessageBox;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace View
{
    public partial class StepsEditor : Form, IEditorWindow
    {
        private StepDTO step;
        private IMessageService message;

        public event EventHandler SaveEntity;


        public StepsEditor(IMessageService message)
        {
            InitializeComponent();
            SaveSteps.Click += new EventHandler(SaveStepsClick);

            ExitStepsEditor.Click += new EventHandler(ExitStepEditor);
            this.message = message;
        }


        private void ExitStepEditor(object sender, EventArgs e) => this.Hide();

        private void SaveStepsClick(object sender, EventArgs e)
        {
            int modeID = this.step.Step.ID;
            int timer;
            int speed;
            string _type = TypeTextBox.Text;
            int volume;
            string destination = DestinationTextBox.Text;

            if (!int.TryParse(ModelIdComboBox.SelectedItem.ToString(), out modeID))
            {
                message.Show("ModeId must be a number");
                return;
            }
            else if (!int.TryParse(TimerTextBox.Text, out timer))
            {
                message.Show("Timer must be a number");
                return;
            }
            else if (!int.TryParse(SpeedTextBox.Text, out speed))
            {
                message.Show("Speed must be a number");
                return;
            }
            else if (string.IsNullOrWhiteSpace(TypeTextBox.Text))
            {
                message.Show("Type cannot be empty");
                return;
            }
            else if (!int.TryParse(VolumeTextBox.Text, out volume))
            {
                message.Show("Volume must be a number");
                return;
            }
            else
            {
                var stepNew = new Step()
                {
                    ID = step.Step.ID,
                    ModeID = modeID,
                    Timer = timer,
                    Destination = destination,
                    Speed = speed,
                    Type = _type,
                    Volume = volume,
                };
                SaveEntity?.Invoke(stepNew, e);
                this.Hide();
            }
        }

       


        public void ShowEditorWindow(object sender, EventArgs e)
        {
            this.Show();

            if (sender is StepDTO)
            {

                this.step = (StepDTO)sender;
                var oldSV = ModelIdComboBox.SelectedValue;
                for (int i = 0; i < step.Modes.Count; i++)
                {
                    int item = step.Modes[i];
                    ModelIdComboBox.Items.Add(item);
                    if (item == step.Step.ModeID)
                    {
                        ModelIdComboBox.SelectedIndex = i;
                    }
                }

                StepsIdlabel.Text = step.Step.ID.ToString();

                if (ModelIdComboBox.SelectedValue == oldSV && ModelIdComboBox.Items.Count > 0)
                {
                    ModelIdComboBox.SelectedValue = 0;
                    ModelIdComboBox.Text = ModelIdComboBox.Items[0].ToString();
                }
                else
                {
                    ModelIdComboBox.Text = step.Step.ModeID.ToString();
                }


                TimerTextBox.Text = step.Step.Timer.ToString();
                DestinationTextBox.Text = step.Step.Destination;
                SpeedTextBox.Text = step.Step.Speed.ToString();
                TypeTextBox.Text = step.Step.Type;
                VolumeTextBox.Text = step.Step.Volume.ToString();

            }
            else
            {
                throw new ArgumentException(nameof(sender));
            }
        }
    }
}
