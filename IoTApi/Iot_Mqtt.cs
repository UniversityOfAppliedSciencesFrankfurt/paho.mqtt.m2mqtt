using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using Mqtt_Core;
using System.Text;
using Mqtt_Core.Messages;
using Daenet.Iot;


namespace Daenet.Iot
{
     
        public class Iot_Mqtt : IIotApi
        {

            #region Private Section

            private MqttClient _mqttClient;
            private string _uniqueDeviceId;

            #endregion Private Section



            public string Name
            {
                get
                {
                    return "myIot_Mqtt";
                }
            }

            public Task OnMessage(Func<object, bool> onReceiveMsg, CancellationToken cancelationToken, Dictionary<string, object> args = null)
            {
                throw new NotImplementedException();

            }

            public Task Open(Dictionary<string, object> args)

            {
                string connectionToMqtt = args.FirstOrDefault(x => x.Key.Contains("mqttConnectionString")).Value.ToString();

                return Task.Run(() => {
                    
                    _mqttClient = new MqttClient(connectionToMqtt);

                    _uniqueDeviceId = Guid.NewGuid().ToString();

                    _mqttClient.Connect(_uniqueDeviceId);

                                       
                });

            }

            private void _mqttClient_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
            {

           
            Console.WriteLine("Topic : " + e.Topic + "  Message :" + Encoding.ASCII.GetString(e.Message));
        }

            public void Open(string hostName, IIotApi client)
            {
                throw new NotImplementedException();
            }

            public Task ReceiveAsync(Func<object, bool> onSuccess = null, Func<Exception, bool> onError = null,
                int timeout = 60000, Dictionary<string, object> args = null)
            {

                return Task.Run(() =>

                {

                    List<string> subTopicList = new List<string>();
                    List<byte> qosList = new List<byte>();
                    foreach (var item in args)
                    {
                        if (item.Key.Contains("subscribeTopic"))
                        {
                            subTopicList.Add(item.Value.ToString());
                            qosList.Add(MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE);
                        }
                    }
                    _mqttClient.Subscribe(subTopicList.ToArray(), qosList.ToArray());

                    _mqttClient.MqttMsgPublishReceived += _mqttClient_MqttMsgPublishReceived;
                    
                });
        }
            public void RegisterAcknowledge(Action<string, Exception> onAcknowledgeReceived)
            {
                throw new NotImplementedException();
            }

            public Task SendAsync(IList<object> sensorMessages, Action<IList<object>> onSuccess = null, Action<IList<object>, Exception> onError = null, Dictionary<string, object> args = null)
            {
                List<string> pubMessages = new List<string>();
                List<string> topicList = new List<string>();

                foreach (object item in sensorMessages)
                {
                    pubMessages.Add(item.ToString());
                }

                foreach (var topic in args)
                {
                    if (topic.Key.Equals("topicName"))
                    {
                        topicList.Add(topic.Value.ToString());
                    }
                }

                return Task.Run(() =>
                {

                    foreach (var ourTopic in topicList)
                    {
                        foreach (var msg in pubMessages)
                        {
                            _mqttClient.Publish(ourTopic, Encoding.ASCII.GetBytes(msg));
                        }
                    }

                });
            }

            public Task SendAsync(object sensorMessage, Action<IList<object>> onSuccess = null, Action<IList<object>, Exception> onError = null, Dictionary<string, object> args = null)
            {
                throw new NotImplementedException();
            }
        }
 }

