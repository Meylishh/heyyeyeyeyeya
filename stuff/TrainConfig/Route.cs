namespace stuff
{
    public class Route
    {
        public readonly City From;
        public readonly City To;
        public readonly string Name;

        public Route(City from, City to)
        {
            From = from;
            To = to;
            Name = $"{from} - {to}";
        }
    }
    public enum City 
    { 
        Moscow,
        Vladivostok,
        Saratov,
        Voronezh,
        Sochi,
        MagicCity
    }
}