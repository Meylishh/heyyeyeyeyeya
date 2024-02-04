using System;
using System.Collections.Generic;
using System.Linq;
using stuff.Carsss;

namespace stuff.Supermarket
{
    // Написать программу администрирования супермаркетом.
// В супермаркете есть очередь клиентов.
// У каждого клиента в корзине есть товары, также у клиентов есть деньги.
// Клиент, когда подходит на кассу, получает итоговую сумму покупки и
// старается её оплатить.
// Если оплатить клиент не может, то он рандомный товар из корзины
// выкидывает до тех пор, пока его денег не хватит для оплаты.
// Клиентов можно делать ограниченное число на старте программы.

    public class SupermarketManager
    {
        private Queue<Client> queue;
        public SupermarketManager()
        {
            queue = new Queue<Client>();
        }
        public SupermarketManager(Queue<Client> queue)
        {
            this.queue = queue;
        }

        public void StartTakingClients()
        {
            if (queue.Any())
            {
                while (queue.Count > 0)
                {
                    var client = queue.Peek();
                    Console.WriteLine($"{client.Name} has {client.Money}$ and their cart is {client.Cart.CartPrice}$");
                    if (client.Money < client.Cart.CartPrice)
                    {
                        while (client.Money < client.Cart.CartPrice)
                        {
                            Console.WriteLine("The client's money isn't enough. ");
                            client.Cart.RemoveRandomItem();
                        }
                    }
                    
                    client.Buy(client.Cart.CartPrice);
                    Console.WriteLine($"{client.Name} paid for all his goods and has {client.Money} left");
                    queue.Dequeue();
                }
            }
        }
        
        public void DisplayClientsInfo()
        {
            foreach (var client in queue)
            {
                Console.WriteLine($"Name: {client.Name}, money: {client.Money}");
            }
        }

        public static Queue<Client> GenerateClientsQueue(int clientsCount)
        {
            var queue = new Queue<Client>();
            if (clientsCount > 0)
            {
                for (int i = 0; i < clientsCount; i++)
                {
                    var info = GenerateClientInfo();
                    queue.Enqueue(new Client((string)info[0], (float)info[1]));
                }
            }
            return queue;
        }

        private static object[] GenerateClientInfo()
        {
            const string alphabet = "abcdefghijklmnopqrstuvwxyz";
            var name = new string(Enumerable.Repeat(alphabet, 6)
                .Select(s => s[Random.Shared.Next(s.Length)]).ToArray());
            float money = Random.Shared.Next(50000);
            
            return new object[]{name, money};
        }
    }
}