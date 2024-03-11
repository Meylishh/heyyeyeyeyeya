using System;
using System.Collections.Generic;
using System.Linq;

namespace stuff.AutoService
{
    public class Warehouse
    {
        public IReadOnlyList<Detail> WarehouseDetails => warehouse;
        private List<Detail> warehouse = new();

        public Warehouse()
        {
            FillWarehouse(5);
        }
        
        public void FillWarehouse(int amountPerDetail)
        {
            foreach (var detail in BaseDetails.DetailsList)
            {
                for (int i = 0; i < amountPerDetail; i++)
                {
                    warehouse.Add(detail);
                }
            }
        }
        
        public bool CheckIfDetailAvailable(Detail detail)
        {
            if (warehouse.Any(d => d.Equals(detail)))
            {
                Console.WriteLine("Warehouse contains such detail");
                return true;
            }
            Console.WriteLine("Warehouse does not contain such detail");
            return false;
        }
    }
}