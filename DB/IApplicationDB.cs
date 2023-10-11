using Models;
using System.Collections.Generic;

namespace DB
{
    public interface IApplicationDB
    {
        IEntitiesDB<Account, int> Accounts { get; }
        IEntitiesDB<Mode, int> Modes { get; }
        IEntitiesDB<Step, int> Steps { get; }
    }

    public class MemoryDB : IApplicationDB
    {

        EntitiesDB<Account, int> accounts = null;
        EntitiesDB<Mode, int> modes = null;
        EntitiesDB<Step, int> steps = null;

        public MemoryDB()
        {
            accounts = new EntitiesDB<Account, int>(new List<Account>());
            modes = new EntitiesDB<Mode, int>(new List<Mode>());
            steps = new EntitiesDB<Step, int>(new List<Step>());
        }

        public IEntitiesDB<Account, int> Accounts { get => accounts; }
        public IEntitiesDB<Mode, int> Modes { get => modes; }
        public IEntitiesDB<Step, int> Steps { get => steps; }
    }

   

}
