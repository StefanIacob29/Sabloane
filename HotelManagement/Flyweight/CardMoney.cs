using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalManagement.Flyweight
{
    class CardMoney : Money
    {
        public override EMoneyType GetMoneyType()
        {
            return EMoneyType.Card;
        }
    }
}
