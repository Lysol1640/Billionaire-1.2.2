using System;
using System.Linq;
using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using System.IO;


namespace Billionaire_1._2._1
{
    class DataBase
    {
        public static void ReadData()
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = false
              
            };
            var csvPath = Path.Combine(Environment.CurrentDirectory, "questions.csv");
            using (var reader = new StreamReader(csvPath))
            {
                using (var csvReader = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                   
                    var records = csvReader.GetRecords<Question>().ToList();
                    Program.questions = records;
                }
            }
        }
        
        public static void WriteData()                                                         //writer inicjowany jest przy wyjsciu z trybu developera(save&exit)
        {
            var csvPath = Path.Combine(Environment.CurrentDirectory, "questions.csv");
            using (var writer = new StreamWriter(csvPath))
            {
                using (var csvWriter = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csvWriter.WriteHeader<Question>();
                    csvWriter.NextRecord();
                    foreach (var record in Program.questions)
                    {
                        csvWriter.WriteRecord(record);
                        csvWriter.NextRecord();
                    }
                }
            }
        }
    } 
}



            
           
           
        
        

        
        


           
