using System;
using System.Collections.Generic;
using System.Text;
using HospitalManagement.Models;

namespace HospitalManagement.Services
{
    class Ortopedie:Departament
    {
        private Doctor doctor;

        public Ortopedie(Doctor doctor)
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
