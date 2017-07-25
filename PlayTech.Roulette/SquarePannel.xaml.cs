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
        Color _oldColor;
        public SquarePannel()
        {
            InitializeComponent();
        } 
        public static readonly DependencyProperty IsActiveProperty =
            DependencyProperty.Register("IsActive", typeof(bool), typeof(SquarePannel), new
            PropertyMetadata(false, new PropertyChangedCallback(OnIsActiveChanged)));

        public bool IsActive
        {
            get { return (bool)GetValue(IsActiveProperty); }
            set { SetValue(IsActiveProperty, value); }
        }

        private static void OnIsActiveChanged(DependencyObject d,
           DependencyPropertyChangedEventArgs e)
        {
            SquarePannel Control = d as SquarePannel;
            Control.OnIsActiveChanged(e);
        }

        private void OnIsActiveChanged(DependencyPropertyChangedEventArgs e)
        {
            _active = (bool) e.NewValue;
            Animate();
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
                    rec.Fill = new SolidColorBrush(FillColor);
                    if (FillColor == Colors.Red)
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
        //Color Property
        public static readonly DependencyProperty BackColorProperty =
            DependencyProperty.Register("BackColor", typeof(Color), typeof(SquarePannel), new
            PropertyMetadata(Colors.Red, new PropertyChangedCallback(OnBackColorChanged)));

        public Color BackColor
        {
            get { return (Color)GetValue(BackColorProperty); }
            set { SetValue(BackColorProperty, value); }
        }

        private static void OnBackColorChanged(DependencyObject d,
           DependencyPropertyChangedEventArgs e)
        {
            SquarePannel Control = d as SquarePannel;
            Control.OnBackColorChanged(e);
        }

        private void OnBackColorChanged(DependencyPropertyChangedEventArgs e)
        {
            FillColor = (Color)e.NewValue;
        }
        private Color FillColor
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
            get
            {
                return _oldColor;
            }
        }

        public static readonly DependencyProperty TextProperty =
         DependencyProperty.Register("Text", typeof(string), typeof(SquarePannel), new
            PropertyMetadata("", new PropertyChangedCallback(OnTextChanged)));

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        private static void OnTextChanged(DependencyObject d,
           DependencyPropertyChangedEventArgs e)
        {
            SquarePannel Control = d as SquarePannel;
            Control.OnTextChanged(e);
        }

        private void OnTextChanged(DependencyPropertyChangedEventArgs e)
        {
            number.Text = e.NewValue.ToString();
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
