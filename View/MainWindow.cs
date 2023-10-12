using Presenter;
using Presenter.MessageBox;
using System;
using System.Windows.Forms;

namespace View
{
    public partial class MainWindow : Form, IMainWindow
    {
        private readonly IMessageService message;

        public event EventHandler Login;
        public event EventHandler Register;
        public event EventHandler DeleteRowSteps;
        public event EventHandler DeleteRowModes;
        public event EventHandler DataGridViewDataErrorHandler;
        public event EventHandler OpenFile;
        public event EventHandler UpdateDb;
        public event EventHandler Unregister;
        public event EventHandler AddStepHandler;
        public event EventHandler AddModeHandler;

        public DataGridView StepsDataGrid => StepsDataGridView;
        public string Email => emailTextBox.Text;
        public string Password => PasswordTextBox.Text;
        public string Path => throw new NotImplementedException();
        public DataGridView ModesDataGrid => ModeDataGridView;

        public MainWindow(IMessageService message)
        {
            InitializeComponent();
            loginButton.Click += new EventHandler(loginButtonClick);
            RegisterButton.Click += new EventHandler(RegisterButtonClick);
            OpenFileButton.Click += new EventHandler(OpenFileClick);
            UpdateDbButton.Click += new EventHandler(UpdateDbClick);

            UnregisterButton.Click += new EventHandler(UnregisterClick);

            AddNewStepButton.Click += (e, s) => AddStepHandler?.Invoke(e, s);
            AddNewModeButton.Click += (e, s) => AddModeHandler?.Invoke(e, s);


            var deleteButtonColumn = new DataGridViewButtonColumn();
            StepsDataGridView.CellContentClick += StepsCellContentClick;
            ModeDataGridView.CellContentClick += ModesCellContentClick;
            StepsDataGridView.DataError += DataGridViewDataError;
            Unregister += SingOut;
            this.message = message;
        }

        System.Drawing.Point x;
        public void SingIn(object sender, EventArgs e)
        {
            // MainTabControl.Location = new System.Drawing.Point(6, 74);
            x = emailTextBox.Location;
            emailTextBox.Location = new System.Drawing.Point(10, x.Y);
            ShowHide();
        }

        public void SingOut(object sender, EventArgs e)
        {
            emailTextBox.Location = x;
            ShowHide();
        }

        private void ShowHide()
        {
            UnregisterButton.Visible = !UnregisterButton.Visible;
            RegisterButton.Visible = !RegisterButton.Visible;
            loginButton.Visible = !loginButton.Visible;
            emailTextBox.Enabled = !emailTextBox.Enabled;
            PasswordTextBox.Visible = !PasswordTextBox.Visible;
            OpenFileButton.Visible = !OpenFileButton.Visible;
            MainTabControl.Visible = !MainTabControl.Visible;
            labelEmail.Visible = !labelEmail.Visible;
            labelPassword.Visible = !labelPassword.Visible;
        }

        private void UnregisterClick(object sender, EventArgs e) => Unregister?.Invoke(sender, e);
        private void ModesCellContentClick(object sender, DataGridViewCellEventArgs e) => DeleteRowModes?.Invoke(sender, e);


        private void UpdateDbClick(object sender, EventArgs e)
        {
            if (UpdateDb != null) { UpdateDb(sender, e); }
        }

        private void OpenFileClick(object sender, EventArgs e)
        {
            if (OpenFile != null) { OpenFile(sender, e); }
        }

        private void StepsCellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DeleteRowSteps != null) DeleteRowSteps(sender, e);
        }

        private void DataGridViewDataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (DataGridViewDataErrorHandler != null) DataGridViewDataErrorHandler(sender, e);
        }

        private void RegisterButtonClick(object s, EventArgs e)
        {
            if (Register != null) Register(s, e);
        }

        private void loginButtonClick(object s, EventArgs e)
        {
            if (Login != null) Login(s, e);
        }
    }
}
