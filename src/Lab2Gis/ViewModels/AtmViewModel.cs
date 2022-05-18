using Lab2Gis.Commands;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Lab2Gis.ViewModels
{
    public class AtmViewModel : INotifyPropertyChanged
    {
        private AtmRepository _atmRepository;
        private Atm _atm;
        private AtmStatusViewModel _atmStatus;

        public async Task InitializeAsync(AtmRepository atmRepository, string atmId)
        {
            _atmRepository = atmRepository;

            var atms = await _atmRepository.GetAtmsAsync();
            var atm = atms.FirstOrDefault(atm => atm.Id == atmId);
            var atmStatus = await _atmRepository.GetAtmStatusAsync(atmId);

            _atm = atm;
            _atmStatus = new AtmStatusViewModel(atmStatus);
            UpdateBalanceCommand = new Command(commandParameter =>
            {
                var window = (Window)commandParameter;
                _atmRepository.UpdateAtmAsync(atmId, _atmStatus.AtmStatus);
                window.DialogResult = true;
                window.Close();
            }, null);
        }

        public string Name
        {
            get => _atm?.Name;
            set
            {
                if (value == _atm.Name) return;
                _atm.Name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public Command UpdateBalanceCommand { get; private set; }

        public AtmStatusViewModel AtmStatus
        {
            get => _atmStatus;
            set
            {
                if (value == _atmStatus) return;
                _atmStatus = value;
                OnPropertyChanged(nameof(AtmStatus));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}