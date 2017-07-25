using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayTech.Webservice
{
    /// <summary>
    /// Arguments of a Roulette Server Event
    /// </summary>
    public class HttpWebServerEventArgs<T> : EventArgs where T : class
    {
        public T SchemaObject;
    }
}
