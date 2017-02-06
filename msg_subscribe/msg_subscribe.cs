using System;
using System.Collections.Generic;

namespace Daenet.Iot    
{

    public class msg_subscribe
    {
        static string conString = "broker.hivemq.com";        
        string clientId = new Guid().ToString(); 
        
               
        public static void Main(string[] args)
        {            
            Iot_Mqtt obj = new Iot_Mqtt();
            Dictionary<string, object> dict = new Dictionary<string, object>();
            dict.Add("mqttConnectionString", conString);
            obj.Open(dict);                    
               
            Console.WriteLine("Enter topic to subscribe");
            string subsTopic = Console.ReadLine();

            Dictionary<string, object> dict_topic = new Dictionary<string, object>();

            dict_topic.Add("subscribeTopic", subsTopic);            
            obj.ReceiveAsync(null, null, 60000,dict_topic);
            
                       
            Console.ReadKey();
        }              
    }
}
