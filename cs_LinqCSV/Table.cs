using CsvHelper.Configuration.Attributes;

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
}
