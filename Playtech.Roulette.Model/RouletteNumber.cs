using System.ComponentModel;
namespace Playtech.Roulette.Model
{
    public class RouletteNumber : INotifyPropertyChanged
    {
        private bool _isActive;
        private bool _isRed = true;
        public string Label { get; set; }

        public bool IsActive
        {
            get => _isActive;
            set
            {
                _isActive = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("IsActive"));
            }
        }

        public bool IsRed
        {
            get => _isRed;
            set
            {
                _isRed = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("IsRed"));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
