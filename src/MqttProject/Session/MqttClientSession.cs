using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mqtt_Core.Session
{
    /// <summary>
    /// MQTT Client Session
    /// </summary>
    public class MqttClientSession : MqttSession
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="clientId">Client Id to create session</param>
        public MqttClientSession(string clientId)
            : base(clientId)
        {
        }
    }
}