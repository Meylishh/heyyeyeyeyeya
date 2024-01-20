using System;

namespace stuff
{
    public class FighterType4 : Fighter
    {
        //has low atk but lots of health and armor. each time when gets hit, returns the enemy 10% of his current health
        private Fighter _fighter;
        public FighterType4()
        {
            Name = "Indestructible Big Bro Herod";
            MaxHealth = 300;
            Health = MaxHealth;
            Attack = 5;
            Armor = 20;
            _fighter = null;
        }

        public override void GetDamage(int damage)
        {
            base.GetDamage(damage);
            Console.WriteLine($"{Name} takes {damage} like nothing and didn't even blink once! Did they even notice that their health now is {Health}?");
            if (_fighter != null && Health > 0) 
                CastSpell(_fighter);
        }

        public override void DealDamage(Fighter fighter)
        {
            _fighter = fighter;
            Console.WriteLine($"{Name} takes a swing and hits {fighter.Name} for {Attack}. Well, they tried their best!");
            base.DealDamage(fighter);
        }

        private void CastSpell(Fighter fighter)
        {
            Console.WriteLine($"Oh no! {Name} comes back with revenge and deals back {Convert.ToInt32(Health / 100 * 10)} damage!");
            fighter.GetDamage(Convert.ToInt32(Health / 100 * 10));
        }
    }
}