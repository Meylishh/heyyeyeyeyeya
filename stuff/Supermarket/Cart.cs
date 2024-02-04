using System;
using System.Collections.Generic;
using System.Linq;
using stuff.Carsss;

namespace stuff.Supermarket
{
    public class Cart
    {
        private static Random random;
        private List<Item> items;
        
        private float cartPrice;
        public float CartPrice
        {
            get
            {
                return cartPrice;
            }
            private set
            {
                cartPrice = value;
            }
        }
        public Cart(bool fillWithRandomItems = true)
        {
            random = new Random();
            CartPrice = 0;

            items = new List<Item>();
            if (fillWithRandomItems)
            {
                AddRandomItemsToCart();
            }
        }

        private void SetFirstCartPrice(List<Item> cart)
        {
            foreach (var item in cart)
            {
                CartPrice += item.Price;
            }
        }

        public void ShowCart()
        {
            if (items.Any())
            {
                foreach (var item in items)
                {
                    Console.WriteLine($"{item.Amount} {item.Name} for {item.Price}");
                }
            }
            else
            {
                Console.WriteLine("The cart is empty");
            }
        }

        public void RemoveRandomItem()
        {
            if (items.Any())
            {
                var itemToRemove = items[random.Next(0, items.Count - 1)];
                CartPrice -= itemToRemove.Price;
                items.Remove(itemToRemove);
                Console.WriteLine($"{itemToRemove.Amount} {itemToRemove.Name} for {itemToRemove.Price} was removed from the cart");
            }
        }

        public void AddRandomItemsToCart()
        {
            int amountOfItems = random.Next(1, 21);
            for (int i = 0; i < amountOfItems; i++)
            {
                var type = GenerateProductType();
                items.Add(new Item(type, GenerateName(type), GeneratePrice(), random.Next(1, 31)));
            }
            SetFirstCartPrice(items);
        }

        private Product GenerateProductType()
        {
            var randomEnumIndex = random.Next(typeof(Product).GetEnumValues().Length);
            return (Product) randomEnumIndex;
        }

        private float GeneratePrice()
        {
            var integer = random.Next(10, 100);
            var afterDecimal = Math.Round((float)random.NextDouble(), 2);
            return integer + (float)afterDecimal;
        }
        
        private string GenerateName(Product product)
        {
            var randomBrands = new List<string>()
            {
                "Coca-Cola",
                "Pepsi",
                "KFC",
                "McDonald's",
                "Starbucks",
                "Pizza Hut",
                "Dominos",
                "Burger King",
                "Taco Bell",
                "Subway",
                "Honda",
                "Toyota",
                "BMW",
                "Mercedes-Benz",
                "Audi",
                "Tesla",
                "Apple",
                "Google",
                "Samsung",
                "Microsoft",
                "Nike",
                "Adidas",
                "Under Armour",
                "New Balance",
                "Converse",
                "Vans",
                "Doc Martens",
                "Ralph Lauren",
                "Gucci",
                "Louis Vuitton"
            };
            
            var randomNameIndex = random.Next(randomBrands.Count);
            var name = $"{product} by {randomBrands[randomNameIndex]}";
            return name;
        }
    }
}