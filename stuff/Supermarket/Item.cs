namespace stuff.Supermarket
{
    public class Item
    {
        public readonly string Name;
        public readonly Product Product;
        public readonly int CodeId;
        public float Price { get; private set; }
        public float Amount { get; private set; }

        public Item(Product product, string name, float price, int amount = 1)
        {
            Name = name;
            Amount = amount;
            Product = product;
            CodeId = GetHashCode();
            Price = price * amount;
        }
    }

    public enum Product
    {
        Milk,
        Bread,
        Eggs,
        Rice,
        Pasta,
        Chicken,
        Beef,
        Fish,
        Apples,
        Bananas,
        Oranges,
        Tomatoes,
        Potatoes,
        Carrots,
        Onions,
        Lettuce,
        Cucumbers,
        Yogurt,
        Cheese,
        Butter,
        Cereal,
        Juice,
        Soda,
        Snacks,
        IceCream,
        FrozenVegetables,
        CannedSoup,
        PastaSauce,
        CookingOil
    }
}