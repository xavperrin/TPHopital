using System.Windows;
using TPHopitalWpf.ViewModels;

namespace TPHopitalWpf.Views
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
