using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit.Sdk;
using cs_LinqCSV;

namespace Tests {
    [TestClass]
    public class UnitTest1 {
        [TestMethod]
        public void UploadFiles() {
            string inputFile = @"D:\PROJECTS\cs_LinqCSV\cs_LinqCSV\bin\Debug\netcoreapp3.1\sample_utf8.csv";
            string outputFile = @"D:\PROJECTS\cs_LinqCSV\cs_LinqCSV\bin\Debug\netcoreapp3.1\sample_.csv";
            SalesReport SR = new SalesReport(inputFile, outputFile);
            var read = SR.ReadCSVFile();
            Assert.AreEqual(45,read.Count );

        }

        [TestMethod]
        public void Test2() {
            string inputFile = @"D:\PROJECTS\cs_LinqCSV\cs_LinqCSV\bin\Debug\netcoreapp3.1\sample_utf8.csv";
            string outputFile = @"D:\PROJECTS\cs_LinqCSV\cs_LinqCSV\bin\Debug\netcoreapp3.1\sample_.csv";
            SalesReport SR = new SalesReport(inputFile, outputFile);
            var read = SR.ReadCSVFile();
            Assert.AreEqual(45, read.Count);

        }
    }
}
