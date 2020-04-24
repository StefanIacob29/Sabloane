using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalManagement.Flyweight
{
    class CashRegisterCard : CashRegister
    {   
        public override Money CreateNewMoney()
        {
            return new CardMoney();
        }

        public override bool IsSharedValue(double value)
        {
            return false;
        }
    }
}
