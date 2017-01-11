using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace MqttServerConsole
{
    public class Program

    {

        static MqttClient mqttClient = new MqttClient("broker.hivemq.com");
        public static void Main(string[] args)
        {

            string clientid = "testclientpublish";

            mqttClient.Connect(clientid);
            Console.WriteLine("Connected to MQTT Broker:");


            Console.WriteLine("Enter the topics name to publish message:");
            string topics = Console.ReadLine();

            while (true)

                try
                {

                    Console.WriteLine("Enter the message to publish:");
                    string mesage = Console.ReadLine();

                    mqttClient.Publish(topics, Encoding.ASCII.GetBytes(mesage));
                    Console.WriteLine("publish successful");
                    // mqttClient.MqttMsgPublishReceived += MqttClient_MqttMsgPublishReceived;
                    Console.ReadKey();

                }

                catch (Exception ex)
                {
                    Console.WriteLine("Error :     " + ex.ToString());
                }
        }

        private static void MqttClient_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
        {
            byte[] response = e.Message;

            //Console.WriteLine(Encoding.ASCII.GetBytes(response));
        }


    }
}
