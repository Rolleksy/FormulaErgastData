using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace FormulaErgastConsole.Services
{
    public class CSVtoObject
    {

        public CSVtoObject() { }
        

        

        public List<T> GetObjectsFromCSV<T> (string fileName) where T : class
        {
            string pathToFile = $"\\Users\\aleks\\source\\repos\\FormulaErgastData\\FormulaErgastConsole\\ErgastCSV\\";
            pathToFile = pathToFile + fileName + ".csv";
            var records =new List<T>();
            var csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ",",
                HasHeaderRecord = true,
            };
            using (var reader = new StreamReader(pathToFile))
            using (var csv = new CsvReader(reader, csvConfig))
            {
                records = csv.GetRecords<T>().ToList();
            }

            return records;
        }
    }
}
