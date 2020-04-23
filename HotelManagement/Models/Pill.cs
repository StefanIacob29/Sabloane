namespace HospitalManagement.Models
{
    public class Pill
    {
        public Pill(string pillName,int quantity, int price)
        {
            this.Name = pillName;
            this.Quantity = quantity;
            this.Price= price;
        }

        public string Name { get; set; }

        public int Quantity { get; set; }

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
