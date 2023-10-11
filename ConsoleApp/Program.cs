
using DB;
using Models;
using System;

namespace ConsoleApp
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Random random = new Random();
            MemoryDB db = new MemoryDB();
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

            Console.ReadKey();
        }
    }
}
