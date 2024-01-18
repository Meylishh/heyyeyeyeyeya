using System;
using System.Collections.Generic;
using System.Linq;

namespace stuff
{
    public class Player
    {
        public int Money = 1000;

        public int InventoryCapacity { get; private set; } = 6;

        private List<Item> inventory;
        
        public Player()
        {
            inventory = new List<Item>(InventoryCapacity);
        }

        public void BuyItem(string name, Shopkeeper shopkeeper)
        {
            if (shopkeeper.CanSellItem(name, out Item item))
            {
                if (Money - item.Price < 0)
                {
                    Console.WriteLine("You don't have enough money to buy this item");
                }
                else
                {
                    shopkeeper.SellItem(item);
                    inventory.Add(item);
                    InventoryCapacity--;
                    Money -= item.Price;
                    Console.WriteLine($"{item.Name} was added to your inventory");
                }
            }
            else
            {
                Console.WriteLine("Shopkeeper don't have such item, couldn't buy");
            }
        }

        public void CheckInventory()
        {
            if (inventory.Any())
            {
                Console.WriteLine("Your inventory: ");
                foreach (var item in inventory)
                {
                    Console.WriteLine($"{item.Name} - {item.Description}");
                }
            }
            else
            {
                Console.WriteLine("Your inventory is empty");
            }
        }

        
        //Создать класс игрока, с полями, содержащими информацию об игроке и
        // методом, который выводит информацию на экран.
        // В классе обязательно должен быть конструктор
        // Создать класс игрока, у которого есть данные с его положением в x,y.
        // Создать класс отрисовщик, с методом, который отрисует игрока.
        // Попрактиковаться в работе со свойствами
        /*public readonly string Name;
        public readonly int Age;
        public readonly string Race;

        public int Xposition { get; set; }
        public int Yposition { get; set; }
        public Player(string name, string race, int age)
        {
            Name = name;
            Race = race;
            Age = age;

            Xposition = 0;
            Yposition = 0;
        }

        public void GetPlayerInfo()
        {
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Race: {Race}");
            Console.WriteLine($"Age: {Age}");
        }

        public void DrawPlayer(int x, int y)
        {
            Xposition = x;
            Yposition = y; 
            string[,] field = new string[5,5];
            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    if (i == y && j == x)
                        field[i, j] = "0";
                    else
                        field[i, j] = "x";
                    Console.Write(field[i,j] + " ");   
                }
                Console.WriteLine();
            }
        }
        public void DrawPlayer()
        {
            string[,] field = new string[5,5];
            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    if (i == Yposition && j == Xposition)
                        field[i, j] = "0";
                    else
                        field[i, j] = "x";
                    Console.Write(field[i,j] + " ");   
                }
                Console.WriteLine();
            }
        }*/
    }
}