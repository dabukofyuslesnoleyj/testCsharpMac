using System;
using System.IO;
using System.Globalization;
using CsvHelper;


namespace testCsharp
{

    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string sample_text = "Hello World \n KMP";
            
            Console.WriteLine(sample_text);

            File.WriteAllText("sample_text.txt", sample_text);

            string read_text = File.ReadAllText("sample_text.txt");

            Console.WriteLine(read_text);
            var reader = new StreamReader("file.csv");
            var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            var records = csv.GetRecords<Person>();
            // Console.WriteLine(records.GetEnumerator());
            foreach (Person record in records){
                if(record.Name == "one")
                    Console.WriteLine(record.Id.ToString());
            }
        }
    }
}
