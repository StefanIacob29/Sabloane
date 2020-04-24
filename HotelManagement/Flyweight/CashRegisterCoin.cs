using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalManagement.Flyweight
{
    class CashRegisterCoin : CashRegister
    {
        public override Money CreateNewMoney()
        {
            return new CoinMoney();
        }

        public override bool IsSharedValue(double value)
        {
            return CoinMoney.IsSharedValue(value);
        }
    }
}
