namespace HotelManagement.Models
{
    public class Patient
    {
        public string Name { get; set; }

        public string Id { get; set; }

        public TreatmentModel Treatment { get; set; }

        public Appointment Appointment { get; set; }
    }
}
