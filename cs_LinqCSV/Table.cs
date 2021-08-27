using CsvHelper.Configuration.Attributes;
using System.Collections.Generic;

namespace cs_LinqCSV {
    public class Table {

        [Name("Дата Размещения")]
        public  string date { get; set; }

        [Name("Менеджер")]
        public string manager { get; set; }


        [Name("Сумма")]
        public string orderTotal { get; set; }


        [Name("Доставлен")]
        public string isDelivered { get; set; }

    }

    public class TablePase {

        public TablePase(string year, string month, string manager, string orderTotal) {
            this.year = year;
            this.month = month;
            this.manager = manager;
            this.orderTotal = orderTotal;
        }
        
        public string year { get; set; }
        public string month { get; set; }
        public string manager { get; set; }
        public string orderTotal { get; set; }

    }

    public class ResultTable {


        public ResultTable(string year, string month, double earnings, 
            List<string> bestManager, List<double> earningsBestManager,
            List<string> loserManager, List<double> earningsLoserManager) {

            this.year = year;
            this.month = month;
            this.earnings = earnings;

            this.bestManager = new List<string>();
            this.bestManager = bestManager;

            this.earningsBestManager = new List<double>();
            this.earningsBestManager = earningsBestManager;

            this.loserManager = new List<string>();
            this.loserManager = loserManager;

            this.earningsLoserManager = new List<double>();
            this.earningsLoserManager = earningsLoserManager;


        }

        [Name("Год")]
        public string year { get; set; }

        [Name("Месяц")]
        public string month { get; set; }

        [Name("Выручка")]
        public double earnings { get; set; }

        [Name("Лучший продавец")]
        public List<string> bestManager { get; set; }

        [Name("Выручка лучшего продавца")]
        public List<double> earningsBestManager { get; set; }

        [Name("Худший продавец")]
        public List<string> loserManager { get; set; }

        [Name("Выручка худшего продавца")]
        public List<double> earningsLoserManager { get; set; }

    }
}
