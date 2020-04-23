using HospitalManagement.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalManagement.Services
{
    public class DepartamentService
    {
        private Departament departament;
        public void makeAppointment(Patient client,DateTime date,Doctor doctor)
        {
            switch (doctor.Role)
            {
                case "urologie":
                    {
                        departament = new Urologie(doctor);
                        departament.makeAppointment(client, date);
                        break;
                    }
                case "stomatologie": break;
                case "ortopedie": break;
                case "oftalmologie": break;
                case "chirurgie": break;
                case "cardiologie": break;
            }
        }
    }
}
