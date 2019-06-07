using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using TPHopitalWpf.Classes;
using TPHopitalWpf.Classes.DAO;


namespace TPHopitalWpf.ViewModels
{
    public class MedecinsViewModel : ViewModelBase
    {
        public Medecin medecin { get; set; }

        public Medecin medecinSelected { get; set; }

        public MedecinDAO dao { get; set; }
        public ObservableCollection<Medecin> listeMedecins { get; set; }
        public ICommand AddCommand { get; set; }
        
        public ICommand EditCommand { get; set; }

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
            dao = new MedecinDAO();
            listeMedecins = new ObservableCollection<Medecin>(dao.ListAll());
            AddCommand = new RelayCommand(AddMedecin);//Action
            EditCommand = new RelayCommand(EditMedecin);
        }

        private void EditMedecin()
        {
            if (medecinSelected != null)
            {
                Nom_Medecin = medecinSelected.Nom_medecin;
                Prenom_Medecin = medecinSelected.Prenom_medecin;
                Tel_Medecin = medecinSelected.Tel_medecin;
                medecin.Id_medecin = medecinSelected.Id_medecin;
  
            }
            else
                MessageBox.Show("Veuillez sélectionner un medecin!");

            //dao.Update(medecin, medecin.Id_medecin);



        }

        private void AddMedecin()//Action
        {
            dao.Create(medecin);
            listeMedecins.Add(medecin);

            //soit un client qui existe à modifier
            foreach (Medecin m in listeMedecins)
            {
                if (m.Id_medecin == medecin.Id_medecin)
                {

                }
            }
            medecin = new Medecin();
            Nom_Medecin = "";
            Prenom_Medecin = "";
            Tel_Medecin = "";
        }  
    }
}