using BL.Validate;
using DB;
using Models;
using Presenter.MessageBox;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace BL
{
    public class Authorization
    {
        private IMessageService message;
        private readonly IApplicationDB<Account, int> accountsDb;

        public event EventHandler LoadDbHandler;

        public Authorization(IMessageService message, IApplicationDB<Account, int> accountsDb)
        {
            this.message = message;
            this.accountsDb = accountsDb;
        }

        public void Register(string email, string password)
        {
            if (!ValidateAccount.EmailCheck(email, this.message)
                || !ValidateAccount.PasswordCheck(password, this.message)) return;

            var acc = accountsDb.GetAll().FirstOrDefault(i => i.Email == email);


            if (acc == null)
            {
                password = PasswordED.HashPassword(password);
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
            var acc = accountsDb.GetAll().FirstOrDefault(i => i.Email == email);
            if (acc == null) { message.Show("Account not found"); return; }

            PasswordED.VerifyHashedPassword(acc.Password, password);

            if (PasswordED.VerifyHashedPassword(acc.Password, password))
            {
                if (LoadDbHandler != null) LoadDbHandler(this, EventArgs.Empty);
            }
            else message.Show("Incorrect login or password");
        }
    }
}

