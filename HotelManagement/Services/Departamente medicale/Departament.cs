using HospitalManagement.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalManagement.Services
{
    public interface Departament
    {
        public Doctor makeAppointment(Patient Client, DateTime date);
    }
}
