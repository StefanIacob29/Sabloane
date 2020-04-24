using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalManagement.Flyweight
{
    public class CoinMoney : Money
    {
        public override EMoneyType GetMoneyType()
        {
            return EMoneyType.Coin;
        }

        public static bool IsSharedValue(double value)
        { 
            return (value == 0.01 || value == 0.05 || value == 0.1 || value == 0.5) ;
        }
    }
}
