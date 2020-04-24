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
            new Pill("Paracetamol",100,100)
            {
              
            },
            new Pill("Ibuprofen",150,200)
            {
                
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
            for (int pill=0;pill<Pills.Count;pill++)
            {
                
                builder.Append((pill+1).ToString()+". "+Pills[pill]+"\n");
            }

            return builder.ToString();
        }
    }
}