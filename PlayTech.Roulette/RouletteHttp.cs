using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;
using System.Net;
using System.Threading;
using System.IO;

namespace PlayTech.Roulette
{
    /// <summary>
    /// Http server implementation for receiving roulette bets
    /// </summary>
    public class RouletteHttp
    {
        HttpListener listener = null;
        Thread t = null;
        /// <summary>
        /// Instantiate a Http Server
        /// </summary>
        /// <param name="url">the URL that the server answers</param>
        public RouletteHttp(string url)
        {
            listener = new HttpListener();
            t = new Thread(T_main);
            listener.Prefixes.Add(url);
        }
        ~RouletteHttp()
        {
            t = null;
            listener = null;
        }
        /// <summary>
        /// Arguments of a Roulette Server Event
        /// </summary>
        public class RouletteEventArgs : EventArgs
        {
            public int number;
            public Int64 correlation;
        }
        /// <summary>
        /// Handler for Packets incoming from Http Server
        /// </summary>
        public EventHandler<RouletteEventArgs> ReceivedPkgHandler;
        /// <summary>
        /// Http Server Thread
        /// </summary>
        private void T_main()
        {
            try
            {
                while(true)
                {
                    HttpListenerContext context = listener.GetContext(); // Pause until a request come
                    string msg = "OK";
                    context.Response.StatusCode = (int)HttpStatusCode.OK;
                    if (context.Request.HasEntityBody) // If has a body deals, otherwise ignore it
                    {
                        using (StreamReader reader = new StreamReader(context.Request.InputStream))
                        {
                            var js = reader.ReadToEnd(); // Read the body and stores for JSON parse trial
                            try
                            {
                                PlaytechInputSchema schema = JsonConvert.DeserializeObject<PlaytechInputSchema>(js);
                                if (ReceivedPkgHandler != null)
                                {
                                    var a = new RouletteEventArgs();
                                    //Try parse the numbers, if not valid integers ignore the packet
                                    if (int.TryParse(schema.Data.WinningNumber, out a.number) && 
                                            Int64.TryParse(schema.Correlation, out a.correlation))
                                                ReceivedPkgHandler?.Invoke(this, a);
                                }
                            }
                            catch // The JSON provided not match the Schema, give to the user an answer and ignore the content
                            {
                                msg = "Bad Request: The JSON do not delivery the right Schema";
                                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                            }
                            
                        }
                    }
                    //Write to caller the appropriate answer
                    context.Response.ContentLength64 = Encoding.UTF8.GetByteCount(msg);
                    using (Stream stream = context.Response.OutputStream)
                    {
                        using (StreamWriter writer = new StreamWriter(stream))
                        {
                            writer.Write(msg);
                        }
                    }
                }
            }
            catch(WebException we)
            {
                System.Windows.MessageBox.Show("The HTTP Server Cannot Execute the Assignment Task\n" + we.Message );
            }
            catch(Exception)
            {
                //When the thread is aborted is generated an exception
                //This catch hide the exception from the user for a smooth application closure
            }
        }
        /// <summary>
        /// Start the Server Thread and open the Listener flow
        /// </summary>
        public void StartServer()
        {
            t.Start();
            listener.Start();
        }
        /// <summary>
        /// Stop the listener flow and abort the server thread
        /// </summary>
        public void StopServer()
        {
            listener.Stop();
            Thread.Sleep(5);
            t.Abort();
        }
    }
}
