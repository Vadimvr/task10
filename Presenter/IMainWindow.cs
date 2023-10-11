﻿using System;
using System.Windows.Forms;

namespace Presenter
{
    public interface IMainWindow
    {
        string Email { get; }
        string Password { get; }
        string Path { get; }
        DataGridView StepsDataGrid { get; }
        DataGridView ModesDataGrid { get; }

        event EventHandler Login;
        event EventHandler Register;
        event EventHandler loadDb;
        event EventHandler DeleteRowSteps;
        event EventHandler DeleteRowModes;
        event EventHandler CellValidatingHandler;
        event EventHandler DataGridViewDataErrorHandler;
        event EventHandler OpenFile;
        event EventHandler UpdateDb;
    }
}
