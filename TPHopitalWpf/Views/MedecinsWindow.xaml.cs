using System.Windows;
using TPHopitalWpfEF.ViewModels;

namespace TPHopitalWpfEF.Views
{
    /// <summary>
    /// Logique d'interaction pour MedecinsWindow.xaml
    /// </summary>
    public partial class MedecinsWindow : Window
    {
        public MedecinsWindow()
        {
            InitializeComponent();
            DataContext = new MedecinsViewModel();
        }

        
    }
}
