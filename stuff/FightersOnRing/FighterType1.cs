using System;
using System.Collections;

namespace stuff
{
    public class FighterType1 : Fighter
    {
        //healer - lot of health, little dmg, normal armor, heals after being hit but takes a little mana for it 
        //mana restores for 5 each time fighter deals dmg
        
        private int _mana;
        private int Mana
        {
            get => _mana;
            set => _mana = value > 100 ? 100 : value;
        }
        
        public FighterType1()
        {
            Name = "Cutie Heaven Healer Dario";
            MaxHealth = 120;
            Health = MaxHealth;
            Attack = 15;
            Armor = 35;
            Mana = 100;
        }

        public override void DealDamage(Fighter fighter)
        {
            base.DealDamage(fighter);
            Console.WriteLine($"{Name} really doesn't want to do this, but attacks {fighter.Name} for {Attack}");
            Mana += 5;
        }

        public override void GetDamage(int damage)
        {
            base.GetDamage(damage);
            Console.WriteLine($"Oh no, {Name} was attacked and now they have {Health} health!");
            
            if (Mana >= 20)
                CastSpell(damage);
            else 
                Console.WriteLine($"{Name} doesn't have enough mana to cast spell! Seems like the only thing left for them is to pray for angels' help...");
        }

        private void CastSpell(int damage)
        {
            //heals 30% from received dmg and takes 20 mana
            Health += (damage / 100) * 30;
            Mana -= 20;
            Console.WriteLine($"Angels themselves decided to help {Name} and restored their health! Now it's {Health}");
        }
        
    }
}