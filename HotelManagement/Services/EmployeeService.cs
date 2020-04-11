using System.Collections.Generic;
using HotelManagement.Models;

namespace HotelManagement.Services
{
    public class EmployeeService
    {
        public List<Employee> Employees { get; set; } = new List<Employee>()
        {
            new Employee()
            {
                Name = "admin",
                Password = "admin",
                Role = "doctor"
            }
        };

        public void AddEmployee(Employee employee)
        {
            Employees.Add(employee);
        }

        public void RemoveEmployee(Employee employee)
        {
            if (Employees.Contains(employee))
            {
                Employees.Remove(employee);
            }
        }
    }
}
