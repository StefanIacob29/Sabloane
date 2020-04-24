using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalManagement.Flyweight
{
    public abstract class Money
    {
        public double TotalCashValue { get; internal set; } = 0.0;

        public abstract EMoneyType GetMoneyType();
    }
}
