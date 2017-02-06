
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mqtt_Core;
using Mqtt_Core.Messages;


namespace ConsoleClient
{
    public class Program
        {   
        public static void Main(string[] args)
        {
            // already existing mqtt broker "broker.hivemq.com" is used for testing
            MqttClient client = new MqttClient("broker.hivemq.com");
            // creating universial uniqe code for client identity
            string uniqueclientid = Guid.NewGuid().ToString();

            // method to establish a connection- connection reqest is send from client to broker
            client.Connect(uniqueclientid);

            Console.WriteLine("Enter  topic name to subscribe");
            string[] topic = { Console.ReadLine() }; 
                      
            byte[] qoslevel =  new byte[] { MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE };

            // message is requested with a broker specifying a topic name and QoS  
            client.Subscribe(topic, qoslevel);
            
            //even is listened for every published event for that topic
            client.MqttMsgPublishReceived += Client_MqttMsgPublishReceived;

            Console.ReadKey();

        }

        private static void Client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
        {
            byte[] respose = e.Message;
            string topicname = e.Topic;
            string byteToString = Encoding.ASCII.GetString(respose);
            Console.WriteLine("Topic name : " + topicname + "  Data :" + byteToString);
        }


    }
}
