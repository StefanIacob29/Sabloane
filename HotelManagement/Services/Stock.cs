using System.Collections.Generic;
using System.Text;
using HospitalManagement.Models;

namespace HospitalManagement.Services
{
    public class Stock
    {
        private static Stock instance;
        private static readonly object padlock = new object();

        private Stock()
        {
        }

        public List<Pill> Pills { get; set; } = new List<Pill>
        {
            new Pill
            {
                Name = "Paracetamol",
                Price = 100,
                Quantity = "100"
            },
            new Pill
            {
                Name = "Ibuprofen",
                Price = 200,
                Quantity = "150"
            }
        };

        public static Stock GetStock()
        {
            lock (padlock)
            {
                if (instance == null)
                {
                    instance = new Stock();
                }
                return instance;
            }
        }

        public void AddPillInStock(Pill pill)
        {
            Pills.Add(pill);
        }

        public void RemovePillFromStock(Pill pill)
        {
            if (Pills.Contains(pill)) Pills.Remove(pill);
        }

        public string ShowPillStock()
        {
            StringBuilder builder = new StringBuilder();
            foreach (var pill in Pills)
            {
                builder.Append(pill);
            }

            return builder.ToString();
        }
    }
}