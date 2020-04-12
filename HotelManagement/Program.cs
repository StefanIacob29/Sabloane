using System;
using HotelManagement.Services;
using HotelManagement.Models;
namespace HotelManagement
{
    class Program
    {
        static PatientService patientService = new PatientService();
        static void meniuLogedClient(int id)
        {
            Patient patient = patientService.getPatient(id);
            while (true)
            {
                Console.Clear();
                Console.WriteLine("--------------Client Meniu--------------");
                Console.WriteLine("Welcome " + patient.Name + " your access code is " + id.ToString());
                Console.WriteLine("1.Make appointment");
                Console.WriteLine("2.See Treatment");
                Console.WriteLine("3.Pay");
                Console.WriteLine("0.Logout");
                int op = Convert.ToInt32(Console.ReadLine());
                switch (op)
                {
                    case 1:
                        {
                            Console.WriteLine("Make appointment");
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("See Treatment");
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("Pay");
                            break;
                        }
                }
                if (op == 0)
                    break;
            }

        }
        static void meniuClient()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("--------------Client Meniu--------------");
                Console.WriteLine("1.Login");
                Console.WriteLine("2.New Client");
                Console.WriteLine("0.Back");
                int op = Convert.ToInt32(Console.ReadLine());
                switch (op)
                {
                    case 1:
                        {
                            Console.Clear();
                            Console.WriteLine("Enter your access code");
                            int id = Convert.ToInt32(Console.ReadLine());
                            if (patientService.getPatient(id) != null)
                                meniuLogedClient(id);
                            break;
                        }
                    case 2:
                        {
                            Console.Clear();
                            Console.WriteLine("Enter your name: ");
                            string name = Console.ReadLine();
                            meniuLogedClient(patientService.AddPatient(name));
                            break;
                        }
                }
                if (op == 0)
                    break;
            }
        }
        static void meniuEmployee()
        {
            EmployeeProxy employeeProxy = new EmployeeProxy();
            Console.Clear();
            Console.WriteLine("--------------Employee Meniu--------------");
            Console.WriteLine("Username: ");
            string username = Console.ReadLine();
            Console.WriteLine("Password: ");
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
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Please choose an option");
                Console.WriteLine("1.Employee");
                Console.WriteLine("2.Client");
                Console.WriteLine("0.Exit");
                int op= Convert.ToInt32( Console.ReadLine());
                switch (op)
                {
                    case 1:
                        meniuEmployee();break;
                    case 2:
                        meniuClient(); break;
                }
                if (op == 0)
                    break;
            }   
            
        }
    }
}
