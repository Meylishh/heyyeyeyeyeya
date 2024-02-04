using System;
// ReSharper disable All

namespace stuff.Carsss
{
    public abstract class Vehicle
    {
        public readonly int YearOfManufacture;
        public readonly string Make;
        public readonly string Model;
        public readonly float Weight;

        protected Vehicle(string make, string model, int yearOfManufacture, float weight)
        {
            Make = make;
            Model = model;
            YearOfManufacture = yearOfManufacture;
            Weight = weight;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"The {Make} car, model {Model}. Year of manufacture: {YearOfManufacture}, weight: {Weight}.");
        }
        
        public void DisplayInfo(string additionalInfo)
        {
            Console.WriteLine($"The {Make} car, model {Model}. Year of manufacture: {YearOfManufacture}, weight: {Weight}. {additionalInfo}");
        }

        public virtual void StartEngine()
        { 
            Console.WriteLine("The engine has started...");   
        }

        public abstract void TurnOnRadio(RadioStation station);
    }
}