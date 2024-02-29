using System;
using System.Threading;
using System.Threading.Tasks;

namespace stuff.IVehicles
{
    public class Car: IGround
    {
        public float MaxSpeed { get; private set; }

        public Car(float maxSpeed)
        {
            MaxSpeed = maxSpeed;
        }
        public void Ride()
        {
            Console.WriteLine($"\nThis car has no breaks, so you ride at the {MaxSpeed} speed...");
            Console.Write("You have 15 seconds to write down your last words before you'll crash into a tree: ");

            var readLastWordsTask = ReadLastWords();
            var countdownTask = Countdown();

            Task.WaitAny(readLastWordsTask, countdownTask);

            Console.WriteLine(readLastWordsTask.IsCompleted
                ? "\nYeah, Buddy......... I'll remember that"
                : "\nSorry Buddy, you're out of time. Don't worry, I'll show your message to your mom");
            
            Environment.Exit(0);
        }

        private static Task ReadLastWords()
        {
            return Task.Run(() =>
            {
               Console.ReadLine();
            });
        }

        private static Task Countdown()
        {
            return Task.Delay(TimeSpan.FromSeconds(15));
        }
    }
}