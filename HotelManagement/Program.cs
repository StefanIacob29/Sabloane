using System;
using System.Collections.Generic;
using HospitalManagement.Models;
using HospitalManagement.Services;

namespace HospitalManagement
{
    class Program
    {
        private static DoctorProxy doctorProxy = new DoctorProxy();
        private static DepartamentService departamentService = new DepartamentService();
        private static DoctorService doctorService = new DoctorService();
        private static PatientService PatientService = new PatientService();
        private static List<string> departments=new List<string>() { "urologie", "stomatologie", "ortopedie", "oftalmologie", "chirurgie", "cardiologie" };
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
                            int ct = 1;
                            Console.Clear();
                            Console.WriteLine("Alege departamentul la care vrei sa faci o programare");
                            foreach (var dep in departments)
                            {
                                Console.WriteLine(ct + "." + dep);
                                ct++;
                            }
                            int op2 = Convert.ToInt32(Console.ReadLine());
                            Console.Clear();
                            DateTime now = DateTime.Now;
                            string[] months = {"January", "February", "March", "April", "May",
                             "June", "July", "September", "October", "November", "December"};
                            Console.WriteLine("Alege data la care vrei sa faci programarea");
                            for(int i=1;i<=5;i++)
                            {
                                now = now.AddDays(1);
                                Console.WriteLine(i + "." + now.Day+" "+ months[now.Month - 1]);
                            }
                            int op3 = Convert.ToInt32(Console.ReadLine());
                            Console.Clear();
                            DateTime hour = new DateTime(2008, 4, 1, 9, 0, 0);
                            for (int i = 1; i <= 13; i++)
                            {
                                Console.WriteLine(i + "." + hour.ToString("HH:mm"));
                                hour=hour.AddMinutes(30);
                            }
                            int op4 = Convert.ToInt32(Console.ReadLine());
                            now = DateTime.Now;
                            now =now.AddDays(op3);
                            hour = new DateTime(2008, 4, 1, 9, 0, 0);
                            hour=hour.AddMinutes(30 * (op4 - 1));
                            DateTime appoiment = new DateTime(now.Year, now.Month, now.Day, hour.Hour, hour.Minute,0,0);
                            departamentService.makeAppointment(patient, appoiment, doctorService.getDoctorByDepartment(departments[op2-1]));
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
