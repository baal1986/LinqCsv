using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;


namespace cs_LinqCSV {
    public class SalesReport {
        //***********************************************************************************
        public SalesReport(string fileNameInput, string fileNameOutput) {
            this.fileNameInput = fileNameInput;
            this.fileNameOutput = fileNameOutput;

            this.table = new List<Table>();
            this.resultTable = new List<ResultTable>();
        }
        //***********************************************************************************
        public void Generate() {
            ReadCSVFile();
            Parse();
            WriteCSVFile();
        }
        //***********************************************************************************
        public List<Table> ReadCSVFile() {

            var config = new CsvConfiguration(CultureInfo.InvariantCulture) {
                Delimiter = ";",
                BadDataFound = null
            };

            using (var reader = new StreamReader(fileNameInput))
            using (var csv = new CsvReader(reader, config)) {
                table = csv.GetRecords<Table>().ToList();
            }
            return table;

        }
        //***********************************************************************************
        public void Parse() {
            var res = from t in table
                      where t.isDelivered.Equals("Да")
                      select t;
            tableParse = new List<TablePase>();

            foreach (var itm in res) {
                var data = itm.date.Split(".");
                tableParse.Add(new TablePase(data[2], data[1], itm.manager, itm.orderTotal));
            }

            var gropYM = tableParse.GroupBy(x => new { x.year, x.month }, (key, group) => new {
                Key1 = key.year,
                Key2 = key.month,
                Result = group.ToList()
            });

            foreach (var itm in gropYM) {

                string year = itm.Key1;
                string month = itm.Key2;


                var groupM = itm.Result.GroupBy(x => x.manager).
                                   Select(x => new {
                                       name = x.Key,
                                       amount = x.Sum(z => Convert.ToDouble(z.orderTotal))
                                   }).ToList();

                var min = groupM.Select(x => x.amount).Min();
                var max = groupM.Select(x => x.amount).Max();
                var total = groupM.Select(x => x.amount).Sum();


                var bestManager = groupM.Where(x => x.amount.Equals(max)).ToList();
                var loserManager = groupM.Where(x => x.amount.Equals(min)).ToList();

                List<string> bestManagerNames = new List<string>();
                List<double> bestManagerAmount = new List<double>();
                foreach (var item2 in bestManager) {
                    bestManagerNames.Add(item2.name);
                    bestManagerAmount.Add(item2.amount);
                    //Console.WriteLine($"  best manager: {item2.name} {item2.amount}");
                }

                List<string> loserManagerNames = new List<string>();
                List<double> loserManagerAmount = new List<double>();
                foreach (var item3 in loserManager) {
                    loserManagerNames.Add(item3.name);
                    loserManagerAmount.Add(item3.amount);
                    //Console.WriteLine($"  loser manager: {item3.name} {item3.amount}");
                }


                resultTable.Add(new ResultTable(year, month, total,
                                                bestManagerNames[0], bestManagerAmount[0],
                                                loserManagerNames[0], loserManagerAmount[0])
                );
            }


        }
        //***********************************************************************************
        void PrintResult() {
            var resultTableSort = resultTable.OrderBy(x => x.year).ThenBy(x => x.month);
            foreach (var item in resultTableSort) {
                Console.WriteLine($"{item.year}\t{item.month}\t{item.earnings}\t" +
                    $"{item.bestManager[0]}\t\t {item.earningsBestManager}\t\t" +
                    $"{item.loserManager[0]}\t\t{item.earningsLoserManager}");
            }
        }
        //***********************************************************************************
        public void WriteCSVFile() {
        
            using (var writer = new StreamWriter(fileNameOutput))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture)) {
                 csv.WriteRecords(resultTable);
            }
        }
        //***********************************************************************************
        private string fileNameInput { set; get; }
        private string fileNameOutput { set; get; }
        private List<Table> table { set; get; }
        private List<TablePase> tableParse { set; get; }
        private List<ResultTable> resultTable { set; get; }
        //***********************************************************************************
    }
}
