using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using System.Windows.Input;
using TPHopitalWpf.Classes;
using TPHopitalWpf.Classes.DAO;

namespace TPHopitalWpf.ViewModels
{
    public class MedecinsViewModel : ViewModelBase
    {
        public Medecin medecin { get; set; }
        public MedecinDAO dao { get; set; }
        public ObservableCollection<Medecin> listeMedecins { get; set; }
        public ICommand AddCommand { get; set; }


        public string Nom_Medecin
        {
            get
            {
                return medecin.Nom_medecin;
            }
            set
            {
                medecin.Nom_medecin = value;
                RaisePropertyChanged();
            }
        }

        public string Prenom_Medecin
        {
            get
            {
                return medecin.Prenom_medecin;
            }
            set
            {
                medecin.Prenom_medecin = value;
                RaisePropertyChanged();
            }
        }
        
             public string Tel_Medecin
                {
            get
            {
                return medecin.Tel_medecin;
            }
            set
            {
                medecin.Tel_medecin = value;
                RaisePropertyChanged();
            }
                }


        public MedecinsViewModel()
        {
            medecin = new Medecin();
            listeMedecins = Medecin.ListAll();
            AddCommand = new RelayCommand(AddMedecin);
        }
        

        private void AddMedecin ()
        {
            dao.Create(medecin);
            listeMedecins.Add(medecin);
        }  
    }
}