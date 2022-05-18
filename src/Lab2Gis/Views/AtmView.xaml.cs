using Lab2Gis.ViewModels;

namespace Lab2Gis.Views
{
    public partial class AtmView
    {
        public AtmView()
        {
            InitializeComponent();
        }

        public AtmView(AtmViewModel atmViewModel)
        {
            InitializeComponent();
            DataContext = atmViewModel;
        }
    }
}
