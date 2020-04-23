using System;
using System.Collections.Generic;
using System.Text;
using HospitalManagement.Models;
namespace HospitalManagement.Services
{
    class Oftalmologie:Departament
    {
        private Doctor doctor;

        public Oftalmologie(Doctor doctor)
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
