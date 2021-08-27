using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace cs_LinqCSV {
    class ResultTable {

        [Name("Год")]
        public string Year { get => year; }
        private string year { get; set; }

        [Name("Месяц")]
        public string Month { get => month; }
        private string month { get; set; }

        [Name("Выручка")]
        public string Earnings { get => earnings; }
        private string earnings { get; set; }

        [Name("Лучший продавец")]
        public string BestManager { get => bestManager; }
        private string bestManager { get; set; }

        [Name("Выручка лучшего продавца")]
        public string EarningsBestManager { get => earningsBestManager; }
        private string earningsBestManager { get; set; }

        [Name("Худший продавец")]
        public string LoserManager { get => loserManager; }
        private string loserManager { get; set; }

        [Name("Выручка худшего продавца")]
        public string EarningsLoserManager { get => earningsLoserManager; }
        private string earningsLoserManager { get; set; }

    }
}
