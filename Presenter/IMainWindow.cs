using System;
using System.Windows.Forms;

namespace Presenter
{
    public interface IMainWindow
    {
        string Email { get; }
        string Password { get; }
        string Path { get; }
        DataGridView DataGridView { get; }

        event EventHandler Login;
        event EventHandler Register;
        event EventHandler loadDb;
        event EventHandler DeleteRow;
        event EventHandler CellValidatingHandler;
        event EventHandler DataGridViewDataErrorHandler;
        event EventHandler OpenFile;
        event EventHandler UpdateDb;
    }
}
