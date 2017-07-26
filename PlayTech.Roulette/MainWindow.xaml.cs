using Playtech.Roulette.Model;
using System;
using System.Windows;

namespace PlayTech.Roulette
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly RouletteViewModel _viewmodel = new RouletteViewModel();
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = _viewmodel;
        }

        /// <summary>
        ///     Clean the resources before exit the application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Closed(object sender, EventArgs e)
        {
            _viewmodel.Dispose();
        }
    }
}