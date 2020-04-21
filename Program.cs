using System.IO;
using System.Globalization;
using CsvHelper;
using Json.Net;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Text.RegularExpressions;

namespace testCsharp
{
    //LOG PARSING
    /*
    Message Type
    Datatype
    Date Time
    Action


    */
    
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
            // string sample_text = "Hello World \n KMP";
            
            // Console.WriteLine(sample_text);

            // File.WriteAllText("sample_text.txt", sample_text);

            // string read_text = File.ReadAllText("sample_text.txt");

            // Console.WriteLine(read_text);

            //CSV READER ****************************
            // var reader = new StreamReader("file.csv");
            // var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            // var records = csv.GetRecords<Person>();
            // ArrayList personList = new ArrayList();
            // foreach (Person record in records){
            //     Console.WriteLine("Hello "+record.Name.ToString());
            //     personList.Add(record);
            // }


            //JSON HANDLER ****************************
            // var datalist = JsonNet.Serialize(personList);
            // Console.WriteLine(datalist);

            // List<Person> jsonlist = JsonNet.Deserialize<List<Person>>(datalist);
            
            // foreach (Person data in jsonlist)
            //     Console.WriteLine(data.Name);
            

            // File.WriteAllText("sample_json.json", datalist);

            string input_log =  File.ReadAllText("sub_log.log");
            string[] log_messages = input_log.Split("\n");

            foreach (string log_message in log_messages)
            {

                Regex regex = new Regex("(INFO|WARNING|ERROR),(.*?),(.*?),");
                Match match = regex.Match(log_message);
                string log_header = match.Groups[0].Value;
                string[] log_header_split = log_header.Split(",");

                regex = new Regex("!((INFO|WARNING|ERROR),(.*?),(.*?),)");
                match = regex.Match(log_message);
                string log_body = match.Groups[0].Value;
                
                // LogMessage lm = new LogMessage(log_params);
                // lm.ToString();
                
            }

        }
    }
}
