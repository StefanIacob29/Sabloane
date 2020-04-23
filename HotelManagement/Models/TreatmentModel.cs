using HospitalManagement.Decorator;
using System.Collections.Generic;

namespace HospitalManagement.Models
{
    public class TreatmentModel:ITreatment
    {
        public string TreatmentName { get; set; }
        public List<Pill> Pills { get; set; }

        public ETreatmentType TreatmentType { get; set; }
        public int Price { get; set; }
        public TreatmentModel()
        {
            this.TreatmentType = ETreatmentType.NONE;
            Pills = new List<Pill>();
            this.Price = 0;
        }


        public void AddPill()
        {
           //at the beggining there are no pills
        }

        public void AddPill(string pillName, int price)
        {
            throw new System.NotImplementedException();
        }
    }
}
