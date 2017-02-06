using System;
using System.Collections.Generic;


namespace Daenet.Iot
{

    public class msg_publish
    {
        // already existing mqtt broker "broker.hivemq.com" is used for testing    
        static string conString = "broker.hivemq.com";
        // creating universial uniqe code for client identity
        string clientid = new Guid().ToString();

            public static void Main(string[] args)
            {

               
                Iot_Mqtt obj = new Iot_Mqtt();
                Dictionary<string, object> dict = new Dictionary<string, object>();
                dict.Add("mqttConnectionString", conString);
                obj.Open(dict);
                try
                {
                    Console.WriteLine("Enter the Topic name to publish");
                    string topic = Console.ReadLine();
                    Dictionary<string, object> dtopic = new Dictionary<string, object>();
                    dtopic.Add("topicName", topic);              

                    while (true)
                    {
                        Console.WriteLine("Write the msg ! :");
                        string msg = Console.ReadLine();
                        List<object> mlist = new List<object>();
                        mlist.Add(msg);
                        IList<object> lst = mlist;
                        obj.SendAsync(lst, null, null, dtopic);

                    Console.ReadKey();

                    }
                
                
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }



            }
        }
    
}

