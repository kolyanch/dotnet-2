using Lab2Gis.Commands;
using Lab2Gis.Views;
using System.Threading.Tasks;

namespace Lab2Gis.ViewModels
{
    public class MapViewModel
    {
        public AtmRepository AtmRepository { get; }

        public MapViewModel()
        {
            AtmRepository = new AtmRepository();
            ShowAtmsListCommand = new Command(async _ =>
            {
                var atmsViewModel = new AtmsViewModel();
                await atmsViewModel.InitializeAsync(AtmRepository);
                var atmsView = new AtmsView(atmsViewModel);
                atmsView.ShowDialog();
            }, null);
        }

        public Command ShowAtmsListCommand { get; }

        public async Task ShowAtmInfo(string atmId)
        {
            var atmViewModel = new AtmViewModel();
            await atmViewModel.InitializeAsync(AtmRepository, atmId);
            var atmInfoView = new AtmView(atmViewModel);
            atmInfoView.ShowDialog();
        }
    }
}