using System.Windows;
using System.Windows.Controls;

namespace PlayTech.Roulette
{
    /// <summary>
    ///     Interaction logic for PopUp.xaml
    /// </summary>
    public partial class PopUp : UserControl
    {
        public PopUp()
        {
            InitializeComponent();
            Visibility = Visibility.Hidden;
        }
        #region Visible Property

        /// <summary>
        ///     Dependency property from Background color
        /// </summary>
        public static readonly DependencyProperty VisibleProperty =
            DependencyProperty.Register("Visible", typeof(bool), typeof(PopUp), new
                PropertyMetadata(false, OnVisibleChanged));
        /// <summary>
        ///     Color of the background when the Control is not activated
        /// </summary>
        public bool Visible
        {
            get => (bool)GetValue(VisibleProperty);
            set => SetValue(VisibleProperty, value);
        }

        private static void OnVisibleChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as PopUp;
            control?.OnVisibleChanged(e);
        }

        private void OnVisibleChanged(DependencyPropertyChangedEventArgs e)
        {
            if ((bool)e.NewValue)
                Visibility = Visibility.Visible;
            else
                Visibility = Visibility.Hidden;
              
        }

        #endregion
        #region Number Property

        /// <summary>
        ///     Dependency property from Text
        /// </summary>
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Number", typeof(string), typeof(PopUp), new
                PropertyMetadata("", OnNumberChanged));

        /// <summary>
        ///     Control text label
        /// </summary>
        public string Number
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        private static void OnNumberChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as PopUp;
            control?.OnNumberChanged(e);
        }

        private void OnNumberChanged(DependencyPropertyChangedEventArgs e)
        {
            N.Text = (string) e.NewValue;
        }

        #endregion
        #region Color Property

        /// <summary>
        ///     Dependency property from Text
        /// </summary>
        public static readonly DependencyProperty ColorProperty =
            DependencyProperty.Register("Color", typeof(string), typeof(PopUp), new
                PropertyMetadata("", OnColorChanged));

        /// <summary>
        ///     Control text label
        /// </summary>
        public string Color
        {
            get => (string)GetValue(ColorProperty);
            set => SetValue(ColorProperty, value);
        }

        private static void OnColorChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as PopUp;
            control?.OnColorChanged(e);
        }

        private void OnColorChanged(DependencyPropertyChangedEventArgs e)
        {
            NColor.Text = (string)e.NewValue;
        }

        #endregion
        #region Even/Odd Property

        /// <summary>
        ///     Dependency property from Text
        /// </summary>
        public static readonly DependencyProperty EvenOddProperty =
            DependencyProperty.Register("EvenOdd", typeof(string), typeof(PopUp), new
                PropertyMetadata("", OnEvenOddChanged));

        /// <summary>
        ///     Control text label
        /// </summary>
        public string EvenOdd
        {
            get => (string)GetValue(EvenOddProperty);
            set => SetValue(EvenOddProperty, value);
        }

        private static void OnEvenOddChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as PopUp;
            control?.OnEvenOddChanged(e);
        }

        private void OnEvenOddChanged(DependencyPropertyChangedEventArgs e)
        {
            NEvenOdd.Text = (string)e.NewValue;
        }

        #endregion
        #region Dozen Property

        /// <summary>
        ///     Dependency property from Text
        /// </summary>
        public static readonly DependencyProperty DozenProperty =
            DependencyProperty.Register("Dozen", typeof(string), typeof(PopUp), new
                PropertyMetadata("", OnDozenChanged));

        /// <summary>
        ///     Control text label
        /// </summary>
        public string Dozen
        {
            get => (string)GetValue(DozenProperty);
            set => SetValue(DozenProperty, value);
        }

        private static void OnDozenChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as PopUp;
            control?.OnDozenChanged(e);
        }

        private void OnDozenChanged(DependencyPropertyChangedEventArgs e)
        {
            NDozen.Text = (string)e.NewValue;
        }

        #endregion
        #region Column Property

        /// <summary>
        ///     Dependency property from Text
        /// </summary>
        public static readonly DependencyProperty ColumnProperty =
            DependencyProperty.Register("Column", typeof(string), typeof(PopUp), new
                PropertyMetadata("", OnColumnChanged));

        /// <summary>
        ///     Control text label
        /// </summary>
        public string Column
        {
            get => (string)GetValue(ColumnProperty);
            set => SetValue(ColumnProperty, value);
        }

        private static void OnColumnChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as PopUp;
            control?.OnColumnChanged(e);
        }

        private void OnColumnChanged(DependencyPropertyChangedEventArgs e)
        {
            NGroup.Text = (string)e.NewValue;
        }

        #endregion
        #region Low/High Property

        /// <summary>
        ///     Dependency property from Text
        /// </summary>
        public static readonly DependencyProperty LowHighProperty =
            DependencyProperty.Register("LowHigh", typeof(string), typeof(PopUp), new
                PropertyMetadata("", OnLowHighChanged));

        /// <summary>
        ///     Control text label
        /// </summary>
        public string LowHigh
        {
            get => (string)GetValue(LowHighProperty);
            set => SetValue(LowHighProperty, value);
        }

        private static void OnLowHighChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as PopUp;
            control?.OnLowHighChanged(e);
        }

        private void OnLowHighChanged(DependencyPropertyChangedEventArgs e)
        {
            NLowHigh.Text = (string)e.NewValue;
        }

        #endregion
    }
}