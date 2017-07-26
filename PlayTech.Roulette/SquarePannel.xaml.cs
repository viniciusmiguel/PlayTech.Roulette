using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace PlayTech.Roulette
{
    /// <summary>
    ///     Interaction logic for SquarePannel.xaml
    /// </summary>
    public partial class SquarePannel : UserControl
    {
        #region Constructor

        public SquarePannel()
        {
            InitializeComponent();
        }

        #endregion

        #region Private Methods

        private void Animate()
        {
            Dispatcher.Invoke(() =>
            {
                if (IsImage)
                {
                    if (_active)
                    {
                        number.Foreground = Brushes.Black;
                        Img.Source =
                            new ImageSourceConverter().ConvertFromString("pack://siteoforigin:,,,/Resources/buttomcyan.png")
                                as ImageSource;
                        Img.InvalidateArrange();
                    }
                    else
                    {
                        number.Foreground = Brushes.White;
                        Img.Source =
                            new ImageSourceConverter().ConvertFromString("pack://siteoforigin:,,,/Resources/buttom.png") as
                                ImageSource;
                        Img.InvalidateArrange();
                    }
                }
                else
                {
                    if (_active)
                    {
                        Rec.Fill = Brushes.Cyan;
                        number.Foreground = Brushes.Black;
                    }
                    else
                    {
                        Rec.Fill = new SolidColorBrush(_fillcolor);
                        number.Foreground = IsRed ? Brushes.Black : Brushes.White;
                    }
                }
                
            });
        }
        public bool IsImage
        {
            get => _isImage;
            set
            {
                _isImage = value;
                if (_isImage)
                {
                    Rectangle.Visibility = Visibility.Hidden;
                    Picture.Visibility = Visibility.Visible;
                }
                else
                {
                    Rectangle.Visibility = Visibility.Visible;
                    Picture.Visibility = Visibility.Hidden;
                }
            }
        }
        #endregion

        #region Private Variables

        private bool _vertical;
        private bool _active;
        private Color _fillcolor = Colors.Red;
        private bool _isImage;
        #endregion

        #region Dependency Properties

        #region IsActive Property

        /// <summary>
        ///     Is Active Dependency Property
        /// </summary>
        public static readonly DependencyProperty IsActiveProperty =
            DependencyProperty.Register("IsActive", typeof(bool), typeof(SquarePannel), new
                PropertyMetadata(false, OnIsActiveChanged));

        /// <summary>
        ///     Set or Gets the Control State
        /// </summary>
        public bool IsActive
        {
            get => (bool) GetValue(IsActiveProperty);
            set => SetValue(IsActiveProperty, value);
        }

        private static void OnIsActiveChanged(DependencyObject d,
            DependencyPropertyChangedEventArgs e)
        {
            var control = d as SquarePannel;
            control?.OnIsActiveChanged(e);
        }

        private void OnIsActiveChanged(DependencyPropertyChangedEventArgs e)
        {
            _active = (bool) e.NewValue;
            Animate();
        }

        #endregion

        #region IsRed Property

        /// <summary>
        ///     Dependency property from Background color
        /// </summary>
        public static readonly DependencyProperty IsRedProperty =
            DependencyProperty.Register("IsRed", typeof(bool), typeof(SquarePannel), new
                PropertyMetadata(true, OnIsRedChanged));

        /// <summary>
        ///     Color of the background when the Control is not activated
        /// </summary>
        public bool IsRed
        {
            get => (bool) GetValue(IsRedProperty);
            set => SetValue(IsRedProperty, value);
        }

        private static void OnIsRedChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as SquarePannel;
            control?.OnIsRedChanged(e);
        }

        private void OnIsRedChanged(DependencyPropertyChangedEventArgs e)
        {
            if ((bool) e.NewValue)
            {
                _fillcolor = Colors.Red;
            }
            else
            {
                _fillcolor = BackColor;
            }
            Animate();
        }

        #endregion

        #region Text Property

        /// <summary>
        ///     Dependency property from Text
        /// </summary>
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(SquarePannel), new
                PropertyMetadata("", OnTextChanged));

        /// <summary>
        ///     Control text label
        /// </summary>
        public string Text
        {
            get => (string) GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        private static void OnTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as SquarePannel;
            control?.OnTextChanged(e);
        }

        private void OnTextChanged(DependencyPropertyChangedEventArgs e)
        {
            number.Text = e.NewValue.ToString();
        }

        #endregion

        #endregion

        #region Public Properties
        public Color BackColor { get; set; } = Color.FromRgb(0x11,0x33,0x11);
        /// <summary>
        ///     Change the ViewBox Text Margin to scale the text for a better fit
        /// </summary>
        public Thickness ViewBoxMargin
        {
            get => vb.Margin;
            set => vb.Margin = value;
        }

        /// <summary>
        ///     If true change the rotation of the displayed text to Vertical
        /// </summary>
        public bool VerticalText
        {
            get => _vertical;
            set
            {
                _vertical = value;
                if (_vertical)
                    nangle.Angle = -90;
                else
                    nangle.Angle = 0;
            }
        }

        #endregion
    }
}