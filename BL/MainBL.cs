using DB;
using Models;
using Presenter.MessageBox;
using System;
using System.Collections.Generic;

namespace BL
{
    public interface IMainBL
    {
        Authorization Authorization { get; }

        event EventHandler LoadDbHandler;
        void OpenFile(object sender, EventArgs e);
        void RemoveEntity(object sender, EventArgs e);
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

        public event EventHandler LoadDbHandler;
        public event EventHandler OpenFileHandler;

        public MainBL(IMessageService message)
        {
            this.db = new MemoryDB();

            this.defaultData = new DefaultData(this.db);
            this.defaultData.Create();
            this.ofd = new OpeFileService(message);
            this.messageService = message;
            this.Authorization = new Authorization(message, this.db);
            this.Authorization.LoadDbHandler += new EventHandler(LoadDb); ;

        }

        private void LoadDb(object sender, EventArgs e)
        {
            if (LoadDbHandler != null)
            {
                List<ModeAndSteps> steps = new List<ModeAndSteps>();
                foreach (var item in db.Steps.GetAll())
                {
                    steps.Add(new ModeAndSteps(item.Mode, item));
                }

                LoadDbHandler(steps, EventArgs.Empty);
            }
        }

        public void RemoveEntity(object sender, EventArgs e)
        {
            var x = (int)sender;
            db.Steps.Delete(x);
        }

        public void OpenFile(object sender, EventArgs e)
        {
            ofd.Open();
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
