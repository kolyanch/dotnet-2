using Lab2Gis.ViewModels;

namespace Lab2Gis.Views
{
    public partial class AtmsView
    {
        public AtmsView()
        {
            InitializeComponent();
        }

        public AtmsView(AtmsViewModel atmsViewModel)
        {
            InitializeComponent();
            DataContext = atmsViewModel;
        }
    }
}
