using System;
using System.Runtime.CompilerServices;
using System.Threading;
// ReSharper disable All

namespace stuff.Carsss
{ 
    public class ElectricVehicle : Vehicle
    {
        //kw/h
        public readonly float BatteryCapacity;
        public float BatteryCurrentCharge { get; protected set; }
        public float RangePerCharge { get; protected set; }
        public float RangeLeftForCurrentCharge { get; protected set; }
        protected ElectricVehicle(string make, string model, int yearOfManufacture, float weight, float rangePerCharge, float batteryCapacity) 
            : base(make, model, yearOfManufacture, weight)
        {
            RangePerCharge = rangePerCharge;
            RangeLeftForCurrentCharge = RangePerCharge;
            BatteryCapacity = batteryCapacity;
            BatteryCurrentCharge = 100;
        }

        public void CheckBatteryCharge()
        {
            Console.WriteLine($"{Make} {Model}'s battery charge: {BatteryCurrentCharge}%");
        }

        public void ChargeBattery()
        {
            Console.Write("The battery is charging");
            var pos = Console.GetCursorPosition();
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Thread.Sleep(100);
                    Console.Write(".");
                }
                Console.SetCursorPosition(pos.Left, pos.Top);
                for (int j = 0; j < 3; j++)
                {
                    Thread.Sleep(100);
                    Console.Write(" ");
                }
                Console.SetCursorPosition(pos.Left, pos.Top);
            }

            RangeLeftForCurrentCharge = RangePerCharge;
            BatteryCurrentCharge = 100;
            Console.WriteLine($"\nThe {Make} {Model}'s battery is full now");
        }

        public void Ride(float kilometers)
        {
            if (kilometers > RangeLeftForCurrentCharge)
            {
                Console.WriteLine("The distance is too big to go at this battery charge");
            }
            else
            {
                RangeLeftForCurrentCharge -= kilometers;
                BatteryCurrentCharge = (float) Math.Round(Convert.ToDouble(100 - (100 / (RangePerCharge / RangeLeftForCurrentCharge))), 2);
                Console.WriteLine($"You disable autopilot and go for a lonely ride for {kilometers} km. You wasted {100-BatteryCurrentCharge}% of battery's charge for nothing");
            }
        }
        public override void StartEngine()
        {
            Console.WriteLine($"The {Make} model {Model}'s electric engine has started. Finally, reducing air pollution");
        }

        public override void TurnOnRadio(RadioStation station)
        {
            Console.WriteLine($"You turned the {station} on. Now your energy consumption is now x2. +vibe, -work hours.");
            RangePerCharge /= 2;
            RangeLeftForCurrentCharge /= 2;
        }
    }
}