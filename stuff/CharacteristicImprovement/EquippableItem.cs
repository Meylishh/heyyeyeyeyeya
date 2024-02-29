using System;
using System.Collections.Generic;
using stuff.Carsss;

namespace stuff.CharacteristicImprovement
{
    public class BaseEquippableItem
    {
        public bool isActive { get; set; } = true;
        public readonly string ItemName;
        
        protected readonly Player player;
        private BaseEquippableItem nextItem;
        public BaseEquippableItem(Player player, string itemName)
        {
            this.player = player;
            ItemName = itemName;
        }

        protected virtual void Activate() { }

        public void AddItem(BaseEquippableItem equippableItem)
        {
            if (nextItem != null)
            {
                nextItem.AddItem(equippableItem);
            }
            else
            {
                nextItem = equippableItem;
            }
        }

        public void Equip()
        {
            if (isActive)
            {
                Activate();
            }
            else
            {
                Console.WriteLine($"{ItemName} item is inactive");
            }
            nextItem?.Equip();
        }
    }

    public class Weapon : BaseEquippableItem
    {
        public readonly int IncreaseAttack;
        public Weapon(Player player, string weaponName, int increaseAttack) : base(player, weaponName)
        {
            IncreaseAttack = increaseAttack;
        }

        protected override void Activate()
        {
            player.Attack += IncreaseAttack;
            Console.WriteLine($"plr attack +{IncreaseAttack}");
        }
    }

    public class Armor : BaseEquippableItem
    {
        public readonly int IncreaseArmor;
        public Armor(Player player, string armorName, int increaseArmor) : base(player, armorName)
        {
            IncreaseArmor = increaseArmor;
        }

        protected override void Activate()
        {
            player.Armor += IncreaseArmor;
            Console.WriteLine($"plr armor +{IncreaseArmor}");
        }
    }
}