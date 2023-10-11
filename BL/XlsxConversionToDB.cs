using ClosedXML.Excel;
using DB;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    internal class XLSXConversionToDB
    {
        private IApplicationDBOld db;

        public XLSXConversionToDB(IApplicationDBOld db)
        {
            this.db = db;
        }

        internal void FileISOpen(object sender, EventArgs e)
        {
            string fileName = sender.ToString();
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
            foreach (var mode in modeList)
            {
                if (db.Modes.GetAll().FirstOrDefault(m => m.Name.Equals(mode.Name, StringComparison.CurrentCultureIgnoreCase)) == null)
                    db.Modes.Add(mode);
                int id = db.Modes.GetAll().FirstOrDefault(m => m.Name.Equals(mode.Name, StringComparison.CurrentCultureIgnoreCase)).ID;
                mode.ID = id;
            }

            foreach (var item in stepsList)
            {
                item.ModeID = item.Mode.ID;
                db.Steps.Add(item);
            }
        }
    }
}
