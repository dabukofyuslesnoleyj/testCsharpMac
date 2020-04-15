using System;
using System.IO;
using System.Globalization;
using CsvHelper;
using Json.Net;
using System.Collections;
using System.Collections.Generic;


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

            //TEXT READER ****************************
            string sample_text = "Hello World \n KMP";
            
            Console.WriteLine(sample_text);

            File.WriteAllText("sample_text.txt", sample_text);

            string read_text = File.ReadAllText("sample_text.txt");

            Console.WriteLine(read_text);

            //CSV READER ****************************
            var reader = new StreamReader("file.csv");
            var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            var records = csv.GetRecords<Person>();
            // Console.WriteLine(records.GetEnumerator());
            ArrayList personList = new ArrayList();
            foreach (Person record in records){
                Console.WriteLine("Hello "+record.Name.ToString());
                personList.Add(record);
            }


            //JSON HANDLER ****************************
            var datalist = JsonNet.Serialize(personList);
            Console.WriteLine(datalist);

            List<Person> jsonlist = JsonNet.Deserialize<List<Person>>(datalist);
            
            foreach (Person data in jsonlist)
                Console.WriteLine(data.Name);
            

            File.WriteAllText("sample_json.json", datalist);



        }
    }
}
