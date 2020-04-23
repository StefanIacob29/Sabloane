namespace HospitalManagement.Models
{
    public class Pill
    {
        private string pillName;
        private int v;

        public Pill(string pillName, int v)
        {
            this.pillName = pillName;
            this.v = v;
        }

        public string Name { get; set; }

        public string Quantity { get; set; }

        public double Price { get; set; }

        public override bool Equals(object obj)
        {
            Pill pill = obj as Pill;

            if (pill == null)
            {
                return false;
            }

            return Name == pill.Name &&
                   Price == pill.Price &&
                   Quantity == pill.Quantity;
        }

        public override string ToString()
        {
            return $"Name: {Name} Quantity: {Quantity} Price: {Price}";
        }
    }
}
