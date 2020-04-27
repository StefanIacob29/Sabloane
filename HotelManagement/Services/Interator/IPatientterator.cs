using HospitalManagement.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalManagement.Services.Interator
{
    interface IPatientterator
    {
        Patient First();
        Patient Next();
        bool IsDone { get; }
        Patient CurrentPatient { get; }
    }
}
