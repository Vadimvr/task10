using DB;
using Models;
using Presenter.MessageBox;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace BL
{
    public interface IMainBL
    {
        Authorization Authorization { get; }

        event EventHandler LoadDbHandlerModes;
        event EventHandler LoadDbHandlerSteps;

        event EventHandler SingInHandler;
        event EventHandler StepSaveHandler;
        //   event EventHandler DataUpdatedHandler;
        void OpenFile(object sender, EventArgs e);
        void RemoveEntityModes(object sender, EventArgs e);
        void RemoveEntitySteps(object sender, EventArgs e);
        void StepSave(object sender, EventArgs e);
        void UpdateDb(object sender, EventArgs e);
    }

    public class MainBL : IMainBL
    {
        private OpeFileService ofd;
        IMessageService messageService;
        public Authorization Authorization { get; private set; }

        internal readonly UpdateEntity updateEntity;
        internal IAppDbContext context;

        private XLSXConversionToDB xlsxToDb;


        public event EventHandler LoadDbHandlerModes;
        public event EventHandler LoadDbHandlerSteps;
        public event EventHandler SingInHandler;
        public event EventHandler StepSaveHandler;

        public MainBL(IMessageService message, string connectingString = "")
        {
            context = CreateDB.Create(connectingString);

            this.updateEntity = new UpdateEntity(context);

            this.StepSaveHandler += updateEntity.EntitySave;

            this.ofd = new OpeFileService(message);
            this.xlsxToDb = new XLSXConversionToDB(context);
            this.ofd.LoadExcelFile += this.xlsxToDb.FileISOpen;
            this.messageService = message;
            this.Authorization = new Authorization(message, context);
            this.Authorization.LoadDbHandler += new EventHandler(SingIn);
            SingInHandler += LoadDbModes;
            SingInHandler += LoadDbSteps;
        }


        public void StepSave(object sender, EventArgs e)
        {
            if (sender is Step)
            {
                StepSaveHandler?.Invoke(sender, e);
                LoadDbSteps(sender, e);
            }
            if (sender is Mode)
            {
                StepSaveHandler?.Invoke(sender, e);
                LoadDbModes(sender, e);
            }
        }
        private void SingIn(object sender, EventArgs e) => SingInHandler?.Invoke(sender, e);


        private void LoadDbModes(object sender, EventArgs e)
        {
            if (LoadDbHandlerModes != null)
            {
                List<Mode> modes = new List<Mode>();
                foreach (var item in context.Modes)
                {
                    modes.Add(item);
                }

                LoadDbHandlerModes(modes, EventArgs.Empty);
            }
        }

        private void LoadDbSteps(object sender, EventArgs e)
        {
            if (LoadDbHandlerSteps != null)
            {
                List<Step> steps = new List<Step>();
                foreach (var item in context.Steps)
                {
                    steps.Add(item);
                }

                LoadDbHandlerSteps(steps, EventArgs.Empty);
            }
        }

        public void RemoveEntitySteps(object sender, EventArgs e)
        {
            var id = (int)sender;
            RemoveEntitySteps(id, e);
        }

        public void RemoveEntitySteps(int sender, EventArgs e)
        {
            var id = (int)sender;
            var step = context.Steps.FirstOrDefault(s => s.ID == id);
            if (step != null)
            {
                context.Steps.Remove(step);
                context.SaveChanges();
            }

        }

        public void RemoveEntityModes(object sender, EventArgs e)
        {
            var id = (int)sender;
            var mode = context.Modes.FirstOrDefault(s => s.ID == id);
            if (mode != null)
            {
                context.Modes.Remove(mode);
                var steps = context.Steps.Where(s => s.ModeID == id);
                foreach (var step in steps)
                {
                    RemoveEntitySteps(step.ID, e);
                }
                LoadDbSteps(sender, EventArgs.Empty);
            }
        }

        public void OpenFile(object sender, EventArgs e)
        {
            ofd.Open();
            LoadDbSteps(sender, EventArgs.Empty);
            LoadDbModes(sender, EventArgs.Empty);
        }

        public void UpdateDb(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
