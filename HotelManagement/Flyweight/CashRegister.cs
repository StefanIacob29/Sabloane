using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalManagement.Flyweight
{
    public abstract class CashRegister
    {
        private Dictionary<double, Money> _sharedMoneyMap;
        private Money _unsharedMoney;

        public CashRegister()
        {
            _sharedMoneyMap = new Dictionary<double, Money>();
            _unsharedMoney = CreateNewMoney();
        }

        public Money Lookup(double value)
        {
            if (IsSharedValue(value))
            {
                if (_sharedMoneyMap.ContainsKey(value) == false)
                {
                    _sharedMoneyMap.Add(value, CreateNewMoney());
                }
                return _sharedMoneyMap[value];
            }
            return _unsharedMoney;
        }

        public void CashIn(double value)
        {
            Money money = this.Lookup(value);
            if (IsSharedValue(value) || money.GetMoneyType() == EMoneyType.Card)
            {
                money.TotalCashValue += value;
                Console.WriteLine("Cash in  added  " + value);
            }
            else
            {
                _unsharedMoney.TotalCashValue += value;
                Console.WriteLine("Cash in  added " + value);
            }
        }

        public void CashOut(double value)
        {
            var money = this.Lookup(value);
            if (IsSharedValue(value) && money.TotalCashValue >= value)
            {
                money.TotalCashValue -= value;
                Console.WriteLine("Cash out  " + value);
            }
            else
            if (_unsharedMoney.TotalCashValue >= value)
            {
                _unsharedMoney.TotalCashValue -= value;
                Console.WriteLine("Cash out " + value);
            }
            else
            {
                Console.WriteLine("Cash out Error");
            }
        }

        public double GetTotalCash()
        {
            double sum = 0.0;
            foreach (KeyValuePair<double, Money> money in _sharedMoneyMap)
            {
                sum += money.Value.TotalCashValue;
            }

            if (_unsharedMoney != null)
            {
                sum += _unsharedMoney.TotalCashValue;
            }
            return sum;
        }

        public abstract Money CreateNewMoney();

        public abstract bool IsSharedValue(double value);
    }
}