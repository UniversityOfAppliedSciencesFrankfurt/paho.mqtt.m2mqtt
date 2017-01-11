using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Exceptions;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace MqttClientConsole
{
    public class Program
    {


        static MqttClient mqttClient = new MqttClient("broker.hivemq.com");

        public static void Main(string[] args)

        {
            try
            {
                string clientid = "testclientsubscribe";

                mqttClient.Connect(clientid);
                Console.WriteLine("Connected to MQTT Broker:");
                Console.WriteLine("Enter the topic name to subscribe:");
                string topic = Console.ReadLine();

                string[] topics = new string[] { topic };

                byte[] qoslevels = new byte[] { MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE };

                mqttClient.Subscribe(topics, qoslevels);
                mqttClient.MqttMsgPublishReceived += MqttClient_MqttMsgPublishReceived;

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

            Console.WriteLine(Encoding.ASCII.GetString(response));
        }

    }

}

