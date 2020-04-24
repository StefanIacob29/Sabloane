using System;
using HospitalManagement.Models;

namespace HospitalManagement.Services
{
    public class Observer
    {
        public string AppointmentString;
        private Patient patient;

        public void AddObserver(Patient patient)
        {
            this.patient = patient;
        }

        public void SetDate(DateTime date, string departament)
        {
            AppointmentString = "La data de " + date.Day + "/" + date.Month + "/" + date.Year + " la ora " +
                                date.ToString("HH:mm") + " aveti o programare la " + departament;
            patient.updateAppoinment(AppointmentString);
        }
    }
}