using System;
using System.Collections.Generic;

namespace stuff.AutoService
{
    public static class BaseDetails
    {
        public static IReadOnlyList<Detail> DetailsList => detailsList;
        private static List<Detail> detailsList = new List<Detail>()
        {
            new Detail("Engine block", DetailType.EngineAndDrivetrain, Random.Shared.Next(1, 1000)),
            new Detail("Cylinder head", DetailType.EngineAndDrivetrain, Random.Shared.Next(1, 1000)),
            new Detail("Pistons", DetailType.EngineAndDrivetrain, Random.Shared.Next(1, 1000)),
            new Detail("Piston rings", DetailType.EngineAndDrivetrain, Random.Shared.Next(1, 1000)),
            new Detail("Connecting rods", DetailType.EngineAndDrivetrain, Random.Shared.Next(1, 1000)),
            new Detail("Crankshaft", DetailType.EngineAndDrivetrain, Random.Shared.Next(1, 1000)),
            new Detail("Camshaft", DetailType.EngineAndDrivetrain, Random.Shared.Next(1, 1000)),
            new Detail("Timing belt or chain", DetailType.EngineAndDrivetrain, Random.Shared.Next(1, 1000)),
            new Detail("Valves", DetailType.EngineAndDrivetrain, Random.Shared.Next(1, 1000)),
            new Detail("Fuel injection system", DetailType.EngineAndDrivetrain, Random.Shared.Next(1, 1000)),
            
            new Detail("Springs", DetailType.SuspensionAndSteering, Random.Shared.Next(1, 500)),
            new Detail("Shock absorbers", DetailType.SuspensionAndSteering, Random.Shared.Next(1, 500)),
            new Detail("Struts", DetailType.SuspensionAndSteering, Random.Shared.Next(1, 500)),
            new Detail("Control arms", DetailType.SuspensionAndSteering, Random.Shared.Next(1, 500)),
            new Detail("Tie rods", DetailType.SuspensionAndSteering, Random.Shared.Next(1, 500)),
            new Detail("Ball joints", DetailType.SuspensionAndSteering, Random.Shared.Next(1, 500)),
            new Detail("Steering rack", DetailType.SuspensionAndSteering, Random.Shared.Next(1, 500)),
            new Detail("Steering wheel", DetailType.SuspensionAndSteering, Random.Shared.Next(1, 500)),
            new Detail("Power steering pump", DetailType.SuspensionAndSteering, Random.Shared.Next(1, 500)),
            
            new Detail("Brake pads", DetailType.Brakes, Random.Shared.Next(1, 200)),
            new Detail("Brake rotors", DetailType.Brakes, Random.Shared.Next(1, 200)),
            new Detail("Brake calipers", DetailType.Brakes, Random.Shared.Next(1, 200)),
            new Detail("Brake lines", DetailType.Brakes, Random.Shared.Next(1, 200)),
            new Detail("Master cylinder", DetailType.Brakes, Random.Shared.Next(1, 200)),
            new Detail("Brake booster", DetailType.Brakes, Random.Shared.Next(1, 200)),
            
            new Detail("Battery", DetailType.ElectricalSystem, Random.Shared.Next(1, 1500)),
            new Detail("Alternator", DetailType.ElectricalSystem, Random.Shared.Next(1, 1500)),
            new Detail("Starter motor", DetailType.ElectricalSystem, Random.Shared.Next(1, 1500)),
            new Detail("Wiring harness", DetailType.ElectricalSystem, Random.Shared.Next(1, 1500)),
            new Detail("Fuses", DetailType.ElectricalSystem, Random.Shared.Next(1, 1500)),
            new Detail("Relays", DetailType.ElectricalSystem, Random.Shared.Next(1, 1500)),
            new Detail("Lights", DetailType.ElectricalSystem, Random.Shared.Next(1, 1500)),
            new Detail("Horn", DetailType.ElectricalSystem, Random.Shared.Next(1, 1500)),
            
            new Detail("Frame", DetailType.BodyAndInterior, Random.Shared.Next(1, 800)),
            new Detail("Body panels", DetailType.BodyAndInterior, Random.Shared.Next(1, 800)),
            new Detail("Doors", DetailType.BodyAndInterior, Random.Shared.Next(1, 800)),
            new Detail("Windows", DetailType.BodyAndInterior, Random.Shared.Next(1, 800)),
            new Detail("Seats", DetailType.BodyAndInterior, Random.Shared.Next(1, 800)),
            new Detail("Dashboard", DetailType.BodyAndInterior, Random.Shared.Next(1, 800)),
            new Detail("Steering column", DetailType.BodyAndInterior, Random.Shared.Next(1, 800)),
            new Detail("Center console", DetailType.BodyAndInterior, Random.Shared.Next(1, 800)),
            new Detail("Carpet", DetailType.BodyAndInterior, Random.Shared.Next(1, 800)),
            new Detail("Headliner", DetailType.BodyAndInterior, Random.Shared.Next(1, 800)),
            
            new Detail("Tires", DetailType.Other, Random.Shared.Next(1, 240)),
            new Detail("Wheels", DetailType.Other, Random.Shared.Next(1, 240)),
            new Detail("Mirrors", DetailType.Other, Random.Shared.Next(1, 240)),
            new Detail("Wipers", DetailType.Other, Random.Shared.Next(1, 240)),
            new Detail("Air conditioning system", DetailType.Other, Random.Shared.Next(1, 240)),
            new Detail("Heating system", DetailType.Other, Random.Shared.Next(1, 240)),
            new Detail("Fuel tank", DetailType.Other, Random.Shared.Next(1, 240)),
            new Detail("Coolant reservoir", DetailType.Other, Random.Shared.Next(1, 240)),
            new Detail("Oil filter", DetailType.Other, Random.Shared.Next(1, 240)),
            new Detail("Air filter", DetailType.Other, Random.Shared.Next(1, 240)),
        };
    }
    public class Detail
    {
        public readonly string Name;
        public readonly DetailType DetailType;
        public int Price { get; private set; }
        
        public Detail(string name, DetailType type, int price)
        {
            Name = name;
            DetailType = type;
            Price = price;
        }
    }
    
    public enum DetailType
    {
        EngineAndDrivetrain,
        SuspensionAndSteering,
        Brakes,
        ElectricalSystem,
        BodyAndInterior, 
        Other
    }
}