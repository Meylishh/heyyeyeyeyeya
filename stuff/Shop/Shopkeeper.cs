using System;
using System.Collections.Generic;
using System.Linq;

namespace stuff
{
    // Существует продавец, он имеет у себя список товаров, и при нужде,
    // может вам его показать, также продавец может продать вам товар. После
    // продажи товар переходит к вам, и вы можете также посмотреть свои
    // вещи.
    // Возможные классы – игрок, продавец, товар.
    // Вы можете сделать так, как вы видите это.
    
    public class Shopkeeper
    {
        private Dictionary<string, Item> items = new Dictionary<string, Item>();

        public Shopkeeper(List<Item> items)
        {
            for (int i = 0; i < items.Count; i++)
            {
                this.items.Add(items[i].Name,items[i]);
            }
        }
        
        public bool CanSellItem(string name, out Item item)
        {
            item = null;
            if (items.ContainsKey(name))
            {
                item = items[name];
                return true;
            }
            return false;
        }

        public void SellItem(Item item)
        {
            items.Remove(item.Name);
        }
        public void ShowAllItems()
        {
            if (items.Any())
            {
                Console.WriteLine("Sure, watch my items all you want: ");
                foreach (var item in items.Values)
                {
                    Console.WriteLine($"{item.Name} - {item.Price} leaves");
                }
            }
            else
            {
                Console.WriteLine("Sorry, wanderer, i have nothing to offer you");
            }
        }
    }
}