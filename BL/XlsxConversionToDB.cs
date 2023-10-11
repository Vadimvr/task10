using ClosedXML.Excel;
using DB;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BL
{
    internal class XLSXConversionToDB
    {
        private IApplicationDB<Mode, int> modesDb;
        private IApplicationDB<Step, int> stepsDb;

        public XLSXConversionToDB(IApplicationDB<Mode, int> modesDb, IApplicationDB<Step, int> stepsDb)
        {
            this.modesDb = modesDb;
            this.stepsDb = stepsDb;
        }

        internal void FileISOpen(object sender, EventArgs e)
        {
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
                if (modesDb.GetAll().FirstOrDefault(m => m.Name.Equals(mode.Name, StringComparison.CurrentCultureIgnoreCase)) == null)
                {
                    modesDb.Add(mode);
                }
            }

            foreach (var item in stepsList)
            {
                item.ModeID = modesDb.GetAll().FirstOrDefault(m => m.Name.Equals(item.Mode.Name, StringComparison.CurrentCultureIgnoreCase)).ID;
                item.Mode = null;
                stepsDb.Add(item);
            }
        }
    }
}
