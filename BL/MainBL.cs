using DB;
using Models;
using Presenter.MessageBox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace BL
{
    public interface IMainBL
    {
        Authorization Authorization { get; }

        event EventHandler LoadDbHandlerModes;
        event EventHandler LoadDbHandlerSteps;
     //   event EventHandler DataUpdatedHandler;
        void OpenFile(object sender, EventArgs e);
        void RemoveEntityModes(object sender, EventArgs e);
        void RemoveEntitySteps(object sender, EventArgs e);
        void UpdateDb(object sender, EventArgs e);
    }

    public class MainBL : IMainBL
    {
        private OpeFileService ofd;
        IMessageService messageService;
        public Authorization Authorization { get; private set; }


       
        private XLSXConversionToDB xlsxToDb;
        
        private IApplicationDB<Step, int> stepsDb;
        private IApplicationDB<Mode, int> modesDb;
        private IApplicationDB<Account, int> accountsDb;

        public event EventHandler LoadDbHandlerModes;
        public event EventHandler LoadDbHandlerSteps;

        public MainBL(IMessageService message, string connectingString = "")
        {
            DB.AppDbContext context = new DB.AppDbContext(@"data source="+connectingString);

            stepsDb = new DbSQLite<Step, int>(context);
            modesDb = new DbSQLite<Mode, int>(context);
            accountsDb = new DbSQLite<Account, int>(context);

            this.ofd = new OpeFileService(message);
            this.xlsxToDb = new XLSXConversionToDB(modesDb, stepsDb);
            this.ofd.LoadExcelFile += this.xlsxToDb.FileISOpen;
            this.messageService = message;
            this.Authorization = new Authorization(message, accountsDb);
            this.Authorization.LoadDbHandler += new EventHandler(LoadDbSteps);
            this.Authorization.LoadDbHandler += new EventHandler(LoadDbModes);
        }

        private void LoadDbModes(object sender, EventArgs e)
        {
            if (LoadDbHandlerModes != null)
            {
                List<Mode> steps = new List<Mode>();
                foreach (var item in modesDb.GetAll())
                {
                    steps.Add(item);
                }

                LoadDbHandlerModes(steps, EventArgs.Empty);
            }
        }

        private void LoadDbSteps(object sender, EventArgs e)
        {
            if (LoadDbHandlerSteps != null)
            {
                List<Step> steps = new List<Step>();
                foreach (var item in stepsDb.GetAll())
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
            stepsDb.Delete(id);
        }
        public void RemoveEntityModes(object sender, EventArgs e)
        {
            var id = (int)sender;
            modesDb.Delete(id);

            var steps = stepsDb.GetAll().Where(s => s.ModeID == id).ToList();
            foreach (var step in steps)
            {
                RemoveEntitySteps(step.ID, e);
            }
            LoadDbSteps(sender, EventArgs.Empty);
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
