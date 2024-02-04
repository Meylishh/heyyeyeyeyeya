using System;
using System.Threading;
using System.Threading.Tasks;

namespace stuff.IVehicles
{
    public class Car2: IGround
    {
        public float MaxSpeed { get; private set; }

        public Car2(float maxSpeed)
        {
            MaxSpeed = maxSpeed;
        }
        public void Ride()
        {
            Console.WriteLine($"\nThis car has no brakes, so you ride at the {MaxSpeed} speed...");
            Console.Write("You have 15 seconds to write down your last words before you'll crush into a tree:");

            var countdownTask = Countdown();
            var readLastWordsTask = ReadLastWords();

            Task.WhenAny(countdownTask, readLastWordsTask).ContinueWith(t =>
            {
                Console.WriteLine(readLastWordsTask.IsCompleted
                    ? "\nYeah, buddy......... I'll remember that"
                    : "\nSorry buddy, you're out of time. Don't worry, i'll show your message to your mom");
            });
        }

        private Task ReadLastWords()
        {
            return Task.Run(() =>
            {
               Console.ReadLine();
            });
        }

        private Task Countdown()
        {
            return Task.Delay(TimeSpan.FromSeconds(15));
        }
    }
}