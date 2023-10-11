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
        event EventHandler DataUpdatedHandler;
        void OpenFile(object sender, EventArgs e);
        void RemoveEntityModes(object sender, EventArgs e);
        void RemoveEntitySteps(object sender, EventArgs e);
        void UpdateDb(object sender, EventArgs e);
        //void Login(string email, string password);
    }

    public class MainBL : IMainBL
    {
        private OpeFileService ofd;
        IMessageService messageService;
        public Authorization Authorization { get; private set; }


        IApplicationDB db;
        private DefaultData defaultData;
        private XLSXConversionToDB xlsxToDb;

        public event EventHandler LoadDbHandlerModes;
        public event EventHandler LoadDbHandlerSteps;
        public event EventHandler OpenFileHandler;
        public event EventHandler DataUpdatedHandler;

        public MainBL(IMessageService message)
        {
            this.db = new MemoryDB();

            this.defaultData = new DefaultData(this.db);
            this.defaultData.Create();
            this.ofd = new OpeFileService(message);
            this.xlsxToDb = new XLSXConversionToDB(this.db);
            this.ofd.LoadExcelFile += this.xlsxToDb.FileISOpen;
            this.messageService = message;
            this.Authorization = new Authorization(message, this.db);
            this.Authorization.LoadDbHandler += new EventHandler(LoadDbSteps);
            this.Authorization.LoadDbHandler += new EventHandler(LoadDbModes);

        }

        private void LoadDbModes(object sender, EventArgs e)
        {

            if (LoadDbHandlerModes != null)
            {
                List<Mode> steps = new List<Mode>();
                foreach (var item in db.Modes.GetAll())
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
                foreach (var item in db.Steps.GetAll())
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
            db.Steps.Delete(id);
        }
        public void RemoveEntityModes(object sender, EventArgs e)
        {
            var id = (int)sender;
            db.Modes.Delete(id);

            var steps = db.Steps.GetAll().Where(s => s.ModeID == id).ToList();
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

    public class DefaultData
    {
        private readonly IApplicationDB db;
        Random random;
        internal DefaultData(IApplicationDB db)
        {
            this.db = db;
            this.random = new Random();
        }

        public void Create()
        {
            for (int i = 0; i < 10; i++)
            {
                db.Accounts.Add(new Account() { Email = $"Email_{i}", Password = "123456" });
            }
            for (int i = 0; i < 10; i++)
            {
                db.Modes.Add(new Mode() { ID = i, MaxBottleNumber = i * 154, MaxUsedTips = i * 45, Name = $"Name_Mode_{i}" });
            }
            for (int i = 0; i < 10; i++)
            {
                var mode = db.Modes.Get(random.Next(0, db.Modes.GetAll().Count));
                db.Steps.Add(new Step()
                {
                    ID = i,
                    ModeID = mode.ID,
                    Mode = mode,
                    Speed = i * 487,
                    Timer = i * 128,
                    Type = $"type_{i}",
                    Volume = i * 1200
                });
            }

            foreach (var item in db.Accounts.GetAll())
            {
                Console.WriteLine($"{item.ID}  {item.Email} {item.Password}");
            }
            foreach (var item in db.Steps.GetAll())
            {
                Console.WriteLine($"{item.ID}, {db.Modes.Get(item.ModeID).Name}  {item.Type}");
            }
        }
    }
}
