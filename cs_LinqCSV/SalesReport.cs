﻿using CsvHelper;
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

            table = new List<Table>();
        }
        //***********************************************************************************
        public void Generate() {
            ReadCSVFile();
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

                Console.WriteLine("{0} {1} ", itm.Key1, itm.Key2);
 
                var groupM = itm.Result.GroupBy(x => x.manager).
                                   Select(x => new {
                                       name = x.Key,
                                       amount = x.Sum(z => Convert.ToDouble(z.orderTotal))
                                   }).ToList();

                foreach (var itm2 in groupM) {
                    Console.WriteLine($"{itm2.name} - {itm2.amount}");
                }

                var min = groupM.Select(x => x.amount).Min() ;
                //Console.WriteLine($"min: {min} \n");

                var max = groupM.Select(x => x.amount).Max();
                //Console.WriteLine($"max: {max} \n");

                var total = groupM.Select(x => x.amount).Sum();
                Console.WriteLine($"  total: {total} ");

                var bestManager = groupM.Where(x=>x.amount.Equals(max)).ToList();
                foreach (var item2 in bestManager) {
                    Console.WriteLine($"  best manager: {item2.name} {item2.amount}");
                }


                var loserManager = groupM.Where(x => x.amount.Equals(min)).ToList();
                foreach (var item3 in loserManager) {
                    Console.WriteLine($"  loser manager: {item3.name} {item3.amount}");
                }

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