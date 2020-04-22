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
                Name = "admin",
                Password = "admin",
                Role = "surgeon"
            }
        };

        public void AddEmployee(Doctor doctor)
        {
            Employees.Add(doctor);
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
