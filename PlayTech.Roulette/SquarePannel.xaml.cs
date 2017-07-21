using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace PlayTech.Roulette
{
    /// <summary>
    /// Interaction logic for SquarePannel.xaml
    /// </summary>
    public partial class SquarePannel : UserControl
    {
        bool _active = false;
        Color _oldColor = Colors.Black;
        public SquarePannel()
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
            try
            {
                this.Dispatcher.Invoke(() => {
                    if (_active)
                    {
                        rec.Fill = Brushes.Cyan;
                        number.Foreground = Brushes.Black;
                    }
                    else
                    {
                        rec.Fill = new SolidColorBrush(_oldColor);
                        if (_oldColor == Colors.Red)
                            number.Foreground = Brushes.Black;
                        else
                            number.Foreground = Brushes.White;
                    }
                });
            }
            catch
            {
                
            }
            
        }
        public Thickness ViewBoxMargin {
            get
            {
                return vb.Margin;
            }
            set
            {
                vb.Margin = value;
            }
         }
        public Color BackColor
        {
            set
            {
                _oldColor = value;
                rec.Fill = new SolidColorBrush(value);
                if (_oldColor == Colors.Red)
                    number.Foreground = Brushes.Black;
                else
                    number.Foreground = Brushes.White;
            }
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
        private bool _vertical = false;
        public bool VerticalText {
            get
            {
                return _vertical;
            }
            set
            {
                _vertical = value;
                if (_vertical)
                    nangle.Angle = -90;
                else
                    nangle.Angle = 0;
            }
        }
        private void UserControl_SizeChanged(object sender, SizeChangedEventArgs e)
        {

        }
    }
}
