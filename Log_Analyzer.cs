using System;
using System.IO;
using CsvHelper;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;


namespace testCsharp
{
    public static class Log_Analyzer
    {
        //THINGS TO ANALYZE*************
        /*
        Count message types
        List by message type (emphasis on Wrnings and Errors)
        List by specific timeframe
        List by message source
        List debug messages
        Save subset of messages to csv/json
        Flag Anomalies
        Ignore Routine Messages?
        Message correlation 
        */

        public static List<LogMessage> getListWIthMessageType(List<LogMessage> log_list, MessageType mtype)
        {
            // List<LogMessage> temp = new List<LogMessage>();

            List<LogMessage> query = 
                        (
                            from lm in log_list
                            where lm.messageType == mtype
                            select lm
                        ).ToList();

            // foreach (LogMessage lm in log_list)
            // {
            //     if(lm.messageType == mtype)
            //     {
            //         temp.Add(lm);
            //     }
            // }
            return query;
        }

        public static List<LogMessage> getListWithTimeFrame(List<LogMessage> log_list, DateTime time_in, DateTime time_out)
        {
            // List<LogMessage> temp = new List<LogMessage>();

            List<LogMessage> query = 
                        (
                            from lm in log_list
                            where lm.messageTimestamp >= time_in && lm.messageTimestamp <= time_out
                            select lm
                        ).ToList();


            // foreach (LogMessage lm in log_list)
            // {
            //     if(lm.messageTimestamp >= time_in && lm.messageTimestamp <= time_out)
            //     {
            //         temp.Add(lm);
            //     }
            // }
            return query;
        }

        public static List<LogMessage> getListWIthMessageSource(List<LogMessage> log_list, string msource)
        {
            // List<LogMessage> temp = new List<LogMessage>();

            List<LogMessage> query = 
                        (
                            from lm in log_list
                            where lm.messageSource == msource
                            select lm
                        ).ToList();

            // foreach (LogMessage lm in log_list)
            // {
            //     if(lm.messageSource == msource)
            //     {
            //         temp.Add(lm);
            //     }
            // }
            return query;
        }

        public static void saveLogsAsCSV(List<LogMessage> log_list, string filename)
        {
            using (var writer = new StreamWriter(filename + ".csv"))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(log_list);
            }
        }

    }
}