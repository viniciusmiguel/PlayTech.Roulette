
using System.ComponentModel;

namespace Playtech.Roulette.Model
{
    public class RoulettePopUp : INotifyPropertyChanged
    {
        private string _number;
        private string _lowHigh;
        private string _group;
        private string _color;
        private string _dozen;
        private string _evenOdd;
        private bool _visibility;
        public event PropertyChangedEventHandler PropertyChanged;

        public bool Visibility
        {
            get { return _visibility; }
            set
            {
                _visibility = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Visibility"));
            }
        }

        public string Number
        {
            get { return _number; }
            set { _number = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Number"));
            }
        }

        public string LowHigh
        {
            get { return _lowHigh; }
            set { _lowHigh = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("LowHigh"));
            }
        }

        public string Group
        {
            get { return _group; }
            set
            {
                _group = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Group"));
            }
        }

        public string EvenOdd
        {
            get { return _evenOdd; }
            set
            {
                _evenOdd = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("EvenOdd"));
            }
        }

        public string Color
        {
            get { return _color; }
            set
            {
                _color = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Color"));
            }
        }

        public string Dozen
        {
            get { return _dozen; }
            set
            {
                _dozen = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Dozen"));
            }
        }
    }
}
