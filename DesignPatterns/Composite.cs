namespace CompositeDP
{
    public interface IPriceable
    {
        public double GetPrice();
    }
    public class Product : IPriceable
    {
        private string name;
        private double price;
        public Product(string name, double price)
        {
            this.name = name;
            this.price = price;
        }
        public double GetPrice()
        {
            return this.price;
        }
        public string GetName()
        {
            return this.name;
        }
    }
    public class Packet : IPriceable
    {
        private List<IPriceable> childList;
        private string name;
        public Packet(string name)
        {
            this.name = name;
            this.childList = new List<IPriceable>();
        }
        public string GetName()
        {
            return this.name;
        }
        public double GetPrice()
        {
            double res = 0;
            foreach(IPriceable priceable in childList)
            {
                res += priceable.GetPrice();
            }
            return res;
        }
        public void AddProduct(IPriceable priceable)
        {
            this.childList.Add(priceable);
        }
        public void RemoveProduct(IPriceable priceable)
        {
            this.childList.Remove(priceable);
        }
    }
}