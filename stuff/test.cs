using System;
using System.Collections.Generic;

namespace stuff
{
    public class Creature
    {
        public int Attack { get; set; }
    }

    public class BaseModifier
    {
        public BaseModifier(Creature creature)
        {
            Creature = creature;
        }
        protected readonly Creature Creature; 
        private BaseModifier nextModifier;
        public virtual void ApplyModifier() => nextModifier?.ApplyModifier();

        public void AddModifier(BaseModifier modifier)
        {
            if (nextModifier != null)
            {
                nextModifier.AddModifier(modifier);
            }
            else
            {
                nextModifier = modifier;
            }
        }
    }

    public class DoubleAttackModifier: BaseModifier
    {
        public DoubleAttackModifier(Creature creature) : base(creature)
        {
        }

        public override void ApplyModifier()
        {
            Creature.Attack *= 2;
            Console.WriteLine($"x2 attack: {Creature.Attack}");
            base.ApplyModifier();
        }
    }
    
    public class DisableAllAttackModifier: BaseModifier
    {
        public DisableAllAttackModifier(Creature creature) : base(creature)
        {
            
        }
        public override void ApplyModifier()
        {
            Console.WriteLine($"Disabled modifiers: {Creature.Attack}");
        }
    }
}