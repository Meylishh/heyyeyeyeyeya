using System;
using System.Threading;
using stuff.Supermarket;
// ReSharper disable All

namespace stuff.IVehicles
{
    public class Amphibius: IWaterborne, IFlying
    {
        private readonly float maxSpeedFly; 
        public float MaxSpeed { get; private set; }
        
        private float currentSpeed;

        private bool isFlying;
        private bool IsFlying
        {
            get => isFlying;
            set
            {
                isFlying = value;
                if (value)
                {
                    if (IsSailing)
                    {
                        IsSailing = false;
                    }
                    MaxSpeed = maxSpeedFly;
                }
            }
        }
        
        private bool isSailing;
        private bool IsSailing
        {
            get => isSailing;
            set
            {
                isSailing = value;
                if (value)
                {
                    if (IsFlying)
                    {
                        IsFlying = false;
                    }
                    MaxSpeed = maxSpeedFly / 10;
                }
            }
        }

        public Amphibius(float maxSpeedFly)
        {
            this.maxSpeedFly = maxSpeedFly;
            MaxSpeed = maxSpeedFly;
            currentSpeed = maxSpeedFly / 2;
        }

        private void ControlSpeed(AmphibiusTravelMode travelMode)
        {
            var coord = Console.GetCursorPosition();
            var endXPos = coord.Left;
            Console.Write($"The amphibius starts to {travelMode.ToString().ToLower()} at {currentSpeed} speed");
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey(true);
                    
                    if (key.Key is ConsoleKey.W or ConsoleKey.S)
                    {
                        for (int i = endXPos; i >= coord.Left; i--)
                        {
                            Console.SetCursorPosition(i, coord.Top);
                            Console.Write(" ");
                        }
                    }
                    
                    switch (key.Key)
                    {
                        case ConsoleKey.W:
                            if (currentSpeed < MaxSpeed)
                            {
                                currentSpeed++;
                            }
                            Console.SetCursorPosition(coord.Left, coord.Top);
                            Console.Write($"The amphibius starts to {travelMode.ToString().ToLower()} at {currentSpeed} speed");
                            break;
                        case ConsoleKey.S:
                            if (currentSpeed > 0)
                            {
                                currentSpeed--;
                            }
                            Console.SetCursorPosition(coord.Left, coord.Top);
                            Console.Write($"The amphibius starts to {travelMode.ToString().ToLower()} at {currentSpeed} speed");
                            break;
                        case ConsoleKey.Q:
                            Console.WriteLine("\nThe amphibius has stopped");
                            if (travelMode == AmphibiusTravelMode.Fly)
                            {
                                IsFlying = false;
                            }
                            else
                            {
                                IsSailing = false;
                            }
                            currentSpeed = 0;
                            return;
                    }
                    endXPos = Console.CursorLeft;
                }
            }
        }
        public void Fly()
        {
            IsFlying = true;
            ControlSpeed(AmphibiusTravelMode.Fly);
        }

        public void Sail()
        {
            IsSailing = true;
            ControlSpeed(AmphibiusTravelMode.Sail);
        }
        
        private enum AmphibiusTravelMode
        {
            Fly,
            Sail
        }
    }
}