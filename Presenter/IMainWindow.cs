using System;
using System.Windows.Forms;

namespace Presenter
{
    public interface IMainWindow
    {
        event EventHandler Login;
        event EventHandler Register;
        event EventHandler DeleteRowSteps;
        event EventHandler DeleteRowModes;
        event EventHandler DataGridViewDataErrorHandler;
        event EventHandler OpenFile;
        event EventHandler UpdateDb;
        event EventHandler Unregister;
        string Email { get; }
        string Password { get; }
        string Path { get; }
        DataGridView StepsDataGrid { get; }
        DataGridView ModesDataGrid { get; }

        void SingIn(object sender, EventArgs e);
        void SingOut(object sender, EventArgs e);
    }
}
