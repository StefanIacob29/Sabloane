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
                .FirstOrDefault(employee => employee.Name == username && employee.Password == password);

            return user != null;
        }
    }
}
