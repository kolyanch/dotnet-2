using System.ComponentModel;

namespace Lab2Gis.ViewModels
{
    public class AtmStatusViewModel : INotifyPropertyChanged
    {
        public AtmStatus AtmStatus { get; set; }

        public AtmStatusViewModel()
        {
            AtmStatus = new AtmStatus();
        }

        public AtmStatusViewModel(AtmStatus atmStatus)
        {
            AtmStatus = atmStatus;
        }

        public double Money
        {
            get => AtmStatus.Money;
            set
            {
                if (value == AtmStatus.Money) return;
                AtmStatus.Money = value;
                OnPropertyChanged(nameof(Money));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
