﻿using Presenter;
using Presenter.MessageBox;
using System;
using System.Windows.Forms;

namespace View
{
    public partial class MainWindow : Form, IMainWindow
    {
        private readonly IMessageService message;
        private IMessageService path;

        public MainWindow(IMessageService message)
        {
            InitializeComponent();
            loginButton.Click += new EventHandler(loginButtonClick);
            RegisterButton.Click += new EventHandler(RegisterButtonClick);
            OpenFileButton.Click += new EventHandler(OpenFileClick);
            UpdateDbButton.Click += new EventHandler(UpdateDbClick);


            var deleteButtonColumn = new DataGridViewButtonColumn();
            dataGridView.CellContentClick += CellContentClick;
            dataGridView.DataError += DataGridViewDataError;
            this.message = message;
        }

        private void UpdateDbClick(object sender, EventArgs e)
        {
            if(UpdateDb!= null) { UpdateDb(sender, e); }
        }

        private void OpenFileClick(object sender, EventArgs e)
        {
            if(OpenFile !=null) { OpenFile(sender, e); }
        }

        private void CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DeleteRow != null) DeleteRow(sender, e);
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

        public DataGridView DataGridView => dataGridView;


        public string Email => emailTextBox.Text;
        public string Password => PasswordTextBox.Text;
        public string Path => throw new NotImplementedException();
        public event EventHandler Login;
        public event EventHandler Register;
        public event EventHandler loadDb;
        public event EventHandler DeleteRow;
        public event EventHandler CellValidatingHandler;
        public event EventHandler DataGridViewDataErrorHandler;
        public event EventHandler OpenFile;
        public event EventHandler UpdateDb;

    }
}