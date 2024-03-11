using System;
using System.Collections.Generic;
using System.Linq;

namespace stuff.AutoService
{
    public class Car
    {
        public readonly string Name;
        public IReadOnlyList<Detail> BrokenDetails => brokenDetails;
        private List<Detail> brokenDetails;

        public Car(string name, int maxBrokenDetailAmount)
        {
            Name = name;
            brokenDetails = GenerateDetails(maxBrokenDetailAmount);
        }
        

        public Car(params Detail[] brokenDetails)
        {
            this.brokenDetails = brokenDetails.ToList();
        }
        private List<Detail> GenerateDetails(int maxAmount)
        {
            var newBrokenDetails = new List<Detail>();

            for (int i = 0; i < maxAmount; i++)
            {
                var detail = BaseDetails.DetailsList[Random.Shared.Next(0, BaseDetails.DetailsList.Count)];
                newBrokenDetails.Add(detail);
            }

            return newBrokenDetails;
        }
    }
    
}