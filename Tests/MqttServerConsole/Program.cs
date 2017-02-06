using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mqtt_Core;



namespace ConsoleServer
{
    public class Program
    {
        public static void Main(string[] args)

        {   // already existing mqtt broker "broker.hivemq.com" is used for testing
            MqttClient client = new MqttClient("broker.hivemq.com");
            // creating universial uniqe code for client identity
            string uniqueserverid = Guid.NewGuid().ToString();

            // method connect() with client id as a parameter- to connect to above assigned broker.
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

                    // mqtt method publish() to publish a message as bytes
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