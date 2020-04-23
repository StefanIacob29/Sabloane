﻿using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using HospitalManagement.Decorator;
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
        private static Observer observable = new Observer();
        private static List<string> departments=new List<string>() { "urologie","stomatologie","ortopedie","oftalmologie","chirurgie","cardiologie" };
        static void LoggedClientMenu(int id)
        {
            Patient patient = PatientService.GetPatient(id);
            observable.addObserver(patient);
            while (true)
            {
                Console.Clear();
                Console.WriteLine("--------------Client Menu--------------");
                Console.WriteLine("Welcome " + patient.Name + " your access code is " + id.ToString());
                if (patient.Appointment != null)
                    Console.WriteLine(patient.Appointment);
                Console.WriteLine();
                Console.WriteLine("1.See Treatment");
                Console.WriteLine("2.Pay");
                if(patient.Appointment==null)
                    Console.WriteLine("3.Make appointment");
                Console.WriteLine("0.Logout");
                int op = Convert.ToInt32(Console.ReadLine());
                switch (op)
                {
                    case 3:
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
                            Doctor doc=departamentService.makeAppointment(patient, appoiment, doctorService.getDoctorByDepartment(departments[op2-1]));
                            if (doc != null)
                            {
                                observable.setDate(appoiment, departments[op2 - 1]);
                                doctorService.updateDoctor(doc);
                                Console.Clear();
                                Console.WriteLine("Programarea a fost realizata");
                                Console.WriteLine("Press any key to continue");
                                Console.ReadLine();
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Programarea nu a fost realizata, exista o programare la acea data si ora");
                                Console.WriteLine("Press any key to continue");
                                Console.ReadLine();
                            }
                                
                            break;
                        }
                    case 1:
                        {
                            Console.Clear();
                            if (patient.Treatment.Pills.Count > 0)
                            {
                                Console.WriteLine("Tratamentul Dvs. este urmatorul");
                                foreach (var trat in patient.Treatment.Pills)
                                    Console.WriteLine("Nume pastila: " + trat.Name + " Cantitate: " + trat.Quantity + " Pret: " + trat.Price);
                            }
                            else
                                Console.WriteLine("Nu aveti momentan un tratament atribuit");
                            Console.WriteLine("Press any key to continue");
                            Console.ReadLine();
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("Pay");
                            break;
                        }
                }
                if (op == 0)
                    break;
            }

        }
        public static void DoSomethingWithPatient(int option)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("--------------Client Menu--------------");
                var patient = PatientService.GetPatient(option);

                Console.WriteLine("This is his treatment type"+ patient.Treatment.TreatmentType.ToString());
                Console.WriteLine("This is his pills");
                foreach (var pill in patient.Treatment.Pills)
                {
                    Console.WriteLine(pill.Name);
                }

                Console.WriteLine("Current stock");

                Stock stock = Stock.GetStock();
                Console.WriteLine(stock.ShowPillStock());

                Console.WriteLine(" Which pill u want to add");

                int option2 = Convert.ToInt32(Console.ReadLine());
                var selectedPill = stock.Pills[option2];
                //patient.Treatment.Pills.Add(selectedPill);
                ITreatment itreat=new TreatmentModel();
                switch(patient.Treatment.TreatmentType)
                {
                    case ETreatmentType.NONE:
                        itreat = new FacileDecorator(patient.Treatment, selectedPill.Name, (int)selectedPill.Price);
                        break;
                    case ETreatmentType.FACILE:
                        itreat = new SolvableDecorator(patient.Treatment, selectedPill.Name, (int)selectedPill.Price);
                        break;
                    case ETreatmentType.SOLVABLE:
                        itreat = new MediumDecorator(patient.Treatment, selectedPill.Name, (int)selectedPill.Price);
                        break;
                    case ETreatmentType.MEDIUM:
                        itreat = new RiskyDecorator(patient.Treatment, selectedPill.Name, (int)selectedPill.Price);
                        break;
                    
                    default: 
                        itreat = new RiskyDecorator(patient.Treatment, selectedPill.Name, (int)selectedPill.Price);
                        break;

                }
               // int pacientId = PatientService.GetPatientIndex(option);
                //PatientService.Patients[pacientId].Treatment = itreat;
                
                selectedPill.Quantity -= 1;

                Console.ReadKey();
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
                Console.Clear();
                Console.WriteLine("--------------Doctor Menu--------------");
                Console.WriteLine("1.Modify treatment");
                Console.WriteLine("0.Back");


                int op = Convert.ToInt32(Console.ReadLine());
                switch (op)
                {
                    case 1:
                        {

                           
                                Stock stock = Stock.GetStock();
                                Console.WriteLine(stock.ShowPillStock());
                                int index = 0;
                                foreach (var patient in PatientService.Patients)
                                {
                                    Console.WriteLine(index + "." + patient);
                                    index++;
                                }
                                Console.WriteLine("Choose a patient ");

                                int option = Convert.ToInt32(Console.ReadLine());
                                if (option == 0) break;
                                DoSomethingWithPatient(option);
                                break;



                        }
                    default:
                        break;
                }
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
