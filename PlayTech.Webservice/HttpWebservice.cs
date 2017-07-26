using System;
using System.Text;
using Newtonsoft.Json;
using System.Net;
using System.Threading;
using System.IO;

namespace PlayTech.Webservice
{
    /// <summary>
    /// Http server implementation for receiving roulette bets
    /// </summary>
    public class HttpWebservice<T> : IDisposable where T : class
    {
        private HttpListener _listener;
        private Thread _thread;

        /// <summary>
        /// Instantiate a Http Server
        /// </summary>
        /// <param name="url">the URL that the server answers</param>
        public HttpWebservice(string url) 
        {
            _listener = new HttpListener();
            _thread = new Thread(T_main);
            _listener.Prefixes.Add(url);
        }
        /// <summary>
        /// Handler for Packets incoming from Http Server
        /// </summary>
        public EventHandler<HttpWebServerEventArgs<T>> ReceivedPkgHandler;
        /// <summary>
        /// Handler for an Exception in Http Server
        /// </summary>
        public EventHandler<WebException> HttpWebserverException;
        /// <summary>
        /// Http Server Thread
        /// </summary>
        private void T_main()
        {
            try
            {
                while(true)
                {
                    var context = _listener.GetContext(); // Pause until a request come
                    var msg = "OK";
                    context.Response.StatusCode = (int)HttpStatusCode.OK;
                    if (context.Request.HasEntityBody) // If has a body deals, otherwise ignore it
                    {
                        using (var reader = new StreamReader(context.Request.InputStream))
                        {
                            var js = reader.ReadToEnd(); // Read the body and stores for JSON parse trial
                            try
                            {
                                T schema = JsonConvert.DeserializeObject<T>(js);
                                ReceivedPkgHandler?.Invoke(this, new HttpWebServerEventArgs<T>()
                                {
                                    SchemaObject = schema
                                });
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
                    using (var stream = context.Response.OutputStream)
                    {
                        using (var writer = new StreamWriter(stream))
                        {
                            writer.Write(msg);
                        }
                    }
                }
            }
            catch(WebException we)
            {
                HttpWebserverException?.Invoke(this, we);
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
            _thread.Start();
            _listener.Start();
        }
        /// <summary>
        /// Stop the listener flow and abort the server thread
        /// </summary>
        public void StopServer()
        {
            _listener.Stop();
            Thread.Sleep(5);
            _thread.Abort();
        }
        public void Dispose()
        {
            _thread = null;
            _listener = null;
        }
    }
}
