using System;

namespace stuff.CharacteristicImprovement
{
    public class PlayerEquipment
    {
        private BaseEquippableItem baseEquippableItem;
        private readonly Player player;
        private readonly int playerBaseAttack;
        private readonly int playerBaseArmor;
        
        public PlayerEquipment(Player player)
        {
            this.player = player;
            playerBaseAttack = player.Attack;
            playerBaseArmor = player.Armor;
            
            baseEquippableItem = new BaseEquippableItem(player, "baseItem");
        }

        public void AddNewItem(BaseEquippableItem equippableItem)
        {
            baseEquippableItem.AddItem(equippableItem);
            Console.WriteLine($"{equippableItem.ItemName} item was added to equipment");
            
            RecalculateStats();
        }
        public void AddNewItem(params BaseEquippableItem[] equippableItems)
        {
            foreach (var equippableItem in equippableItems)
            {
                baseEquippableItem.AddItem(equippableItem);
                Console.WriteLine($"{equippableItem.ItemName} item was added to equipment");
            }
            RecalculateStats();
        }
        
        public void EnableItem(BaseEquippableItem item)
        {
            if (!item.isActive)
            {
                item.isActive = true;
                RecalculateStats();
            }
            else
            {
                Console.WriteLine("Item is already enabled");
            }

        }
        public void DisableItem(BaseEquippableItem equippableItem)
        {
            if (equippableItem.isActive)
            {
                equippableItem.isActive = false;
                RecalculateStats();
            }
            else
            {
                Console.WriteLine("Item is already disabled");
            }
        }

        public void DisplayStatsInfo() =>
            Console.WriteLine($"Current player stats:\natk: {player.Attack}; def: {player.Armor}");

        public void ClearAllEquipment()
        {
            player.Attack = playerBaseAttack;
            player.Armor = playerBaseArmor;
            baseEquippableItem = new BaseEquippableItem(player, "baseItem");
            Console.WriteLine("Player equipment is now empty");
        }
        private void RecalculateStats()
        {
            player.Attack = playerBaseAttack;
            player.Armor = playerBaseArmor;
            baseEquippableItem.Equip();
            Console.WriteLine($"Current player stats:\natk: {player.Attack}; def: {player.Armor}");
        }
    }
}