
using ClosedXML.Excel;
using DB;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp
{
    internal class Program
    {

        static void Main(string[] args)
        {
            string fileName = "E:\\DataExample.xlsx";
            var workbook = new XLWorkbook(fileName);
            var ws1 = workbook.Worksheet(1);
            var ws2 = workbook.Worksheet(2);


            List<Mode> modeList = new List<Mode>();
            List<Step> stepsList = new List<Step>();
            for (int j = 2; j < ws1.Rows().Count(); j++)
            {
                modeList.Add(Mode.ConvertToMode(ws1.Row(j)));
                Console.WriteLine(modeList[modeList.Count - 1]);
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


            Console.ReadKey();
        }
    }
}
