using HospitalManagement.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalManagement.Decorator
{
    abstract class TreatmentDecorator:ITreatment
    {
        protected ITreatment DecoratedTreatment { get; set; }
        public ETreatmentType TreatmentType { get; set; }
        public int Price { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public List<Pill> Pills { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public TreatmentDecorator(ITreatment myTreatment)
        {
            this.DecoratedTreatment = myTreatment;
        }
        public abstract void  AddPill(string pillName, int price);
        public override string ToString()
        {
            return $"{this.DecoratedTreatment.TreatmentType} {this.DecoratedTreatment.Price} {this.DecoratedTreatment.Pills} ";
        }
    }
}
