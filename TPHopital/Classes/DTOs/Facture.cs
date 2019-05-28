using System;
using System.Collections.Generic;
using System.Text;

namespace TPHopital.Classes.DTOs
{
    public class Facture:DTO
    {
        private int id_facture;
        private DateTime date_facture;
        private decimal total;
        private int admission_id;

        public Facture()
        {

        }

        public Facture(int id_facture, DateTime date_facture, decimal total, int admission_id)
        {
            this.id_facture = id_facture;
            this.date_facture = date_facture;
            this.total = total;
            this.admission_id = admission_id;
        }

        public int Id_facture { get => id_facture; set => id_facture = value; }
        public DateTime Date_facture { get => date_facture; set => date_facture = value; }
        public decimal Total { get => total; set => total = value; }
        public int Admission_id { get => admission_id; set => admission_id = value; }

        public override bool CheckData()
        {
            if (date_facture == null)
                return false;
            else return true;
        }

        public override string ToString()
        {
            return "Facture (id :"+id_facture+", date : "+date_facture+", total : "+total;
        }
    }
}
