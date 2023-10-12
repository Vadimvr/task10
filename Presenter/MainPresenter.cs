using BL;
using Models;
using Presenter.MessageBox;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace Presenter
{
    public class MainPresenter
    {
        readonly IMainWindow view = null;
        private readonly IEditorWindow stepsEditor;
        readonly IMainBL bl = null;
        readonly IMessageService message = null;

        //public event EventHandler SingInHandler;
        //public event EventHandler SingOutHandler;
        public event EventHandler ShowEditorStepWindow;
        public event EventHandler ShowEditorModeWindow;

        List<Step> stepsOldList;
        List<Mode> modesOldList;

        BindingList<Step> dsSteps;
        BindingList<Mode> dsModes;

        public MainPresenter(IMainWindow view, IEditorWindow stepEditor, IEditorWindow modeEditor, IMainBL bl, IMessageService message)
        {
            this.view = view;
            this.stepsEditor = stepEditor;
            //SingInHandler += this.view.SingIn;
            //SingOutHandler += this.view.SingOut;

            ShowEditorStepWindow += stepEditor.ShowEditorWindow;
            stepEditor.SaveEntity += bl.StepSave;

            ShowEditorModeWindow += modeEditor.ShowEditorWindow;
            modeEditor.SaveEntity += bl.StepSave;

            this.message = message;
            this.bl = bl;
            this.bl.SingInHandler += this.view.SingIn;

            this.view.Unregister += ClearAllDataGrid;

            this.view.Login += new EventHandler(Login);
            this.view.Register += new EventHandler(Register);

            this.bl.LoadDbHandlerSteps += new EventHandler(LoadDataBaseSteps);
            this.bl.LoadDbHandlerModes += new EventHandler(LoadDataBaseModes);
            this.view.DeleteRowSteps += new EventHandler(RemoveEntitySteps);
            this.view.DeleteRowModes += new EventHandler(RemoveEntityModes);
            this.view.AddStepHandler += AddNewStep;
            this.view.AddModeHandler += AddNewMode;
            this.view.UpdateDb += bl.UpdateDb;
            this.view.OpenFile += bl.OpenFile;

            this.view.DataGridViewDataErrorHandler += new EventHandler(DataGridViewDataError);
        }

        private void AddNewMode(object sender, EventArgs e)
        {
            ModeDTO modeDto = new ModeDTO() { Mode = new Mode(), Names = dsModes.Select(x => x.Name).ToList() };
            ShowEditorModeWindow?.Invoke(modeDto, e);
        }

        private void AddNewStep(object sender, EventArgs e)
        {
            StepDTO modeDto = new StepDTO() { Step = new Step(), Modes = dsModes.Select(x => x.ID).ToList() };
            ShowEditorStepWindow?.Invoke(modeDto, e);
        }

        private void RemoveEntityModes(object sender, EventArgs args)
        {
            var e = (DataGridViewCellEventArgs)args;
            if (this.view.ModesDataGrid.Columns[e.ColumnIndex].HeaderText == "Delete" && e.RowIndex < dsModes.Count && e.RowIndex >= 0)
            {
                int temp = e.RowIndex;
                int i = -1;
                if (int.TryParse(temp.ToString(), out i) && i != -1 && i < modesOldList.Count)
                {
                    var id = dsModes[i].ID;
                    dsModes.RemoveAt(i);
                    bl.RemoveEntityModes(id, e);
                }
            }
            if (this.view.ModesDataGrid.Columns[e.ColumnIndex].HeaderText == "Edit" && e.RowIndex < dsModes.Count && e.RowIndex >= 0)
            {
                if (stepsEditor == null)
                {

                }
                int temp = e.RowIndex;

                int i = -1;
                if (int.TryParse(temp.ToString(), out i) && i != -1 && i < stepsOldList.Count)
                {
                    ModeDTO modeDto = new ModeDTO() { Mode = dsModes[i], Names = dsModes.Select(x => x.Name).ToList() };
                    ShowEditorModeWindow?.Invoke(modeDto, e);
                }
            }
        }

        private void DataGridViewDataError(object sender, EventArgs ea)
        {
            DataGridViewDataErrorEventArgs e = (DataGridViewDataErrorEventArgs)ea;
            // format ex
            var allowedColors = DataGridViewDataErrorContexts.Parsing | DataGridViewDataErrorContexts.Commit | DataGridViewDataErrorContexts.CurrentCellChange;
            var dataGrid = ((DataGridView)sender);
            if (e.Context == allowedColors)
            {
                message.Show($"ошибка формата данных new = \"{dataGrid.EditingControl.Text}\" old = \"{((DataGridView)sender).CurrentCell.FormattedValue}\"");
                dataGrid.EditingControl.Text = ((DataGridView)sender).CurrentCell.FormattedValue.ToString();
                return;
            }
        }

        private void RemoveEntitySteps(object sender, EventArgs arg)
        {

            var e = (DataGridViewCellEventArgs)arg;
            if (this.view.StepsDataGrid.Columns[e.ColumnIndex].HeaderText == "Delete" && e.RowIndex < dsSteps.Count && e.RowIndex >= 0)
            {
                int temp = e.RowIndex;


                int i = -1;
                if (int.TryParse(temp.ToString(), out i) && i != -1 && i < stepsOldList.Count)
                {
                    var id = dsSteps[i].ID;
                    dsSteps.RemoveAt(i);
                    bl.RemoveEntitySteps(id, e);
                }
            }
            if (this.view.StepsDataGrid.Columns[e.ColumnIndex].HeaderText == "Edit" && e.RowIndex < dsSteps.Count && e.RowIndex >= 0)
            {
                if(stepsEditor == null)
                {
                   
                }
                int temp = e.RowIndex;

                int i = -1;
                if (int.TryParse(temp.ToString(), out i) && i != -1 && i < stepsOldList.Count)
                {
                    StepDTO modeDto = new StepDTO() { Step = dsSteps[i], Modes = dsModes.Select(x => x.ID).ToList() };
                    ShowEditorStepWindow?.Invoke(modeDto,e);
                }
            }
        }

        private void LoadDataBaseModes(object sender, EventArgs e)
        {
            if (sender is List<Mode>)
            {
                modesOldList = (List<Mode>)sender;
                if (dsModes == null)
                {
                    dsModes = new BindingList<Mode>();
                    this.view.ModesDataGrid.DataSource = dsModes;
                    var deleteButtonColumn = new DataGridViewButtonColumn();
                    deleteButtonColumn.Text = "Delete";
                    deleteButtonColumn.UseColumnTextForButtonValue = true;
                    deleteButtonColumn.HeaderText = "Delete";
                    this.view.ModesDataGrid.Columns.Add(deleteButtonColumn);
                    var editButtonColumn = new DataGridViewButtonColumn();
                    editButtonColumn.Text = "Edit";
                    editButtonColumn.UseColumnTextForButtonValue = true;
                    editButtonColumn.HeaderText = "Edit";
                    this.view.ModesDataGrid.Columns.Add(editButtonColumn);
                }
                else
                    dsModes.Clear();

                foreach (var item in modesOldList)
                {
                    dsModes.Add(item);
                }

            }
        }

        private void LoadDataBaseSteps(object sender, EventArgs e)
        {
            if (sender is List<Step>)
            {
                stepsOldList = (List<Step>)sender;
                if (dsSteps == null)
                {
                    dsSteps = new BindingList<Step>();
                    this.view.StepsDataGrid.DataSource = dsSteps;
                    var deleteButtonColumn = new DataGridViewButtonColumn();
                    deleteButtonColumn.Text = "Delete";
                    deleteButtonColumn.UseColumnTextForButtonValue = true;
                    deleteButtonColumn.HeaderText = "Delete";
                    this.view.StepsDataGrid.Columns.Add(deleteButtonColumn);
                    var editButtonColumn = new DataGridViewButtonColumn();
                    editButtonColumn.Text = "Edit";
                    editButtonColumn.UseColumnTextForButtonValue = true;
                    editButtonColumn.HeaderText = "Edit";
                    this.view.StepsDataGrid.Columns.Add(editButtonColumn);
                }
                else
                    dsSteps.Clear();

                foreach (var item in stepsOldList)
                {
                    dsSteps.Add(item);
                }

            }
        }

        private void ClearAllDataGrid(object sender, EventArgs e)
        {
            dsSteps.Clear();
            dsModes.Clear();

        }

        private void Register(object sender, EventArgs e)
        {
            bl.Authorization.Register(view.Email, view.Password);
        }

        private void Login(object sender, EventArgs e)
        {
            bl.Authorization.Login(view.Email, view.Password);
        }

    }
}
