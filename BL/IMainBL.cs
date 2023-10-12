using System;

namespace BL
{
    public interface IMainBL
    {
        Authorization Authorization { get; }

        event EventHandler LoadDbHandlerModes;
        event EventHandler LoadDbHandlerSteps;

        event EventHandler SingInHandler;
        event EventHandler StepSaveHandler;
        void OpenFile(object sender, EventArgs e);
        void RemoveEntityModes(object sender, EventArgs e);
        void RemoveEntitySteps(object sender, EventArgs e);
        void StepSave(object sender, EventArgs e);
        void UpdateDb(object sender, EventArgs e);
    }
}
