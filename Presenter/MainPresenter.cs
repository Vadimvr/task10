using BL;
using Models;
using Presenter.MessageBox;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace Presenter
{
    public class MainPresenter
    {
        IMainWindow view = null;
        IMainBL bl = null;
        IMessageService message = null;
        BindingList<ModeAndSteps> ds;
        List<ModeAndSteps> oldList;
        public MainPresenter(IMainWindow view, IMainBL bl, IMessageService message)
        {
            this.view = view;
            this.message = message;
            this.bl = bl;

            this.view.Login += new EventHandler(Login);
            this.view.Register += new EventHandler(Register);
            this.bl.LoadDbHandler += new EventHandler(LoadDataBase);
            
            this.view.DeleteRow += new EventHandler(RemoveEntity);

            this.view.UpdateDb += bl.UpdateDb;
            this.view.OpenFile += bl.OpenFile;

            this.view.DataGridViewDataErrorHandler += new EventHandler(DataGridViewDataError);
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

        private void RemoveEntity(object sender, EventArgs arg)
        {

            var e = (DataGridViewCellEventArgs)arg;
            if (this.view.DataGridView.Columns[e.ColumnIndex].HeaderText == "Delete" && e.RowIndex >= 0)
            {
                int temp = e.RowIndex;


                int i = -1;
                if (int.TryParse(temp.ToString(), out i) && i != -1 && i < oldList.Count)
                {
                    var id = ds[i].ID;
                    ds.RemoveAt(i);
                    bl.RemoveEntity(id, e);
                }
            }
        }

        private void LoadDataBase(object sender, EventArgs e)
        {
            if (sender is List<ModeAndSteps>)
            {
                oldList = (List<ModeAndSteps>)sender;
                if (ds == null)
                {
                    ds = new BindingList<ModeAndSteps>();
                    this.view.DataGridView.DataSource = ds;
                    var deleteButtonColumn = new DataGridViewButtonColumn();
                    deleteButtonColumn.Text = "Delete";
                    deleteButtonColumn.UseColumnTextForButtonValue = true;
                    deleteButtonColumn.HeaderText = "Delete";
                    this.view.DataGridView.Columns.Add(deleteButtonColumn);
                }
                else
                    ds.Clear();

                foreach (var item in oldList)
                {
                    ds.Add(item);
                }

            }
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
