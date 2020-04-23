using HospitalManagement.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalManagement.Decorator
{
    class RiskyDecorator:TreatmentDecorator
    {

        public RiskyDecorator(ITreatment treatment, string pillName, int price) : base(treatment)
        {
            this.DecoratedTreatment.TreatmentType = ETreatmentType.SOLVABLE;
            AddPill(pillName, price);
        }
        public override void AddPill(string pillName, int price)
        {
            this.DecoratedTreatment.Pills.Add(new Pill(pillName, 1, price));
            this.DecoratedTreatment.Price += price;
        }
    }
}
