using PlayTech.Model;
using PlayTech.Webservice;
using System;
using System.Collections.Generic;
using System.Timers;
using System.Windows;
using System.Windows.Media;
using System.Net;
using System.ComponentModel;

namespace PlayTech.Roulette
{
    public class Num : INotifyPropertyChanged
    {
        public string Label { get; set; }
        private bool _IsActive;
        public bool IsActive {
            get
            {
                return _IsActive;
            }
            set
            {
                _IsActive = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("IsActive"));
            }
        }
        public Color Color {get; set;}
        public event PropertyChangedEventHandler PropertyChanged;
    };
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Timer _ExibitionTimer;
        HttpWebservice<RouletteJsonModel> _Server;
        private Num[] _Numbers;

        public MainWindow()
        {
            _Numbers = new Num[37];
            for (int i = 0; i < _Numbers.Length; i++)
            {
                _Numbers[i] = new Num();
                _Numbers[i].Label = i.ToString();
                _Numbers[i].IsActive = false;
                if(i <=10)
                {
                    if ((i & 0x1) == 1)
                        _Numbers[i].Color = Colors.Red;
                    else
                        _Numbers[i].Color = Color.FromArgb(0xff, 0x11, 0x33, 0x11);
                }
                else if(i>10 && i <=18 )
                {
                    if ((i & 0x1) != 1)
                        _Numbers[i].Color = Colors.Red;
                    else
                        _Numbers[i].Color = Color.FromArgb(0xff, 0x11, 0x33, 0x11);
                }
                else if (i > 18 && i <=28)
                {
                    if ((i & 0x1) == 1)
                        _Numbers[i].Color = Colors.Red;
                    else
                        _Numbers[i].Color = Color.FromArgb(0xff, 0x11, 0x33, 0x11);
                }
                else
                {
                    if ((i & 0x1) != 1)
                        _Numbers[i].Color = Colors.Red;
                    else
                        _Numbers[i].Color = Color.FromArgb(0xff, 0x11, 0x33, 0x11);
                }
            }
                
            InitializeComponent();

            this.DataContext = this;
            _ExibitionTimer = new Timer(10000); // 10 Seconds of notification
            _ExibitionTimer.Elapsed += T_Elapsed;
            InstantiateServer();
        }
        public Num[] Numbers { get => _Numbers; set => _Numbers = value; }
        private void InstantiateServer()
        {
            if(_Server == null)
            {
                _Server = new HttpWebservice<RouletteJsonModel>("http://localhost:4948/");
                _Server.ReceivedPkgHandler += WebserverObjectHandler;
                _Server.HttpWebserverException += WebServiceException;
                _Server.StartServer();
            }
        }
        private void WebServiceException(object sender, WebException e)
        {
            try
            {
                _Server.StopServer();
            }
            catch
            {
                _Server = null;
            }
            finally
            {
                InstantiateServer();
                _Server.StartServer();
            }
        }
        ~MainWindow()
        {
            _Server = null;
            _ExibitionTimer = null;
        }
        private void WebserverObjectHandler(object sender, HttpWebServerEventArgs<RouletteJsonModel> e)
        {
            int i;
            if (Int32.TryParse(e.SchemaObject.Data.WinningNumber, out i))
                this.Dispatcher.Invoke(() =>
                {
                    GlowButton(i);
                });
        }

        /// <summary>
        /// Timer Call back that returns the GUI to the initial state
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void T_Elapsed(object sender, ElapsedEventArgs e)
        {
            _ExibitionTimer.Stop();
            this.Dispatcher.Invoke(() =>
            {
                foreach (var c in GetControls(this))
                {
                    if (c is SquarePannel sp )
                    {
                       if(sp.Name != "")
                            sp.IsActive = false;
                    }
                    if(c is BigGreenPannel bgp)
                    {
                        bgp.IsActive = false;
                    }
                }
                for (int i = 0; i < _Numbers.Length; i++)
                    _Numbers[i].IsActive = false;
            });
            Popup.Hide();
        }
        private IEnumerable<DependencyObject> GetControls(DependencyObject control)
        {
            if(control != null)
            {
                for(int i =0; i < VisualTreeHelper.GetChildrenCount(control);i++)
                {
                    DependencyObject cc = VisualTreeHelper.GetChild(control, i);
                    if (cc != null)
                        yield return cc;
                    foreach(var c in GetControls(cc))
                    {
                        yield return c;
                    }
                }
            }
        }
        /// <summary>
        /// Glow the buttons according with the number 
        /// </summary>
        /// <param name="number">Number between 0 - 36 </param>
        public void GlowButton(int number)
        {
            if (number >= _Numbers.Length)
                return;
            _Numbers[number].IsActive = true;
            
            if (_Numbers[number].Color == Colors.Red)
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
            if ((number % 3) == 0)
                GroupC.IsActive = true;
            else if (((number % 3) & 0x1) == 1)
                GroupA.IsActive = true;
            else
                GroupB.IsActive = true;
            Popup.Show(number.ToString(), Red.IsActive ? "Red" : "Black", Odd.IsActive ? "Odd" : "Even",
                FirstDozen.IsActive ? "First Dozen" : SecondDozen.IsActive ? "Second Dozen" : "Third Dozen",
                GroupA.IsActive ? "Column A" : GroupB.IsActive ? "Column B" : "Column C", OneTo18.IsActive ? "Low" : "High");      
            _ExibitionTimer.Start();     
        }
        /// <summary>
        /// Clean the resources before exit the application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Closed(object sender, EventArgs e)
        {
            _Server.StopServer();
            _ExibitionTimer.Stop();
            _ExibitionTimer.Dispose();
        }
    }
}
