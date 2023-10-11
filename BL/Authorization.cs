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
        private readonly IApplicationDB<Account, int> accountsDb;
      
        public event EventHandler LoadDbHandler;

        public Authorization(IMessageService message,IApplicationDB<Account, int> accountsDb)
        {
            this.message = message;
            this.accountsDb = accountsDb;
        }

        public void Register(string email, string password)
        {
            var acc = accountsDb.GetAll().FirstOrDefault(i => i.Email == email);
            if (acc == null)
            {
                accountsDb.Add(new Account() { Email = email, Password = password });
                if (LoadDbHandler != null) LoadDbHandler(this, EventArgs.Empty);
            }
            else
            {
                message.Show($"This user is already registered");
            }
        }

        public void Login(string email, string password)
        {
            var acc = accountsDb.GetAll().FirstOrDefault(i => i.Email == email && i.Password == password);

            if (acc != null)
            {
                if (LoadDbHandler != null) LoadDbHandler(this, EventArgs.Empty);
            }
            else message.Show("Account not found");
        }
    }
}

