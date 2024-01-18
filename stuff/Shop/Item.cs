namespace stuff
{
    public class Item
    {
        public readonly string Name;
        public readonly int Price;
        public readonly string Description;

        public Item(string name, int price, string description)
        {
            Name = name;
            Price = price;
            Description = description;
            
        }
    }
}