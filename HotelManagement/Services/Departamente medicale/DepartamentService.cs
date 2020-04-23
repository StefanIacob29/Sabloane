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
        public Doctor makeAppointment(Patient client,DateTime date,Doctor doctor)
        {

            switch (doctor.Role)
            {
                case "urologie":
                    {
                        departament = new Urologie(doctor);
                        return departament.makeAppointment(client, date);
                        
                    }
                case "stomatologie":
                    {
                        departament = new Stomatologie(doctor);
                        return departament.makeAppointment(client, date);

                    }
                case "ortopedie":
                    {
                        departament = new Ortopedie(doctor);
                        return departament.makeAppointment(client, date);

                    }
                case "oftalmologie":
                    {
                        departament = new Oftalmologie(doctor);
                        return departament.makeAppointment(client, date);

                    }
                case "chirurgie":
                    {
                        departament = new Chirurgie(doctor);
                        return departament.makeAppointment(client, date);

                    }
                case "cardiologie":
                    {
                        departament = new Cardiologie(doctor);
                        return departament.makeAppointment(client, date);

                    }
            }
            return null;
        }
    }
}
