using System;
using System.Net;
using PlayTech.Model;
using System.Timers;
using PlayTech.Webservice;

namespace Playtech.Roulette.Model
{
    public class RouletteViewModel :  IDisposable
    {
        private readonly Timer _exibitionTimer;
        private HttpWebservice<RouletteJsonModel> _server;

        public RouletteNumber[] Numbers { get; } = new RouletteNumber[37];
        public RouletteNumber Even { get; set; } = new RouletteNumber();
        public RouletteNumber Odd { get; set; } = new RouletteNumber();
        public RouletteNumber Red { get; set; } = new RouletteNumber();
        public RouletteNumber Black { get; set; } = new RouletteNumber();
        public RouletteNumber OneTo18 { get; set; } = new RouletteNumber();
        public RouletteNumber NineteenTo36 { get; set; } = new RouletteNumber();
        public RouletteNumber FirstDozen { get; set; } = new RouletteNumber();
        public RouletteNumber SecondDozen { get; set; } = new RouletteNumber();
        public RouletteNumber ThirdDozen { get; set; } = new RouletteNumber();
        public RouletteNumber GroupA { get; set; } = new RouletteNumber();
        public RouletteNumber GroupB { get; set; } = new RouletteNumber();
        public RouletteNumber GroupC { get; set; } = new RouletteNumber();
        public RoulettePopUp Popup { get; set; } = new RoulettePopUp();

        public RouletteViewModel()
        {
            Even.Label = "Even";
            Odd.Label = "Odd";
            Red.Label = " ";
            Black.Label = " ";
            OneTo18.Label = "1 to 18";
            NineteenTo36.Label = "19 to 36";
            FirstDozen.Label = "1st 12";
            SecondDozen.Label = "2nd 12";
            ThirdDozen.Label = "3rd 12";
            GroupA.Label = "2to1";
            GroupB.Label = "2to1";
            GroupC.Label = "2to1";

            for (var i = 0; i < Numbers.Length; i++)
            {
                Numbers[i] = new RouletteNumber
                {
                    Label = i.ToString(),
                    IsActive = false
                };
                if (i <= 10)
                {
                    Numbers[i].IsRed = (i & 0x1) == 1;
                }
                else if (i > 10 && i <= 18)
                {
                    Numbers[i].IsRed = (i & 0x1) != 1;
                }
                else if (i > 18 && i <= 28)
                {
                    Numbers[i].IsRed = (i & 0x1) == 1;
                }
                else
                {
                    Numbers[i].IsRed = (i & 0x1) != 1 ;
                }
            }
            _exibitionTimer = new Timer(10000); // 10 Seconds of notification
            _exibitionTimer.Elapsed += T_Elapsed;
            InstantiateServer();
        }
        
        private void InstantiateServer()
        {
            if (_server != null) return;
            _server = new HttpWebservice<RouletteJsonModel>("http://localhost:4948/");
            _server.ReceivedPkgHandler += WebserverObjectHandler;
            _server.HttpWebserverException += WebServiceException;
            _server.StartServer();
        }
        private void WebServiceException(object sender, WebException e)
        {
            try
            {
                _server.StopServer();
            }
            catch
            {
                _server = null;
            }
            finally
            {
                InstantiateServer();
                _server.StartServer();
            }
        }
        private void WebserverObjectHandler(object sender, HttpWebServerEventArgs<RouletteJsonModel> e)
        {
            if (int.TryParse(e.SchemaObject.Data.WinningNumber, out int i))
                GlowButton(i);
        }
        /// <summary>
        ///     Timer Call back that returns the GUI to the initial state
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void T_Elapsed(object sender, ElapsedEventArgs e)
        {
            _exibitionTimer.Stop();
            foreach (var t in Numbers)
                t.IsActive = false;

            Even.IsActive = false;
            Odd.IsActive = false;
            Red.IsActive = false;
            Black.IsActive = false;
            OneTo18.IsActive = false;
            NineteenTo36.IsActive = false;
            FirstDozen.IsActive = false;
            SecondDozen.IsActive = false;
            ThirdDozen.IsActive = false;
            GroupA.IsActive = false;
            GroupB.IsActive = false;
            GroupC.IsActive = false;
            Popup.Visibility = false;
        }
        /// <summary>
        ///     Glow the buttons according with the number
        /// </summary>
        /// <param name="number">Number between 0 - 36 </param>
        private void GlowButton(int number)
        {
            if (number >= Numbers.Length)
                return;
            Numbers[number].IsActive = true;

            if (number == 0) return;

            if (Numbers[number].IsRed)
                Red.IsActive = true;
            else
                Black.IsActive = true;
            if ((number & 0x1) == 1)
                Even.IsActive = true;
            else
                Odd.IsActive = true;

            if (number <= 18)
                OneTo18.IsActive = true;
            else
                NineteenTo36.IsActive = true;

            if (number <= 12)
                FirstDozen.IsActive = true;
            else if (number > 12 && number <= 24)
                SecondDozen.IsActive = true;
            else
                ThirdDozen.IsActive = true;
            if (number % 3 == 0)
                GroupC.IsActive = true;
            else if (((number % 3) & 0x1) == 1)
                GroupA.IsActive = true;
            else
                GroupB.IsActive = true;

            Popup.Number = number.ToString();
            Popup.Color = Red.IsActive ? "Red" : "Black";
            Popup.EvenOdd = Odd.IsActive ? "Odd" : "Even";
            Popup.Dozen = FirstDozen.IsActive ? "First Dozen" : SecondDozen.IsActive ? "Second Dozen" : "Third Dozen";
            Popup.Group = GroupA.IsActive ? "Column A" : GroupB.IsActive ? "Column B" : "Column C";
            Popup.LowHigh = OneTo18.IsActive ? "Low" : "High";
            Popup.Visibility = true;
            _exibitionTimer.Start();
        }

        public void Dispose()
        {
            _server.StopServer();
            _server.Dispose();
            _exibitionTimer.Dispose();
        }
    }
}
