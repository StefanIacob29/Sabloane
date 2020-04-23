using System;

namespace HospitalManagement.Models
{
    public class Appointment
    {

        public Appointment(Patient client, DateTime date)
        {
            this.Patient = client;
            this.Date = date;
        }

        public Patient Patient { get; set; }
        public DateTime Date { get; set; }
    }
}
