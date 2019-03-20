namespace ClassLibraryDemoStrongName
{
    public class Product
    {
        public int Id { get; set; }
        public int Price { get; set; }
        public string Name { get; set; }

        public Product(int price, string name)
        {
            Price = price;
            Name = name;
        }

        public override string ToString()
        {
            return string.Format("{0} - {1}$", Name, Price);
        }
    }
}
