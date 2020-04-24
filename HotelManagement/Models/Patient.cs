using HospitalManagement.Decorator;

namespace HospitalManagement.Models
{
    public class Patient
    {
        public string Name { get; set; }

        public int Id { get; set; }

        public float Budget { get; set; }

        public ITreatment Treatment { get; set; }

        public string Appointment { get; set; }

        public Patient(string name,int id)
        {
            this.Name = name;
            this.Budget = 15000;
            this.Id = id;
            Treatment = new TreatmentModel();
        }
        public void updateAppoinment(string date)
        {
            this.Appointment = date;
        }

        public override string ToString()
        {
            return $"{this.Name} ";
        }

    }
}
