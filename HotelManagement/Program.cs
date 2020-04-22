using System;
using HospitalManagement.Models;
using HospitalManagement.Services;

namespace HospitalManagement
{
    class Program
    {
        private static readonly PatientService PatientService = new PatientService();
        static void LoggedClientMenu(int id)
        {
            Patient patient = PatientService.GetPatient(id);
            while (true)
            {
                Console.Clear();
                Console.WriteLine("--------------Client Menu--------------");
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
        public static void ClientMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("--------------Client Menu--------------");
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
                            if (PatientService.GetPatient(id) != null)
                                LoggedClientMenu(id);
                            break;
                        }
                    case 2:
                        {
                            Console.Clear();
                            Console.WriteLine("Enter your name: ");
                            string name = Console.ReadLine();
                            LoggedClientMenu(PatientService.AddPatient(name));
                            break;
                        }
                }
                if (op == 0)
                    break;
            }
        }
        private static void EmployeeMenu()
        {
            DoctorProxy doctorProxy = new DoctorProxy();
            Console.Clear();
            Console.WriteLine("--------------Doctor Menu--------------");
            Console.WriteLine("Username: ");
            string username = Console.ReadLine();
            Console.WriteLine("Password: ");
            string password = Console.ReadLine();
            if (doctorProxy.Login(username, password))
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
                Console.WriteLine("1.Doctor");
                Console.WriteLine("2.Client");
                Console.WriteLine("0.Exit");
                int op= Convert.ToInt32( Console.ReadLine());
                switch (op)
                {
                    case 1:
                        EmployeeMenu();
                        break;
                    case 2:
                        ClientMenu();
                        break;
                }

                if (op == 0)
                    break;
            }   
            
        }
    }
}
