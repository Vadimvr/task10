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
        private IAppDbContext context;

        public event EventHandler LoadDbHandler;

      

        public Authorization(IMessageService message, IAppDbContext context)
        {
            this.message = message;
            this.context = context;
        }

        public void Register(string email, string password)
        {
            if (!ValidateAccount.EmailCheck(email, this.message)
                || !ValidateAccount.PasswordCheck(password, this.message)) return;

            var acc = context.Accounts.FirstOrDefault(i => i.Email == email);


            if (acc == null)
            {
                password = PasswordED.HashPassword(password);
                context.Accounts.Add(new Account() { Email = email, Password = password });
                if (LoadDbHandler != null) LoadDbHandler(this, EventArgs.Empty);
            }
            else
            {
                message.Show($"This user is already registered");
            }
        }

        public void Login(string email, string password)
        {
            var acc = context.Accounts.FirstOrDefault(i => i.Email == email);
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

