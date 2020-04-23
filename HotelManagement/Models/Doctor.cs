using System.Collections.Generic;

namespace HospitalManagement.Models
{
    public class Doctor
    {
        public string Name { get; set; }

        public string Password { get; set; }

        public string Role { get; set; }

        public List<Appointment> appointments = new List<Appointment>();

        public override bool Equals(object obj)
        {
            Doctor doctor = obj as Doctor;

            if (doctor == null)
            {
                return false;
            }

            return Name == doctor.Name &&
                   Password == doctor.Password &&
                   Role == doctor.Role;
        }
    }
}
