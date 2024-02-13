using System;
using System.Threading;
using System.Threading.Tasks;
using stuff.Carsss;

namespace stuff.IVehicles
{
    public class Submarine: IUnderwater
    {
        public float MaxSpeed { get; }
        private float currentSpeed;
        public bool IsUnderWater { get; set; }
        
        public Submarine(float maxSpeed)
        {
            MaxSpeed = maxSpeed;
            currentSpeed = maxSpeed/2;
        }

        public void Sail()
        {
            var coord = Console.GetCursorPosition();
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey(true);
                    if (key.Key == ConsoleKey.Q)
                    {
                        currentSpeed = 0;
                        Console.WriteLine("\nThe submarine has stopped");
                        break;
                    }
                }
                else
                {
                    for (int i = Console.CursorLeft; i >= coord.Left; i--)
                    {
                        Console.SetCursorPosition(i, coord.Top);
                        Console.Write(" ");
                    }
                
                    Console.SetCursorPosition(coord.Left, coord.Top);
                }
                
                if (currentSpeed < MaxSpeed && currentSpeed > 0)
                {
                    currentSpeed += Random.Shared.Next(-20, 21);
                    if (currentSpeed > MaxSpeed)
                    {
                        currentSpeed = MaxSpeed;
                    }
                    else if (currentSpeed < 0)
                    {
                        currentSpeed = 0;
                    }
                }
                else
                {
                    if (currentSpeed == 0)
                    {
                        currentSpeed += Random.Shared.Next(21);
                    }
                    else if (currentSpeed == MaxSpeed)
                    {
                        currentSpeed += Random.Shared.Next(-20, 1);
                    }
                }
                
                Console.Write(IsUnderWater
                    ? $"The submarine is sailing underwater at the {currentSpeed} speed"
                    : $"The submarine is sailing like an ordinary boat on the water at the {currentSpeed} speed");
                Thread.Sleep(30);
                
            }
        }
    }
}