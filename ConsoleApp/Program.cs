using ClosedXML.Excel;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using testDataBase;
using DB;
using System.Data.Entity.Core.Metadata.Edm;

namespace ConsoleApp
{
    internal class Program
    {

        static void Main(string[] args)
        {
            DB.AppDbContext context = new DB.AppDbContext(@"data source=E:\test.db;");

            IApplicationDB<Step,int> stepsDb = new SQLiteDb<Step, int>(context);
            IApplicationDB<Mode,int> modesDb = new SQLiteDb<Mode, int>(context);
            IApplicationDB<Account,int> accountsDb = new SQLiteDb<Account, int>(context);

            foreach (var item in stepsDb.GetAll())
            {
                Console.WriteLine( item);
            }

            accountsDb.Delete(1);
            Console.ReadKey();
        }

        private static void testAddDataFromFile()
        {
            testDataBase.AppDbContext context = new testDataBase.AppDbContext(@"data source=E:\test.db;");
            string fileName = "E:\\DataExample.xlsx";
            var workbook = new XLWorkbook(fileName);
            var ws1 = workbook.Worksheet(1);
            var ws2 = workbook.Worksheet(2);


            List<Mode> modeList = new List<Mode>();
            List<Step> stepsList = new List<Step>();

            for (int j = 2; j < ws1.Rows().Count(); j++)
            {
                Mode mode = Mode.ConvertToMode(ws1.Row(j));

                modeList.Add(mode);
            }



            for (int j = 2; j < ws2.Rows().Count(); j++)
            {
                var step = Step.ConvertToMode(ws2.Row(j));
                stepsList.Add(step);
                var mode = modeList.FirstOrDefault(m => m.ID == step.ModeID);
                if (mode == null) throw new ArgumentNullException("mode is null");
                step.Mode = mode;
                Console.WriteLine(step);
            }

            for (int i = 0; i < modeList.Count; i++)
            {
                Mode mode = modeList[i];
                if (context.Modes.FirstOrDefault(m => m.Name.Equals(mode.Name, StringComparison.CurrentCultureIgnoreCase)) == null)
                {
                    context.Modes.Add(mode);
                    context.SaveChanges();
                }

                modeList[i] = context.Modes.FirstOrDefault(m => m.Name.Equals(mode.Name, StringComparison.CurrentCultureIgnoreCase));

            }

            foreach (var item in stepsList)
            {
                item.ModeID = context.Modes.FirstOrDefault(m => m.Name.Equals(item.Mode.Name, StringComparison.CurrentCultureIgnoreCase)).ID;
                item.Mode = null;
                context.Steps.Add(item);
                context.SaveChanges();
            }
        }
    }
}



//string fileName = "E:\\DataExample.xlsx";
//var workbook = new XLWorkbook(fileName);
//var ws1 = workbook.Worksheet(1);
//var ws2 = workbook.Worksheet(2);


//List<Mode> modeList = new List<Mode>();
//List<Step> stepsList = new List<Step>();
//for (int j = 2; j < ws1.Rows().Count(); j++)
//{
//    modeList.Add(Mode.ConvertToMode(ws1.Row(j)));
//    Console.WriteLine(modeList[modeList.Count - 1]);
//}
//for (int j = 2; j < ws2.Rows().Count(); j++)
//{
//    var step = Step.ConvertToMode(ws2.Row(j));
//    stepsList.Add(step);
//    var mode = modeList.FirstOrDefault(m => m.ID == step.ModeID);
//    if (mode == null) throw new ArgumentNullException("mode is null");
//    step.Mode = mode;
//    Console.WriteLine(step);
//}


//Console.ReadKey();