using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalManagement.Flyweight
{
    class Cashier
    {
        private CashRegisterCoin _coinMoney;
        private CashRegisterPaper _paperMoney;
        private CashRegisterCard _cardMoney;

        public Cashier()
        {
            _coinMoney = new CashRegisterCoin();
            _paperMoney = new CashRegisterPaper();
            _cardMoney = new CashRegisterCard();
        }

        public void CashIn(double value, EMoneyType moneyType)
        {
            switch(moneyType)
            {
                case EMoneyType.Card:
                    _cardMoney.CashIn(value);
                    break;
                case EMoneyType.Coin:
                    _coinMoney.CashIn(value);
                    break;
                case EMoneyType.Paper:
                    _paperMoney.CashIn(value);
                    break;
            }
        }

        public void CashOut(double value, EMoneyType moneyType)
        {
            switch (moneyType)
            {
                case EMoneyType.Card:
                    _cardMoney.CashOut(value);
                    break;
                case EMoneyType.Coin:
                    _coinMoney.CashOut(value);
                    break;
                case EMoneyType.Paper:
                    _paperMoney.CashOut(value);
                    break;
            }
        }

        public double GetTotalCash()
        {   
            return _coinMoney.GetTotalCash() + _cardMoney.GetTotalCash() + _paperMoney.GetTotalCash();
          
        }
    }
}
