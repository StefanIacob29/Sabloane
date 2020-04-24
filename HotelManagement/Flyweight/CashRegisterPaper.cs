using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalManagement.Flyweight
{
    class CashRegisterPaper : CashRegister
    {
        public override Money CreateNewMoney()
        {
            return new PaperMoney();
        }

        public override bool IsSharedValue(double value)
        {
            return PaperMoney.IsSharedValue(value);
        }
    }
}
