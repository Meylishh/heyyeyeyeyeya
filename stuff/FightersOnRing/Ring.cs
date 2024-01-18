using System;

namespace stuff
{
    public class Ring
    {
        // Создать 5 бойцов, пользователь выбирает 2 бойцов и они сражаются друг
        // с другом до смерти. У каждого бойца могут быть свои статы.
        // Каждый игрок должен иметь особую способность для атаки, которая
        // свойственна только его классу!
        // Если можно выбрать одинаковых бойцов, то это не должна быть одна и
        // та же ссылка на одного бойца, чтобы он не атаковал сам себя.
        // Пример, что может быть уникальное у бойцов. Кто-то каждый 3 удар
        // наносит удвоенный урон, другой имеет 30% увернуться от полученного
        // урона, кто-то при получении урона немного себя лечит. Будут новые
        // поля у наследников. У кого-то может быть мана и это только его
        // особенность.
        private Fighter[] fighters;
        private Fighter fighter1;
        private Fighter fighter2;
        
        public Ring()
        {
            fighters = new Fighter[4];
            fighters[0] = new FighterType1();
            fighters[1] = new FighterType2();
            fighters[2] = new FighterType3();
            fighters[3] = new FighterType4();
        }
        
        public void ChooseYourFighters()
        {
            int counter = 1;
            Console.WriteLine("Choose 1st fighter: ");
            foreach (var fighter in fighters)
            {
                Console.WriteLine($"{counter} - {fighter.Name}");
                counter++;
            }

            fighter1 = Choice();
            Console.WriteLine("Choose 2nd fighter: ");
            fighter2 = Choice();
        }

        public void StartFight()
        {
            while (fighter1.Health > 0 && fighter2.Health > 0)
            {
                Console.WriteLine($"\n{fighter1.Name} turn:\n");
                fighter1.DealDamage(fighter2);
                Console.WriteLine($"\n{fighter2.Name} turn:\n");
                fighter2.DealDamage(fighter1);
            }
            Console.WriteLine("The fight is over!");
        }

        public void ShowWinner()
        {
            if (fighter1.Health <= 0)
            {
                Console.WriteLine($"{fighter2.Name} won!");
            }
            else if (fighter2.Health <= 0)
            {
                Console.WriteLine($"{fighter1.Name} won!");
            }
            else
            {
                Console.WriteLine("Friendship won...?");
            }
        }
        private Fighter Choice()
        {
            var input = Console.ReadLine();
            int num = 0;
            while (!int.TryParse(input, out num) || num < 1 || num > 4)
            {
                Console.WriteLine("Wrong input");
                input = Console.ReadLine();
            }
            switch (num)
            {
                case 1:
                    return new FighterType1();
                case 2:
                    return new FighterType2();
                case 3:
                    return new FighterType3();
                case 4:
                    return new FighterType4();
            }
            return null;
        }
    }
}