namespace HotelManagement.Models
{
    public class Employee
    {
        public string Name { get; set; }

        public string Password { get; set; }

        public string Role { get; set; }

        public override bool Equals(object obj)
        {
            Employee employee = obj as Employee;

            if (employee == null)
            {
                return false;
            }

            return Name == employee.Name &&
                   Password == employee.Password &&
                   Role == employee.Role;
        }
    }
}
