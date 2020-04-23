using System;
using System.Collections.Generic;
using HospitalManagement.Models;

namespace HospitalManagement.Services
{
    public class DoctorService
    {
        public List<Doctor> Employees { get; set; } = new List<Doctor>()
        {
            new Doctor()
            {
                Name = "urologie",
                Password = "urologie",
                Role = "urologie"
            },
            new Doctor()
            {
                Name = "stomatologie‎",
                Password = "stomatologie‎",
                Role = "stomatologie‎"
            },
            new Doctor()
            {
                Name = "ortopedie‎",
                Password = "ortopedie‎",
                Role = "ortopedie‎"
            },
            new Doctor()
            {
                Name = "oftalmologie‎",
                Password = "oftalmologie‎",
                Role = "oftalmologie‎"
            },
            new Doctor()
            {
                Name = "chirurgie‎",
                Password = "chirurgie‎",
                Role = "chirurgie‎"
            },
            new Doctor()
            {
                Name = "cardiologie‎‎",
                Password = "cardiologie‎",
                Role = "cardiologie‎"
            }
        };

        public void AddEmployee(Doctor doctor)
        {
            Employees.Add(doctor);
        }
        public void updateDoctor(Doctor doc)
        {
            for(var i = 0; i < Employees.Count; i++)
            {
                if (Employees[i].Role == doc.Role)
                    Employees[i] = doc;
            }
        }
        public Doctor getDoctorByDepartment(string department)
        {
            foreach(var doc in Employees)
            {
                if (String.Equals(doc.Role, department, StringComparison.InvariantCultureIgnoreCase))
                    return doc;
            }
            return null;
        }
        public List<string> getDepartmenst()
        {
            List<string> departament = new List<string>();
            foreach(var doc in Employees)
            {
                departament.Add(doc.Role);
            }
            return departament;
        }
        public void RemoveEmployee(Doctor doctor)
        {
            if (Employees.Contains(doctor))
            {
                Employees.Remove(doctor);
            }
        }
    }
}
