namespace stuff
{
    public class Fighter
    {
        public string Name { get; set; }

        public int MaxHealth;

        private int health;
        public int Health
        {
            get
            {
                return health;
            }
            set
            {
                if (health > MaxHealth)
                {
                    health = MaxHealth;
                }
                else
                {
                    health = value;
                }
            }
        }
        public int Attack { get; set; }
        public int Armor { get; set; }

        public virtual void GetDamage(int damage)
        {
            Health -= damage / 100 * Armor;
        }
        
        public virtual void GetDamage(int damage, Fighter fighter)
        {
            Health -= damage / 100 * Armor;
        }

        public virtual void DealDamage(Fighter fighter)
        {
            fighter.GetDamage(Attack);
        }
        
    }
}