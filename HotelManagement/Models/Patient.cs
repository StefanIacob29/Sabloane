using HospitalManagement.Decorator;

namespace HospitalManagement.Models
{
    public class Patient
    {
        public string Name { get; set; }

        public int Id { get; set; }

        public ITreatment Treatment { get; set; }

        public string Appointment { get; set; }

        public Patient(string name,int id)
        {
            this.Name = name;
            this.Id = id;
            Treatment = new TreatmentModel();
        }
        public void updateAppoinment(string date)
        {
            this.Appointment = date;
        }
    }
}
