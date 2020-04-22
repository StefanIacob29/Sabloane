namespace HospitalManagement.Models
{
    public class Patient
    {
        public string Name { get; set; }

        public int Id { get; set; }

        public TreatmentModel Treatment { get; set; }

        public Appointment Appointment { get; set; }

        public Patient(string name,int id)
        {
            this.Name = name;
            this.Id = id;
        }
    }
}
