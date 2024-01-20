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
        private Fighter[] fightersList;
        private Fighter fighter1;
        private Fighter fighter2;
        
        public Ring()
        {
            fightersList = new Fighter[4];
            fightersList[0] = new FighterType1();
            fightersList[1] = new FighterType2();
            fightersList[2] = new FighterType3();
            fightersList[3] = new FighterType4();
        }
        
        public Fighter[] ChooseYourFighters()
        {
            int counter = 1;
            foreach (var fighter in fightersList)
            {
                Console.WriteLine($"{counter} - {fighter.Name}");
                counter++;
            }
            
            var chosenFighters = new Fighter[2];
            Console.WriteLine("Choose 1st fighter: ");
            chosenFighters[0] = Choice();
            Console.WriteLine("Choose 2nd fighter: ");
            chosenFighters[1] = Choice();
            return chosenFighters;

        }

        public void StartFight(Fighter[] fighters)
        {
            while (fighters[0].Health > 0 && fighters[1].Health > 0)
            {
                Console.WriteLine($"\n{fighters[0].Name} turn:\n");
                fighters[0].DealDamage(fighters[1]);
                
                if(fighters[1].Health == 0)
                    break;
                
                Console.WriteLine($"\n{fighters[1].Name} turn:\n");
                fighters[1].DealDamage(fighters[0]);
            }
            Console.WriteLine("The fight is over!");
        }

        public void ShowWinner(Fighter[] fighters)
        {
            if (fighters[0].Health > 0 && fighters[1].Health > 0)
                Console.WriteLine("Could not find a winner, please restart a fight");
            else
            {
                if (fighters[0].Health <= 0)
                    Console.WriteLine($"{fighters[1].Name} won!");
                else if (fighters[1].Health <= 0)
                    Console.WriteLine($"{fighters[0].Name} won!");
                else
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