using System;
using System.Collections.Generic;
using System.Text;
using HotelManagement.Models;

namespace HotelManagement.Services
{
    class PatientService
    {
        public List<Patient> Patients { get; set; } = new List<Patient>();

        public int AddPatient(string name)
        {
            int id = Patients.Count + 1;
            Patients.Add(new Patient(name, id));
            return id;
        }
        public Patient getPatient(int id)
        {
            foreach(var it in Patients)
            {
                if (it.Id == id)
                    return it;
            }

            return null;
        }
    }
}
