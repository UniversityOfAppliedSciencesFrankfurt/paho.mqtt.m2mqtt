

using System.Collections;
using System.Collections.Generic;
using Mqtt_Core.Messages;

namespace Mqtt_Core.Session
{
    /// <summary>
    /// MQTT Session base class
    /// </summary>
    public abstract class MqttSession
    {
        /// <summary>
        /// Client Id
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// Messages inflight during session
        /// </summary>
        public Dictionary<string, MqttMsgContext> InflightMessages { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public MqttSession()
            : this(null)
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="clientId">Client Id to create session</param>
        public MqttSession(string clientId)
        {
            this.ClientId = clientId;
            this.InflightMessages = new Dictionary<string, MqttMsgContext>();
        }

        /// <summary>
        /// Clean session
        /// </summary>
        public virtual void Clear()
        {
            this.ClientId = null;
            this.InflightMessages.Clear();
        }
    }
}
