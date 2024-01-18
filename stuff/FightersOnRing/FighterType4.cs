using System;

namespace stuff
{
    public class FighterType4 : Fighter
    {
        //has low atk but lots of health and armor. each time when gets hit, returns the enemy 10% of his current health
        public FighterType4()
        {
            Name = "Indestructible Big Bro Herod";
            MaxHealth = 200;
            Health = MaxHealth;
            Attack = 5;
            Armor = 20;
        }

        public override void GetDamage(int damage, Fighter fighter)
        {
            base.GetDamage(damage);
            Console.WriteLine($"{Name} takes {damage} like nothing and didn't even blink once! Did they even notice?");
            CastSpell(fighter);
        }

        public override void DealDamage(Fighter fighter)
        {
            base.DealDamage(fighter);
            Console.WriteLine($"{Name} takes a swing and hits {fighter.Name} for {Attack}. Well, they tried their best!");
        }

        private void CastSpell(Fighter fighter)
        {
            fighter.GetDamage(Health / 100 * 10);
            Console.WriteLine($"Oh no! {Name} comes back with revenge and deals back {Health / 100 * 10} damage!");
        }
    }
}