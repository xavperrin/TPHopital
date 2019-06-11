using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
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
