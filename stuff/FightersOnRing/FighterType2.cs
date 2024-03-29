﻿using System;

namespace stuff
{
    public class FighterType2 : Fighter
    {
        //has a strong attack but poor armor. each 3rd hit deals x3 dmg
        private int counter;
        
        public FighterType2()
        {
            Name = "Super Strong Grandpa Alfred";
            MaxHealth = 100;
            Health = MaxHealth;
            Attack = 30;
            Armor = 10;
            counter = 3;
        }

        public override void DealDamage(Fighter fighter)
        {
            if (counter > 1)
            {
                Console.WriteLine($"{Name} punches {fighter.Name} for {Attack} and says that this isn't his strongest hit with a smirk!");
                counter--;
                base.DealDamage(fighter);
            }
            else
            {
                CastSpell(fighter);
                counter = 3;
            }
        }

        public override void GetDamage(int damage)
        {
            //default take dmg
            base.GetDamage(damage);
            Console.WriteLine($"{Name} was attacked but doesn't show any emotion like a true fighter, though their health now is {Health}");
        }

        private void CastSpell(Fighter fighter)
        {
            Console.WriteLine($"Oh-oh, {Name} decides to show their true power now and hits {fighter.Name} with all force for {Attack * 3}!");
            fighter.GetDamage(Attack * 3);
        }
    }
}