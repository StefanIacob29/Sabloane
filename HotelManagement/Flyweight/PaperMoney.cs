using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalManagement.Flyweight
{
    class PaperMoney : Money
    {
        public override EMoneyType GetMoneyType()
        {
            return EMoneyType.Paper;
        }

        public static bool IsSharedValue(double value)
        {
            return (value == 1 || value == 5 || value == 10 || value == 50 || value == 100 || value == 200 || value == 500) ;
        }
    }
}
