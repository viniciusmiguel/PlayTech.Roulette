using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace PlayTech.Roulette
{
    /// <summary>
    /// Interaction logic for SquarePannel.xaml
    /// </summary>
    public partial class BigGreenPannel : UserControl
    {
        bool _active = false;
        public BigGreenPannel()
        {
            InitializeComponent();
        }
        public bool IsActive {
            set
            {
                if(value != _active)
                {
                    _active = value;
                    Animate();
                }
            }
            get
            {
                return _active;
            }
        }
        private void Animate()
        {
            this.Dispatcher.Invoke(() => {
                if (_active)
                {
                    number.Foreground = Brushes.Black;
                    Img.Source = new ImageSourceConverter().ConvertFromString("pack://siteoforigin:,,,/Resources/buttomcyan.png") as ImageSource;
                    Img.InvalidateArrange();
                }
                else
                {
                    number.Foreground = Brushes.White;
                    Img.Source = new ImageSourceConverter().ConvertFromString("pack://siteoforigin:,,,/Resources/buttom.png") as ImageSource;
                    Img.InvalidateArrange();
                }
            });            
        }
        public string Text {
            get
            {
                return number.Text;
            }
            set
            {
                number.Text = value;
            }
        }
  
        private void UserControl_SizeChanged(object sender, SizeChangedEventArgs e)
        {

        }
    }
}
