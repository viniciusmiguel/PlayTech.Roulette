using System;
using System.Collections.Generic;
using System.Timers;
using System.Windows;

namespace PlayTech.Roulette
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        System.Timers.Timer t;
        RouletteHttp server;
        public MainWindow()
        {
            InitializeComponent();
            t = new System.Timers.Timer(10000); // 10 Seconds of notification
            t.Elapsed += T_Elapsed;
            server = new RouletteHttp();
            server.EvHandler += serverHandler;
            server.StartServer();
        }
        ~MainWindow()
        {
            server = null;
            t = null;
        }
        private void serverHandler(object sender, RouletteHttp.RouletteEventArgs e)
        {
            //TODO: what to do with e.correlation ??
            GlowButton(e.number);
        }

        /// <summary>
        /// Timer Call back that returns the GUI to the initial state
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void T_Elapsed(object sender, ElapsedEventArgs e)
        {
            t.Stop();
            //TODO: it's ugly, improve this code 
            N0.IsActive = false;
            N1.IsActive = false;
            N2.IsActive = false;
            N3.IsActive = false;
            N4.IsActive = false;
            N5.IsActive = false;
            N6.IsActive = false;
            N7.IsActive = false;
            N8.IsActive = false;
            N9.IsActive = false;
            N10.IsActive = false;
            N11.IsActive = false;
            N12.IsActive = false;
            N13.IsActive = false;
            N14.IsActive = false;
            N15.IsActive = false;
            N16.IsActive = false;
            N17.IsActive = false;
            N18.IsActive = false;
            N19.IsActive = false;
            N20.IsActive = false;
            N21.IsActive = false;
            N22.IsActive = false;
            N23.IsActive = false;
            N24.IsActive = false;
            N25.IsActive = false;
            N26.IsActive = false;
            N27.IsActive = false;
            N28.IsActive = false;
            N29.IsActive = false;
            N30.IsActive = false;
            N31.IsActive = false;
            N32.IsActive = false;
            N33.IsActive = false;
            N34.IsActive = false;
            N35.IsActive = false;
            N36.IsActive = false;
            Red.IsActive = false;
            Black.IsActive = false;
            Even.IsActive = false;
            Odd.IsActive = false;
            FirstDozen.IsActive = false;
            SecondDozen.IsActive = false;
            ThirdDozen.IsActive = false;
            OneTo18.IsActive = false;
            NineteenTo36.IsActive = false;
            GroupA.IsActive = false;
            GroupB.IsActive = false;
            GroupC.IsActive = false;
            Popup.Hide();
        }
        /// <summary>
        /// Glow the buttons according with the number 
        /// </summary>
        /// <param name="number">Number between 0 - 36 </param>
        public void GlowButton(int number)
        {
            switch(number)
            {
                case 0:
                    N0.IsActive = true;
                    t.Start();
                    return;
                case 1:
                    N1.IsActive = true;
                    Odd.IsActive = true;
                    GroupA.IsActive = true;
                    Red.IsActive = true;
                    OneTo18.IsActive = true;
                    FirstDozen.IsActive = true;
                    break;
                case 2:
                    N2.IsActive = true;
                    Even.IsActive = true;
                    GroupB.IsActive = true;
                    Black.IsActive = true;
                    OneTo18.IsActive = true;
                    FirstDozen.IsActive = true;
                    break;
                case 3:
                    N3.IsActive = true;
                    Odd.IsActive = true;
                    GroupC.IsActive = true;
                    Red.IsActive = true;
                    OneTo18.IsActive = true;
                    FirstDozen.IsActive = true;
                    break;
                case 4:
                    N4.IsActive = true;
                    Even.IsActive = true;
                    GroupA.IsActive = true;
                    Black.IsActive = true;
                    OneTo18.IsActive = true;
                    FirstDozen.IsActive = true;
                    break;
                case 5:
                    N5.IsActive = true;
                    Odd.IsActive = true;
                    GroupB.IsActive = true;
                    Red.IsActive = true;
                    OneTo18.IsActive = true;
                    FirstDozen.IsActive = true;
                    break;
                case 6:
                    N6.IsActive = true;
                    Even.IsActive = true;
                    GroupC.IsActive = true;
                    Black.IsActive = true;
                    OneTo18.IsActive = true;
                    FirstDozen.IsActive = true;
                    break;
                case 7:
                    N7.IsActive = true;
                    Odd.IsActive = true;
                    GroupA.IsActive = true;
                    Red.IsActive = true;
                    OneTo18.IsActive = true;
                    FirstDozen.IsActive = true;
                    break;
                case 8:
                    N8.IsActive = true;
                    Even.IsActive = true;
                    GroupB.IsActive = true;
                    Black.IsActive = true;
                    OneTo18.IsActive = true;
                    FirstDozen.IsActive = true;
                    break;
                case 9:
                    N9.IsActive = true;
                    Odd.IsActive = true;
                    GroupC.IsActive = true;
                    Red.IsActive = true;
                    OneTo18.IsActive = true;
                    FirstDozen.IsActive = true;
                    break;
                case 10:
                    N10.IsActive = true;
                    Even.IsActive = true;
                    GroupA.IsActive = true;
                    Black.IsActive = true;
                    OneTo18.IsActive = true;
                    FirstDozen.IsActive = true;
                    break;
                case 11:
                    N11.IsActive = true;
                    Odd.IsActive = true;
                    GroupB.IsActive = true;
                    Black.IsActive = true;
                    OneTo18.IsActive = true;
                    FirstDozen.IsActive = true;
                    break;
                case 12:
                    N12.IsActive = true;
                    Even.IsActive = true;
                    GroupC.IsActive = true;
                    Red.IsActive = true;
                    OneTo18.IsActive = true;
                    FirstDozen.IsActive = true;
                    break;
                case 13:
                    N13.IsActive = true;
                    Odd.IsActive = true;
                    GroupA.IsActive = true;
                    Black.IsActive = true;
                    OneTo18.IsActive = true;
                    SecondDozen.IsActive = true;
                    break;
                case 14:
                    N14.IsActive = true;
                    Even.IsActive = true;
                    GroupB.IsActive = true;
                    Red.IsActive = true;
                    OneTo18.IsActive = true;
                    SecondDozen.IsActive = true;
                    break;
                case 15:
                    N15.IsActive = true;
                    Odd.IsActive = true;
                    GroupC.IsActive = true;
                    Black.IsActive = true;
                    OneTo18.IsActive = true;
                    SecondDozen.IsActive = true;
                    break;
                case 16:
                    N16.IsActive = true;
                    Even.IsActive = true;
                    GroupA.IsActive = true;
                    Red.IsActive = true;
                    OneTo18.IsActive = true;
                    SecondDozen.IsActive = true;
                    break;
                case 17:
                    N17.IsActive = true;
                    Odd.IsActive = true;
                    GroupB.IsActive = true;
                    Black.IsActive = true;
                    OneTo18.IsActive = true;
                    SecondDozen.IsActive = true;
                    break;
                case 18:
                    N18.IsActive = true;
                    Even.IsActive = true;
                    GroupC.IsActive = true;
                    Red.IsActive = true;
                    OneTo18.IsActive = true;
                    SecondDozen.IsActive = true;
                    break;
                case 19:
                    N19.IsActive = true;
                    Odd.IsActive = true;
                    GroupA.IsActive = true;
                    Red.IsActive = true;
                    NineteenTo36.IsActive = true;
                    SecondDozen.IsActive = true;
                    break;
                case 20:
                    N20.IsActive = true;
                    Even.IsActive = true;
                    GroupB.IsActive = true;
                    Black.IsActive = true;
                    NineteenTo36.IsActive = true;
                    SecondDozen.IsActive = true;
                    break;
                case 21:
                    N21.IsActive = true;
                    Odd.IsActive = true;
                    GroupC.IsActive = true;
                    Red.IsActive = true;
                    NineteenTo36.IsActive = true;
                    SecondDozen.IsActive = true;
                    break;
                case 22:
                    N22.IsActive = true;
                    Even.IsActive = true;
                    GroupA.IsActive = true;
                    Black.IsActive = true;
                    NineteenTo36.IsActive = true;
                    SecondDozen.IsActive = true;
                    break;
                case 23:
                    N23.IsActive = true;
                    Odd.IsActive = true;
                    GroupB.IsActive = true;
                    Red.IsActive = true;
                    NineteenTo36.IsActive = true;
                    SecondDozen.IsActive = true;
                    break;
                case 24:
                    N24.IsActive = true;
                    Even.IsActive = true;
                    GroupC.IsActive = true;
                    Black.IsActive = true;
                    NineteenTo36.IsActive = true;
                    SecondDozen.IsActive = true;
                    break;
                case 25:
                    N25.IsActive = true;
                    Odd.IsActive = true;
                    GroupA.IsActive = true;
                    Red.IsActive = true;
                    NineteenTo36.IsActive = true;
                    ThirdDozen.IsActive = true;
                    break;
                case 26:
                    N26.IsActive = true;
                    Even.IsActive = true;
                    GroupB.IsActive = true;
                    Black.IsActive = true;
                    NineteenTo36.IsActive = true;
                    ThirdDozen.IsActive = true;
                    break;
                case 27:
                    N27.IsActive = true;
                    Odd.IsActive = true;
                    GroupC.IsActive = true;
                    Red.IsActive = true;
                    NineteenTo36.IsActive = true;
                    ThirdDozen.IsActive = true;
                    break;
                case 28:
                    N28.IsActive = true;
                    Even.IsActive = true;
                    GroupA.IsActive = true;
                    Black.IsActive = true;
                    NineteenTo36.IsActive = true;
                    ThirdDozen.IsActive = true;
                    break;
                case 29:
                    N29.IsActive = true;
                    Odd.IsActive = true;
                    GroupB.IsActive = true;
                    Black.IsActive = true;
                    NineteenTo36.IsActive = true;
                    ThirdDozen.IsActive = true;
                    break;
                case 30:
                    N30.IsActive = true;
                    Even.IsActive = true;
                    GroupC.IsActive = true;
                    Red.IsActive = true;
                    NineteenTo36.IsActive = true;
                    ThirdDozen.IsActive = true;
                    break;
                case 31:
                    N31.IsActive = true;
                    Odd.IsActive = true;
                    GroupA.IsActive = true;
                    Black.IsActive = true;
                    NineteenTo36.IsActive = true;
                    ThirdDozen.IsActive = true;
                    break;
                case 32:
                    N32.IsActive = true;
                    Even.IsActive = true;
                    GroupB.IsActive = true;
                    Red.IsActive = true;
                    NineteenTo36.IsActive = true;
                    ThirdDozen.IsActive = true;
                    break;
                case 33:
                    N33.IsActive = true;
                    Odd.IsActive = true;
                    GroupC.IsActive = true;
                    Black.IsActive = true;
                    NineteenTo36.IsActive = true;
                    ThirdDozen.IsActive = true;
                    break;
                case 34:
                    N34.IsActive = true;
                    Even.IsActive = true;
                    GroupA.IsActive = true;
                    Red.IsActive = true;
                    NineteenTo36.IsActive = true;
                    ThirdDozen.IsActive = true;
                    break;
                case 35:
                    N35.IsActive = true;
                    Odd.IsActive = true;
                    GroupB.IsActive = true;
                    Black.IsActive = true;
                    NineteenTo36.IsActive = true;
                    ThirdDozen.IsActive = true;
                    break;
                case 36:
                    N36.IsActive = true;
                    Even.IsActive = true;
                    GroupC.IsActive = true;
                    Red.IsActive = true;
                    NineteenTo36.IsActive = true;
                    ThirdDozen.IsActive = true;
                    break;
                default:
                    return;
            }

            Popup.Show(number.ToString(), Red.IsActive ? "Red" : "Black", Odd.IsActive ? "Odd" : "Even",
                FirstDozen.IsActive ? "First Dozen" : SecondDozen.IsActive ? "Second Dozen" : "Third Dozen",
                GroupA.IsActive ? "Column A" : GroupB.IsActive ? "Column B" : "Column C", OneTo18.IsActive ? "Low" : "High");
            t.Start();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            server.StopServer();
            t.Stop();
            t.Dispose();
        }
    }
}
