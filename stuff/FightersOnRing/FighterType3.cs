using System;

namespace stuff
{

    public class FighterType3 : Fighter
    {
        private readonly Random rnd;

        private bool twiceHit;
        //has low stats but a 30% chance to dodge an attack and if so, fight back 50% stronger
        public FighterType3()
        {
            Name = "Sneaky nimble little Sunny";
            MaxHealth = 90;
            Health = MaxHealth;
            Attack = 25;
            Armor = 15;
            rnd = new Random();
            twiceHit = false;
        }

        public override void GetDamage(int damage)
        {
            twiceHit = TryCastSpell();
            if (!twiceHit)
            {
                base.GetDamage(damage);
                Console.WriteLine($"{Name} almost flew away after getting {damage}, but not going to give up with the health {Health}!");
            }
        }

        public override void DealDamage(Fighter fighter)
        {
            if (twiceHit)
            {
                Console.WriteLine($"{Name} got a bonus for his amazing dodge and deals {Attack * 2} damage! Holy moly");
                twiceHit = false;
                fighter.GetDamage(Attack * 2);
            }
            else
            {
                Console.WriteLine($"Watch out! {Name} jumps out of nowhere and attacks for {Attack}!");
                base.DealDamage(fighter);
            }
        }

        private bool TryCastSpell()
        {
            var chance = rnd.Next(100);
            if (chance <= 30)
            {
                Console.WriteLine($"Yay, {Name} amazingly dodged an attack like an agile cat!");
                return true;
            }
            return false;
        }
    }
}