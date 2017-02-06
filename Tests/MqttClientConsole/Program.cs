
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

            MqttClient client = new MqttClient("broker.hivemq.com");
            string uniqueclientid = Guid.NewGuid().ToString();
            client.Connect(uniqueclientid);

            Console.WriteLine("Enter  topic name to subscribe");
            string[] topic = { Console.ReadLine() };           
            byte[] qoslevel =  new byte[] { MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE };
            client.Subscribe(topic, qoslevel);

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
