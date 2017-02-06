using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Mqtt_Core.Exceptions
{
    /// <summary>
    /// Connection to the broker exception
    /// </summary>
    public class MqttConnectionException : Exception
    {
        public MqttConnectionException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}

