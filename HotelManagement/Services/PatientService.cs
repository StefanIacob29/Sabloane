﻿using System.Collections.Generic;
using HospitalManagement.Models;
using HospitalManagement.Services.Interator;

namespace HospitalManagement.Services
{
    internal class PatientService
    {
        public List<Patient> Patients { get; set; } = new List<Patient>();

        public int AddPatient(string name)
        {
            int id = Patients.Count + 1;
            Patients.Add(new Patient(name, id));
            return id;
        }
        public Patient GetPatient(int id)
        {
            PatientIterator iterator = new PatientIterator(Patients);
            for (Patient item = iterator.First();
                !iterator.IsDone; item = iterator.Next())
            {
                if (item.Id == id)
                {
                    return item;
                }
            }
           /* foreach (var patient in Patients)
            {
                if (patient.Id == id)
                {
                    return patient;
                }
            }*/

            return null;
        }

        public int GetPatientIndex(int id)
        {
            PatientIterator iterator = new PatientIterator(Patients);
            for (Patient item = iterator.First();
                !iterator.IsDone; item = iterator.Next())
            {
                if (item.Id == id)
                {
                    return iterator.getCurrentIndex();
                }
            }
           /* for (int index = 0; index < Patients.Count; ++index)
                if (Patients[index].Id == id)
                    return index;*/
            return -1;
        }

        public float SumToPay(Patient patient)

        {
            float sum = 0;
            foreach (Pill pill in patient.Treatment.Pills)
            {
                sum += pill.Price;
            }
            return sum;
        }
    }
}