using System;

namespace Presenter
{
    public interface IEditorWindow
    {
        bool Visible { get; set; }
        event EventHandler SaveEntity;
        void ShowEditorWindow(object sender, EventArgs e);

    }
}
