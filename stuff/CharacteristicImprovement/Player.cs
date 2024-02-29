using System.Collections.Generic;

namespace stuff.CharacteristicImprovement
{
    public class Player
    { 
        public int Attack { get; set; } = 10;
        public int Armor { get; set; } = 10;

        public readonly PlayerEquipment Equipment;

        public Player()
        {
            Equipment = new PlayerEquipment(this);
        }
    }
    
}