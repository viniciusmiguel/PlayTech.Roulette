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
    public class RouletteHttp
    {
        HttpListener listener = null;
        Thread t = null;
        public RouletteHttp()
        {
            listener = new HttpListener();
            t = new Thread(T_main);
            listener.Prefixes.Add("http://localhost:4948/");

        }
        ~RouletteHttp()
        {
            t = null;
            listener = null;
        }
        public class RouletteEventArgs : EventArgs
        {
            public int number;
            public Int64 correlation;
        }
        public EventHandler<RouletteEventArgs> EvHandler;
        private void T_main()
        {
            try
            {
                while(true)
                {
                    HttpListenerContext context = listener.GetContext(); // Pause until a request come
                    //Got a request, lets check it
                    string msg = "OK";
                    context.Response.StatusCode = (int)HttpStatusCode.OK;
                    if (context.Request.HasEntityBody)
                    {
                        using (StreamReader reader = new StreamReader(context.Request.InputStream))
                        {
                            var js = reader.ReadToEnd();
                            try
                            {
                                PlaytechInputSchema schema = JsonConvert.DeserializeObject<PlaytechInputSchema>(js);
                                if (EvHandler != null)
                                {
                                    var a = new RouletteEventArgs();
                                    if (int.TryParse(schema.Data.WinningNumber, out a.number) && Int64.TryParse(schema.Correlation, out a.correlation))
                                    {
                                        EvHandler?.Invoke(this, a);
                                    }

                                }
                            }
                            catch
                            {
                                msg = "Bad Request: The JSON do not delivery the right Schema";
                                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                            }
                            
                        }
                    }
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
            catch(Exception)
            {

            }
        }

        public void StartServer()
        {
            t.Start();
            listener.Start();
        }
        public void StopServer()
        {
            listener.Stop();
            Thread.Sleep(5);
            t.Abort();
        }
    }
}
