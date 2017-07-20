using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PlayTech.Roulette
{
    /// <summary>
    /// Interaction logic for PopUp.xaml
    /// </summary>
    public partial class PopUp : UserControl
    {
        public PopUp()
        {
            InitializeComponent();
            Visibility = Visibility.Hidden;
        }
        /// <summary>
        /// Show the PopUp on UI
        /// </summary>
        /// <param name="Number"></param>
        /// <param name="Color"></param>
        /// <param name="EvenOdd"></param>
        /// <param name="Dozen"></param>
        /// <param name="Colunm"></param>
        /// <param name="LowHigh"></param>
        public void Show(string Number, string Color, string EvenOdd, string Dozen, string Colunm, string LowHigh)
        {
            this.Dispatcher.Invoke(() => {
                number.Text = Number;
                NColor.Text = Color;
                NEvenOdd.Text = EvenOdd;
                NDozen.Text = Dozen;
                NGroup.Text = Colunm;
                NLowHigh.Text = LowHigh;
                Visibility = Visibility.Visible;
            });
            
        }
        /// <summary>
        /// Hide the PopUp from UI
        /// </summary>
        public void Hide()
        {
            this.Dispatcher.Invoke(() =>
            {
                Visibility = Visibility.Hidden;
            });
        }
    }
}
