using System.Collections.Generic;

namespace HospitalManagement.Models
{
    public class TreatmentModel
    {
        public string TreatmentName { get; set; }
        public List<Pill> Pills { get; set; }
    }
}
