using System.Data;
using System.Linq;
using HotelManagement.Models;

namespace HotelManagement.Services
{
    public class EmployeeProxy
    {
        private EmployeeService employeeService = new EmployeeService();

        public bool Login(string username, string password)
        {
            var user = employeeService.Employees
                .Select(employee => employee)
                .FirstOrDefault(employee => employee.Name == username && employee.Password == password);

            return user != null;
        }

    }
}
