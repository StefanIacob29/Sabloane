using System;
using HotelManagement.Services;

namespace HotelManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            EmployeeProxy employeeProxy = new EmployeeProxy();
            Console.WriteLine("Please enter the username and password to access the system: ");
            string username = Console.ReadLine();
            string password = Console.ReadLine();

            if (employeeProxy.Login(username, password))
            {
                Stock stock = Stock.GetStock();
                Console.WriteLine(stock.ShowPillStock());
            }
            else
            {
                Console.WriteLine("The username or password is not correct");
            }
            
        }
    }
}
