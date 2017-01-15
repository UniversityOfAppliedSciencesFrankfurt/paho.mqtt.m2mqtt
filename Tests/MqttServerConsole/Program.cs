using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;


namespace MqttServerConsole
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Client that Publishes:");
            MqttClient client = new MqttClient("broker.hivemq.com");
            string uniqueserverid = Guid.NewGuid().ToString();
            client.Connect(uniqueserverid);
            try
            {
                Console.WriteLine("Enter the Topic name to publish");
                string topic = Console.ReadLine();

                bool repeat = true;

                while (repeat)
                {
                    Console.WriteLine("Write the msg or 'x' to close :");
                    string msg = Console.ReadLine();
                    if (msg.ToLower().Equals("x"))
                    {
                        repeat = false;
                    }
                    client.Publish(topic, Encoding.ASCII.GetBytes(msg));
                }
                Console.WriteLine("Publish stopped. Please exit the application");

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.ToString());
            }



        }
    }
}