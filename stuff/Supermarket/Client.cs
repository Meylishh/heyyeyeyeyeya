using System.Collections.Generic;

namespace stuff.Supermarket
{
    public class Client
    {
        public readonly string Name;
        public float Money { get; private set; }
        public readonly Cart Cart;

        public Client(string name, float money, bool cartIsRandom = true)
        {
            Name = name;
            Money = money;
            if (!cartIsRandom)
            {
                Cart = new Cart(false);
            }
            else
            {
                Cart = new Cart();   
            }
        }

        public void Buy(float price)
        {
            Money -= price;
        }
    }
}