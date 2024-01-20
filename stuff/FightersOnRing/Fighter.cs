using System;

namespace stuff
{
    public class Fighter
    {
        public string Name { get; set; }

        protected int MaxHealth;
        public float Health { get; set; }
        protected int Attack { get; set; }
        protected int Armor { get; set; }

        public virtual void GetDamage(int damage)
        {
            var dmg = 100 - Armor;
            Health -= Convert.ToSingle(damage) / 100 * dmg;
            if (Health < 0)
            {
                Health = 0;
            }
            //100% - armor
            //% getting
        }
        
        public virtual void DealDamage(Fighter fighter)
        {
            //takes fighter and deals YOUR dmg
            fighter.GetDamage(Attack);
        }
        
    }
}