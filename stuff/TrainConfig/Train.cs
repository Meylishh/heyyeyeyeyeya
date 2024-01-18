using System.Collections.Generic;

namespace stuff
{
    public class Train 
    {
        private readonly Route Route;
        private readonly List<Wagons> Wagons;
        public readonly string Name;
        public Train(Route route, List<Wagons> wagons)
        {
            Route = route;
            Wagons = wagons;
            Name = route.Name;
        }
    }
    
    public enum Wagons
    {
        BigWagon = 100,
        MediumWagon = 60,
        SmallWagon = 30
    }
}