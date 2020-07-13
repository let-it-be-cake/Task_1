using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace Task_2
{
    internal class FileReader
    {
        
        //Additional class for markup data
        class CustormContainer : ClassMap<TranslateContainer>
        {
            public CustormContainer()
            {
                Map(m => m.Type).Index(0);
                Map(m => m.Arguments).Index(1);
            }
        }

        //Standart CSVHelper settings
        static public IEnumerable<TranslateContainer> ReadFigures(string fileName)
        {
            using (var reader = new StreamReader(fileName))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Configuration.HasHeaderRecord = false;
                csv.Configuration.Delimiter = ",";
                csv.Configuration.RegisterClassMap<CustormContainer>();
                return csv.GetRecords<TranslateContainer>().ToArray();
            }
        }
    }
}