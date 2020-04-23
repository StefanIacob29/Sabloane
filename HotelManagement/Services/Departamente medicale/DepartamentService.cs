using HospitalManagement.Models;
using HospitalManagement.Services.Departamente_medicale;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalManagement.Services
{
    public class DepartamentService
    {
        private Departament departament;
        public Doctor makeAppointment(Patient client, DateTime date, Doctor doctor)
        {
            if (String.Equals(doctor.Role, "urologie", StringComparison.InvariantCultureIgnoreCase))
            {
                departament = new Urologie(doctor);
                return departament.makeAppointment(client, date);
            }
            if (String.Equals(doctor.Role, "stomatologie", StringComparison.InvariantCultureIgnoreCase))
            {
                departament = new Stomatologie(doctor);
                return departament.makeAppointment(client, date);
            }
            if (String.Equals(doctor.Role, "ortopedie", StringComparison.InvariantCultureIgnoreCase))
            {
                departament = new Ortopedie(doctor);
                return departament.makeAppointment(client, date);
            }
            if (String.Equals(doctor.Role, "oftalmologie", StringComparison.InvariantCultureIgnoreCase))
            {
                departament = new Oftalmologie(doctor);
                return departament.makeAppointment(client, date);
            }
            if (String.Equals(doctor.Role, "chirurgie", StringComparison.InvariantCultureIgnoreCase))
            {
                departament = new Chirurgie(doctor);
                return departament.makeAppointment(client, date);
            }
            if (String.Equals(doctor.Role, "cardiologie", StringComparison.InvariantCultureIgnoreCase))
            {
                departament = new Cardiologie(doctor);
                return departament.makeAppointment(client, date);
            }
            return null;
        }
    }
}
