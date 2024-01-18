using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace stuff
{
    /*У вас есть программа, которая помогает пользователю составить план поезда.
            Есть 4 основных шага в создании плана:
            -Создать направление - создает направление для поезда(к примеру Бийск - Барнаул)
            -Продать билеты - вы получаете рандомное кол-во пассажиров, которые купили билеты на это направление
            -Сформировать поезд - вы создаете поезд и добавляете ему столько вагонов
            (вагоны могут быть разные по вместительности), сколько хватит для перевозки всех пассажиров.
            -Отправить поезд - вы отправляете поезд, после чего можете снова создать направление.
            В верхней части программы должна выводиться полная информация отекущем рейсе или его отсутствии.*/
    
    public static class TrainRouteConfigurator
    {
        public static Dictionary<string, Train> Routes = new Dictionary<string, Train>();
        private static Random random;
        public static Route CreateRoute()
        {
            Console.WriteLine("Write a route for a train (example: Moscow - Vladivostok)");
            var input = Console.ReadLine();
            try
            {
                input = input.Replace(" ", string.Empty);
                var dividedInput = input.Split('-');
                if (Enum.TryParse(dividedInput[1], out City toCity) &&
                    Enum.TryParse(dividedInput[0], out City fromCity))
                {
                    return new Route(fromCity, toCity);
                }
                
            }
            catch
            {
                Console.WriteLine("Wrong route");
            }
            return null;
        }

        public static int SellTickets(Route route)
        {
            random = new Random();
            var passengers = random.Next(25, 1001);
            Console.WriteLine($"{passengers} tickets were sold for the {route.Name} route");
            return passengers;
        }

        public static Train CreateTrain(Route route, int ticketsSold)
        {
            if (ticketsSold >= 25)
            {
                var wagons = new List<Wagons>();
                var bigCapacity = (int) Wagons.BigWagon;
                var mediumCapacity = (int) Wagons.MediumWagon;
                var smallCapacity = (int) Wagons.SmallWagon;
            
                int bigWagons = ticketsSold / bigCapacity;
                int remainingPassengers = ticketsSold % bigCapacity;

                int mediumWagons = remainingPassengers / mediumCapacity;
                remainingPassengers %= mediumCapacity;

                int smallWagons = (int)Math.Ceiling((double)remainingPassengers / smallCapacity);

                // Ensure there are no extra medium wagons, if small wagons can be used more optimally
                if (smallWagons == 2 && smallCapacity > remainingPassengers)
                {
                    // It may be more optimal to use an extra medium wagon instead of two small ones
                    if((mediumCapacity - remainingPassengers % mediumCapacity) <
                       (2 * smallCapacity - remainingPassengers))
                    {
                        mediumWagons++;
                        smallWagons = 0;
                    }
                }

                //int[] wagonsAmounts = new[] {bigWagons, mediumWagons, smallWagons};
                var wagonsAmounts = new Dictionary<Wagons, int>
                {
                    {Wagons.BigWagon, bigWagons}, 
                    {Wagons.MediumWagon, mediumWagons},
                    {Wagons.SmallWagon, smallWagons}
                };
                foreach (var wagonSize in wagonsAmounts.Keys)
                {
                    if (wagonsAmounts[wagonSize] != 0)
                    {
                        for (int i = 0; i < wagonsAmounts[wagonSize]; i++)
                        {
                            wagons.Add(wagonSize);
                        }
                    }
                } 
                return new Train(route, wagons);
            }
            Console.WriteLine("Wrong amount of tickets");
            return null;
        }

        public static void LaunchTrain(Train train)
        {
            Routes.Add(train.Name, train);
            Console.WriteLine($"The train {train.Name} was launched");
        }

        public static void ShowCurrentTrain()
        {
            if (Routes.Any())
            {
                var currentTrain = Routes.Values.Last();
                Console.WriteLine($"Current launched train: {currentTrain.Name}");
            }
            else
            {
                Console.WriteLine("No trains are launched");
            }
        }
    }
    
    
}