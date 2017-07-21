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
        private bool _vertical = false;
        bool _active = false;
        Color _oldColor = Colors.Black;
        public SquarePannel()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Get or Set the Active status of the component witch cause it to change for cyan color
        /// Back to old color when the status is false
        /// </summary>
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
        /// <summary>
        /// Deals with the color change
        /// </summary>
        private void Animate()
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
        /// <summary>
        /// Change the ViewBox Text Margin to scale the text for a better fit
        /// </summary>
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
        /// <summary>
        /// Color of the component if red the text become black
        /// </summary>
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
        /// <summary>
        /// The text displayed in GUI
        /// </summary>
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
        /// <summary>
        /// If true change the rotation of the displayed text to Vertical
        /// </summary>
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
    }
}
