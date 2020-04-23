using HospitalManagement.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalManagement.Services
{
    public class Observer
    {
        public string appointmentString=null;
        private Patient patient;
        public void addObserver(Patient patient)
        {
            this.patient = patient;
        }
        public void setDate(DateTime date,string departament)
        {
            this.appointmentString = "La data de "+date.Day+"/"+date.Month+"/"+date.Year+ " la ora "+ date.ToString("HH:mm") + " aveti o programare la "+ departament;
            this.patient.updateAppoinment(this.appointmentString);
        }
    }
}
