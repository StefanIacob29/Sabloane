using HospitalManagement.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalManagement.Services.Departamente_medicale
{
    class Cardiologie‎:Departament
    {
        private Doctor doctor;

        public Cardiologie(Doctor doctor)
        {
            this.doctor = doctor;
        }

        public Doctor makeAppointment(Patient Client, DateTime date)
        {
            foreach (var app in doctor.appointments)
            {
                if (app.Date == date)
                    return null;

            }
            doctor.appointments.Add(new Appointment(Client, date));
            return doctor;
        }
    }
}
