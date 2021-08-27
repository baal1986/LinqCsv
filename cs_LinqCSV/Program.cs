using System;

namespace cs_LinqCSV {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("[?] Ex.: prog.exe input.csv output.csv \n");
            SalesReport SR = new SalesReport(args[0], args[1]);
            SR.Generate();
            SR.Parse();
        }
    }
}
