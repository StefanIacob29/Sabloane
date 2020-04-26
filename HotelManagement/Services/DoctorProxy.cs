using System;
using System.Linq;

namespace HospitalManagement.Services
{
    public class DoctorProxy
    {
        private readonly DoctorService _doctorService = new DoctorService();

        public bool Login(string username, string password)
        {
            var user = _doctorService.Employees
                .Select(employee => employee)
                .FirstOrDefault(employee => String.Equals(employee.Name, username, StringComparison.InvariantCultureIgnoreCase)  && String.Equals(employee.Password, password, StringComparison.InvariantCultureIgnoreCase) );

            return user != null;
        }
    }
}
