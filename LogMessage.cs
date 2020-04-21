using System;
using Json.Net;
using Newtonsoft.Json;
using System.Data;


namespace testCsharp
{
    public class LogMessage 
    {
        public MessageType messageType {get; set;}
        public string messageSource {get; set;}
        public DateTime messageTimestamp {get; set;}
        
        public string[] messageBody;
        public bool hasJson;
        public DataTable bodyJson;

        private string completeMessage {get; set;}

        public LogMessage(string[] log_params)
        {
            completeMessage = string.Join("", log_params);
            switch(log_params[0])
            {
                case "INFO" : messageType = MessageType.Info; break;
                case "WARNING" : messageType = MessageType.Warning; break;
                case "ERROR" : messageType = MessageType.Error; break;
            }
            messageSource = log_params[1];
            messageTimestamp = DateTime.Parse(log_params[2]);

            int sub_length = (log_params.Length - 3);
            messageBody = Utility_Funcs.SubArray(log_params, 3, sub_length);
            hasJson = false;
            parseBody();
        }

        private void parseBody()
        {
            if(messageBody[0].Contains("#json"))
            {
                hasJson = true;
                string temp = "";
                foreach (string val in messageBody)
                {
                    temp = string.Join("," ,temp , val);
                }
                // temp.Remove(temp.Length-1,1);
                messageBody = temp.Split("#json");
                string data = "["+messageBody[1]+",]";
                bodyJson = JsonConvert.DeserializeObject<DataTable>(data);
            }
        }

        public override string ToString()
        {
            return completeMessage;
        }

    }
}
