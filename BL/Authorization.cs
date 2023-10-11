using DB;
using Models;
using Presenter.MessageBox;
using System;
using System.Linq;

namespace BL
{
    public class Authorization
    {
        private IMessageService message;
        private IApplicationDB db;
        public event EventHandler LoadDbHandler;
        public Authorization(IMessageService message, IApplicationDB db)
        {
            this.message = message;
            this.db = db;
        }

        public void Register(string email, string password)
        {
            var acc = db.Accounts.GetAll().FirstOrDefault(i => i.Email == email);
            if (acc == null)
            {
                db.Accounts.Add(new Account() { Email = email, Password = password });
        //        message.Show($"hello {email}");
                if (LoadDbHandler != null) LoadDbHandler(this, EventArgs.Empty);
            }
            else
            {
                message.Show($"This user is already registered");
            }
        }

        public void Login(string email, string password)
        {
            var acc = db.Accounts.GetAll().FirstOrDefault(i => i.Email == email && i.Password == password);

            if (acc != null)
            {
              //  message.Show($"hello {acc.Email}");
                if (LoadDbHandler != null) LoadDbHandler(this, EventArgs.Empty);
            }
            else message.Show("Account not found");
        }
    }
}

