using System;
using Json.Net;
using System.Collections;
using System.Collections.Generic;


namespace testCsharp
{
    public class Log_Collection
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
        private List<LogMessage> log_list {get; set;}
        private int warningCount;
        private int errorCount;

        public Log_Collection (List<LogMessage> logMessages)
        {
            log_list = logMessages;
            foreach (LogMessage lm in log_list)
            {
                if(lm.messageType == MessageType.Warning)
                {
                    warningCount++;
                }
                else if(lm.messageType == MessageType.Error)
                {
                    errorCount++;
                }
            }
        }

        public List<LogMessage> getListWIthMessageType(MessageType mtype)
        {
            List<LogMessage> temp = new List<LogMessage>();
            foreach (LogMessage lm in log_list)
            {
                if(lm.messageType == mtype)
                {
                    temp.Add(lm);
                }
            }
            return temp;
        }

        public List<LogMessage> getLogs()
        {
            return log_list;
        }

    }
}