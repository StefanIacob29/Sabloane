using HospitalManagement.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalManagement.Decorator
{
    public interface ITreatment
    {
        ETreatmentType TreatmentType { get; set; }
        int Price { get; set; }

        public List<Pill> Pills { get; set; }
        public void AddPill(string pillName, int price);
    }
}
