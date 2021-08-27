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
            string bestManager, double earningsBestManager,
            string loserManager, double earningsLoserManager) {

            this.year = year;
            this.month = month;
            this.earnings = earnings;

           
            this.bestManager = bestManager;

          
            this.earningsBestManager = earningsBestManager;

           
            this.loserManager = loserManager;

            
            this.earningsLoserManager = earningsLoserManager;


        }

        [Name("Год")]

        public string year { get; set; }

        [Name("Месяц")]
        public string month { get; set; }

        [Name("Выручка")]
        public double earnings { get; set; }

        [Name("Лучший продавец")]
        public string bestManager { get; set; }

        [Name("Выручка лучшего продавца")]
        public double earningsBestManager { get; set; }

        [Name("Худший продавец")]
        public string loserManager { get; set; }

        [Name("Выручка худшего продавца")]
        public double earningsLoserManager { get; set; }

    }
}
