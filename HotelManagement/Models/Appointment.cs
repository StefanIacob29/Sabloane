using HospitalManagement.Decorator;
using System;

namespace HospitalManagement.Models
{
    public class Appointment
    {

        public Appointment(Patient client, DateTime date)
        {
            this.Patient = client;

            ITreatment treatment = new TreatmentModel();
            this.Patient.Treatment = treatment;
            this.Date = date;
        }

        public Patient Patient { get; set; }
        public DateTime Date { get; set; }
    }
}
