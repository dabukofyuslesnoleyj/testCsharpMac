using System;
using Json.Net;


namespace testCsharp
{
    public class LogMessage 
    {
        public MessageType messageType {get; set;}
        public string messageSource {get; set;}
        public DateTime messageTimestamp {get; set;}
        
        public string[] messageBody;

        public LogMessage(string[] log_params)
        {
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
        }

        private void parseBody()
        {
            
        }

        public override string ToString(){
            string data = JsonNet.Serialize(this);
            Console.WriteLine(data);
            return data;
        }


    }
}
