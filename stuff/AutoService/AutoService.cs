using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading;

namespace stuff.AutoService
{
    /*У вас есть автосервис, в который приезжают люди, чтобы починить свои
    автомобили.
    У вашего автосервиса есть баланс денег и склад деталей.
    Когда приезжает автомобиль, у него сразу ясна его поломка, и эта
    поломка отображается у вас в консоли вместе с ценой за починку(цена за
    починку складывается из цены детали + цена за работу).
    Поломка всегда чинится заменой детали, но количество деталей
    ограничено тем, что находится на вашем складе деталей.
    Если у вас нет нужной детали на складе, то вы можете отказать клиенту,
    и в этом случае вам придется выплатить штраф.
    Если вы замените не ту деталь, то вам придется возместить ущерб
    клиенту.
    За каждую удачную починку вы получаете выплату за ремонт, которая
    указана в чек-листе починки.
    Класс Деталь не может содержать значение “количество”. Деталь всего
    одна, за количество отвечает тот, кто хранит детали. При необходимости
    можно создать дополнительный класс для конкретной детали и работе с
    количеством.*/
    
    public class AutoService
    {
        public int Balance { get; set; }
        private readonly int priceForReplacement;
        public Warehouse Warehouse;
        public AutoService(int priceForReplacement)
        {
            Balance = 1000000;
            this.priceForReplacement = priceForReplacement;
            Warehouse = new Warehouse();
        }

        public void ServeClient(Car client)
        {
            Console.WriteLine($"{client.Name} came to your auto service with {client.BrokenDetails.Count} broken details and hopes for you to help them!");
            Console.WriteLine("Receipt for all the work: ");
            RepairCar(client, ChooseDetailsToRepairWith(client));
        }
        private bool DetailValidation(string input, out Detail detailToUse)
        {
            detailToUse = null;
            try
            {
                var splitName = input.Split(", ");
                if (splitName.Length > 2)
                {
                    Console.WriteLine("Couldn't find such detail in the warehouse");
                    return false;
                }
                
                var enumVal = (DetailType)Enum.Parse(typeof(DetailType), splitName[1]);
                foreach (var detail in Warehouse.WarehouseDetails)
                {
                    if (detail.Name == splitName[0] && detail.DetailType == enumVal)
                    {
                        Console.WriteLine($"You found the {splitName[0]} detail in the warehouse and use it");
                        detailToUse = detail;
                        return true;
                    }
                }
            }
            catch
            {
                Console.WriteLine("Couldn't find such detail in the warehouse");
                return false;
            }
            Console.WriteLine("Couldn't find such detail in the warehouse");
            return false;
        }
        
        
        public List<Detail> ChooseDetailsToRepairWith(Car client)
        {
            var brokenDetails = client.BrokenDetails;
            var detailsToRepairWith = new List<Detail>();
            
            foreach (var detail in client.BrokenDetails)
            {
                Console.WriteLine($"The {detail.Name.ToLower()} is broken. Choose an option:" +
                                  $"\n1. Check such detail in warehouse" +
                                  $"\n2. Replace with new detail" +
                                  $"\n3. Refuse a customer");
                var repaired = false;
                while (!repaired)
                {
                    if (Console.KeyAvailable)
                    {
                        var key = Console.ReadKey(true).Key;

                        switch (key)
                        {
                            case ConsoleKey.D1:
                                Warehouse.CheckIfDetailAvailable(detail);
                                break;
                            case ConsoleKey.D2:
                                Console.WriteLine("What detail do you want to use? Write name and type as \"Name, Type\"");
                                var input = Console.ReadLine();
                                if (DetailValidation(input, out Detail detailToUse))
                                {
                                    detailsToRepairWith.Add(detailToUse);
                                    repaired = true;
                                }
                                break;
                            case ConsoleKey.D3:
                                Console.WriteLine("You refused a customer");
                                return null;
                        }
                    }
                    Thread.Sleep(10);
                }
            }

            return detailsToRepairWith;
        }

        public void RepairCar(Car client, List<Detail> detailsToRepairWith)
        {
            if (detailsToRepairWith == null)
            {
                return;
            }
            
            var brokenDetails = client.BrokenDetails;
            bool success = true;
            for (int i = 0; i < brokenDetails.Count; i++)
            {
                if (brokenDetails[i].Equals(detailsToRepairWith[i]))
                {
                    Console.WriteLine("You successfully repaired the broken detail");
                }
                else
                {
                    Console.WriteLine("You repaired the wrong detail! Now you'll have to pay for the damage");
                    DamagePayment(brokenDetails[i]);
                    Console.WriteLine("Your client left disappointed...");
                    success = false;
                    break;
                }
            }
            if (success)
            {
                Balance += CountRepairPrice(brokenDetails.ToList());
                Console.WriteLine($"Congrats! You've earned {CountRepairPrice(brokenDetails.ToList())}$ and your balance now is {Balance}");
            }
        }

        private void DamagePayment(Detail harmedDetail)
        {
            Balance -= harmedDetail.Price + priceForReplacement + 100;
            if (Balance < 0)
            {
                Console.WriteLine("Oops! Your auto service went bankrupt...");
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine($"You paid for the damage and you balance now is {Balance}");
            }
        }
        public int CountRepairPrice(List<Detail> brokenDetails)
        {
            var price = 0;
            foreach (var detail in brokenDetails)
            {
                price += detail.Price + priceForReplacement;
            }
            return price;
        }
    }
}