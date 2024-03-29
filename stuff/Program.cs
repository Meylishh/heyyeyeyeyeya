﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using stuff.Bank;
using stuff.BookStorage;
using stuff.Calculate;
using stuff.Carsss;
using stuff.CharacteristicImprovement;
using stuff.Exceptions;
using stuff.IVehicles;
using stuff.Shapes;
using stuff.ShapeStructy;
using stuff.Supermarket;
using stuff.ZOOO;
using Car = stuff.Carsss.Car;
using Rectangle = stuff.Shapes.Rectangle;

// ReSharper disable All

namespace stuff
{
    public class Program
    {
   
        public static void Main(string[] args)
        {
            var a = new POINT( 2,6);
            var b = new POINT(5, 1);
            var rect = new ShapeStructy.Rectangle(a, b);
            Console.WriteLine(rect.Area());
            Console.WriteLine(rect.Contains(new POINT(2,3)));
            
        }

        #region DZs
        private static void PrintPurchaseResult(float cost, float balance)
        {
            // var balance = 3232f;
            // Console.WriteLine($"Current balance: {balance}");
            // WalletOperations.IncreaseBalanceByPercent(ref balance, 10);
            // Console.WriteLine($"New balance: {balance}");
            //
            // PrintPurchaseResult(200, balance);
            // PrintPurchaseResult(5656, balance);
            ////
            
            if (WalletOperations.TryPurchase(cost, balance, out float newBalance))
            {
                Console.WriteLine($"Success: new balance {newBalance}");
            }
            else
            {
                Console.WriteLine($"Fail: new balance {newBalance}");
            }
        }
        private static void BankAccount()
        {
            var a = new BankAccount();
            a.HandleWriteOffMoney(343232);
            a.HandleWriteOffMoney(100);
            a.HandleWriteOffMoney(-6);
        }
        private static void Storage()
        {
            Input.Divide(Input.HandleInput());
            //////////////////
            var strg = new Storage();
            var b1 = new BookStorage.Book("Cherry's photo album", "Meylish", 2030);
            var b2 = new BookStorage.Book("The Great Dolina Polsha Dictionary", "Meylish & Derllie", 2024);
            
            try
            {
                b1.AddCopies(122);
                strg.AddBook(b1);
                strg.AddBook(b2);
                b2.RemoveCopies(12);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            
            try
            {
                strg.RemoveBook(b1.Id);
                strg.RemoveBook(122);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            
            strg.FindBookByName("The Great Dolina Polsha Dictionary");
            strg.ShowAllBooks();
        }
        private static void User()
        {
            var user = new User.User("Meylish", "meylishhhushh@pigeonmail.su", "123456");
            Console.WriteLine($"Name: {user.Name}\nEmail: {user.EMailAddress}\nPassword: {user.Password}");
            user.ChangePassword("dfdfjkdjf", "238783873huhhuhuh");
            user.ChangePassword("123456", "<0w0>");
        }
        private static void AutoService(Car client)
        {
            var service = new AutoService.AutoService(500);
            service.ServeClient(new AutoService.Car("Lada", 3));
        }
        private static void PlayerEqupment()
        {
            var player = new CharacteristicImprovement.Player();
            
            var armor1 = new Armor(player, "Paper Shield", 2);
            var armor2 = new Armor(player, "Iron Armor", 20);
            var weapon1 = new Weapon(player, "Blade", 5);
            var wearon2 = new Weapon(player, "Proposal Ring", 10);
            
            
            player.Equipment.AddNewItem(armor1, armor2, weapon1, wearon2);
            Console.WriteLine();
            
            player.Equipment.DisableItem(armor1);
            Console.WriteLine();
            
            player.Equipment.EnableItem(armor1);
            Console.WriteLine();
            
            player.Equipment.ClearAllEquipment();
            player.Equipment.DisplayStatsInfo();
        }
        private static void Modifiers()
        {
            var creature = new Creature();
            creature.Attack = 10;
            var baseModif = new BaseModifier(creature);
            var m1 = new DoubleAttackModifier(creature);
            var m2 = new DisableAllAttackModifier(creature);
            var m3 = new DoubleAttackModifier(creature);
            var m4 = new DoubleAttackModifier(creature);
            
            baseModif.AddModifier(m1);
            baseModif.AddModifier(m2);
            baseModif.AddModifier(m3);
            baseModif.AddModifier(m4);
            
            baseModif.ApplyModifier();
        } 
        private static void IVehicles()
        {
            var submarine = new Submarine(150); 
            submarine.Sail();
            Console.WriteLine();
           
            submarine.IsUnderWater = true;
            submarine.Sail();
            Console.WriteLine();

            var amph = new Amphibius(500);
            amph.Fly();
            Console.WriteLine();
            amph.Sail();

            var car = new IVehicles.Car(250);
            car.Ride();
        }
        private static void Shapes()
        {
            var list = new List<Shape>()
            {
                //does not allow to create a non-existent shape
                //new Triangle(10, 33, 12),
                new Triangle(12, 9, 6),
                new Rectangle(10, 20),
                new Circle(20)
            };

            foreach (var shape in list)
            {
                Console.WriteLine($"Shape {shape.GetType().Name.ToLower()} has area of {shape.Area()} and perimeter {shape.Perimeter()}.");
            }
            
            Console.ReadLine();
        }
        private static void Calculator()
        {
            char[] operators = new[] {'%', '^', '/', '*', '+', '-'};
            var operation = new Operation();
            var userInput = string.Empty;
            string[] inputOperation = new string[3];
            double num1 = default;
            double num2 = default;
            Console.WriteLine("This is the best and the most accurate calculator in the universe.");
            Console.Write("Enter an operation for two nums (write floating nums and sign with spaces): ");
            userInput = Console.ReadLine();
            while (userInput != "exit")
            {
                if (userInput.Contains(' ')) //input w spaces
                {
                    inputOperation = userInput.Split(" ");
                }
                else //input without spaces just for fun,,,
                {
                    char sign = default;
                    //check if first number is with +/- sign and if there is, take the next
                    if (operators.Contains(userInput[0]))
                    {
                        sign = operators.FirstOrDefault(c => userInput.Remove(0,1).Contains(c));
                    }
                    else
                    {
                        sign = operators.FirstOrDefault(c => userInput.Contains(c));
                    }
                    //split by sign if there is
                    if (sign != default)
                    {
                        inputOperation = userInput.Split(sign);
                        inputOperation = new[] {inputOperation[0], sign.ToString(), inputOperation[1]};
                    }
                    else
                    {
                        inputOperation = Array.Empty<string>();
                    }
                } //check if the operation generally correct
                if (inputOperation.Length == 3 && double.TryParse(inputOperation[0], out num1) && double.TryParse(inputOperation[2], out num2) 
                    && operators.Contains(Convert.ToChar(inputOperation[1]))) 
                {
                    switch (inputOperation[1])
                    {
                        case "+":
                            operation = new AddOperation();
                            break;
                        case "-":
                            operation = new SubtractOperation();
                            break;
                        case "*":
                            operation = new MultiplyOperation();
                            break;
                        case "/":
                            operation = new DivideOperation();
                            break;
                        case "%":
                            operation = new ModuloOperation();
                            break;
                        case "^":
                            operation = new PowerOperation();
                            break;
                    }
                    var result = operation.Calculate(num1, num2);
                    if (result != null) //check if an operation was succeed
                    {
                        Console.WriteLine($"Result: {result}");
                    }
                    else
                    {
                        Console.WriteLine("Seems like you tried to divide by zero... I'm not gonna comment this");
                    }
                    userInput = Console.ReadLine();
                }
                else
                {
                    Console.Write("Wrong input(not the calculator!!!), try again: ");
                    userInput = Console.ReadLine();
                }
            }
        }
        private static void Supermarket()
        {
            var cli = new Client("Meylish", 99999);
            Console.WriteLine(cli.Cart.CartPrice);
            cli.Cart.ShowCart();
            var sprMarket = new SupermarketManager(SupermarketManager.GenerateClientsQueue(10));
            sprMarket.StartTakingClients();
        }
        private static void Cars()
        {
            var teslaTruck = new TeslaTruck("Tesla", "Truck", 2017, 1300, 724, 160, 36000);
            var teslaCar = new TeslaModelS("Tesla", "S", 2012, 1000, 426, 85, 5);
            var car = new Car("Toyota", "Mark 2", 1968, 1000, 5);
            var truck = new Truck("Mack", "Super Liner", 1977, 130000, 23000);
            var motorcycle = new Motorcycle("Dinka", "Double-T", 2013, 200, MotorcycleType.Sport);

            List<Vehicle> vehicles = new List<Vehicle>() {teslaTruck, teslaCar, car, truck, motorcycle};
            foreach (var vehicle in vehicles)
            {
                vehicle.DisplayInfo();
                vehicle.StartEngine();
                vehicle.TurnOnRadio(RadioStation.RetroFM);
            }
            
            
            teslaCar.ChargeBattery();
            
            /*Console.WriteLine();
            teslaTruck.SetRoute(City.Moscow, City.MagicCity);
            teslaTruck.CheckBatteryCharge();
            teslaTruck.LoadCargo(799);
            teslaTruck.Ride(100);
            teslaTruck.CheckBatteryCharge();
            teslaTruck.ChargeBattery();
            teslaTruck.CheckBatteryCharge();
            teslaTruck.LoadCargo(100000000);
            Console.WriteLine();
            teslaCar.Park();
            teslaCar.AutoPilotEnabled = false;
            teslaCar.Park();
            teslaCar.LockAllDoors();
            teslaCar.LockAllDoors();
            teslaCar.UnlockAllDoors();
            
            motorcycle.DoWheelie();*/
        }
        private static void Zoo()
        {
            var zoo = new Zoo();
            
            var meylish = new Mammal("Meylish", 17, FoodType.Omnivorous, true);
            zoo.AddAnimal(meylish);
            
            var cherry = new Mammal("cat Cherry", 1, FoodType.Omnivorous, false);
            zoo.AddAnimal(cherry);

            var gena = new Reptile("crocodile Gena", 10, FoodType.Carnivorous, false);
            zoo.AddAnimal(gena);
            
            var lexus = new Bird("parrot Lexus", 2, FoodType.Herbivore, 30);
            zoo.AddAnimal(lexus);

            Console.WriteLine();
            lexus.ReadSign();
            gena.TakeALook();
            cherry.Pat();
            meylish.Pat();
            
            Console.WriteLine();
            zoo.PrintAllAnimals();
            
            Console.WriteLine();
            zoo.FeedAnimals();
            
            Console.WriteLine();
            foreach (var animal in zoo.Animals)
            {
                animal.MakeSound();
            }
        }
        private void Library()
        {
            //librarby
            var book1 = new Book("101 way to waste your life", "Meylish", 2024);
            var book2 = new Book("Slowburn isn't boring, you are", "Susanna", 2022);
            var book3 = new Book("How i spent my summer", "Mayday", 2022);
            var book4 = new Book("The washing machine manual", "Vlen", 2036);
            var book5 = new Book("Guide on how to repel people", "Meylish", 2023);
            var book6 = new Book("Deep analysis of minsons relationship", "Susanna", 2023);
            var book7 = new Book("Why are levi and hanji kanon and your <censored> eruri <censored> <censored>",
                "Susanna", 2024);
            var book8 = new Book("The great story of Dolina Polsha emancipation", "Diluxe", 2024);
            var book9 = new Book("10 reasons for Meylish to start playing Dota", "ZloyDed", 2024);

            var library = new Library();
            library.AddBook(book1);
            library.AddBook(book2);
            library.AddBook(book3);
            library.AddBook(book4);
            library.AddBook(book5);
            library.AddBook(book6);
            library.AddBook(book7);
            library.AddBook(book8);
            library.AddBook(book9);
            library.AddBook(book9);

            Console.WriteLine("\n");
            library.ShowAllBooks();
            Console.WriteLine("\nBy author: \n");
            library.ShowBooksByAuthor("Susanna");
            Console.WriteLine("\nBy name: \n");
            library.ShowBooksByName();
            Console.WriteLine("\nBy year: \n");
            library.ShowBooksByYear(2022);
            Console.WriteLine("\n");
            library.RemoveBook("aaaa", true);

            var reader = new Reader();
            reader.BorrowBook("Master and Margarita", library);
            reader.BorrowBook("The washing machine manual", library);
            reader.ShowAllBooks();
            reader.ReturnBook("The washing machine manual", library);
        }
        private void Fighters()
        {
            //fighters
            var ring = new Ring();
            var fighters = ring.ChooseYourFighters();
            ring.StartFight(fighters);
            ring.ShowWinner(fighters);
        }
        private void Shop()
        {
            //shop
            Player plr = new Player();
            var items = new List<Item>();
            var item1 = new Item("Clay kitty", 1000,
                "Cutie patootie little clay kitten from Maeve... Who is Maeve? Well, maybe this lonely black-haired old man knows");
            var item2 = new Item("Glued mug", 10,
                "Idk why would anyone need this, but you would look very fancy walking down the street and drinking from the mug");
            var item3 = new Item("Paper vine box", 5, "Don't think it's useless. It can even be your house");
            var item4 = new Item("Cooler for AM2", 30, "Idk... Just save it as a relic");
            items.Add(item1);
            items.Add(item2);
            items.Add(item3);
            items.Add(item4);
            Shopkeeper shopkeeper = new Shopkeeper(items);
            shopkeeper.ShowAllItems();
            plr.CheckInventory();
            plr.BuyItem("Clay kitty", shopkeeper);
            plr.CheckInventory();
            plr.BuyItem("Glued mug", shopkeeper);
            shopkeeper.ShowAllItems();
        }
        private void TrainConfig()
        {
            //train config
            TrainRouteConfigurator.ShowCurrentTrain();
            var route = TrainRouteConfigurator.CreateRoute();
            if (route != null)
            {
                var tickets = TrainRouteConfigurator.SellTickets(route);
                var train = TrainRouteConfigurator.CreateTrain(route, tickets);
                TrainRouteConfigurator.LaunchTrain(train);
                TrainRouteConfigurator.ShowCurrentTrain();
            }
            else
            {
                Console.WriteLine("Wrong route");
            }
        }
        private void Cards()
        {
            //card game
            var cardPack = new CardPack();
            cardPack.ShuffleCards();
            CardGame.AddPlayers();
            CardGame.Rounds(cardPack);
            CardGame.ShowWinner();
        }
        private void Database()
        {
            //database
            /*var player = new Player("mey", "gayhub student", 17);
            player.GetPlayerInfo();
            player.DrawPlayer(3,4);
            Console.WriteLine();
            player.Yposition = 1;
            player.Xposition = 4;
            player.DrawPlayer();
            
            PlayersDatabase.AddPlayer();
            PlayersDatabase.AddPlayer();
            PlayersDatabase.AddPlayer();


            Console.WriteLine(PlayersDatabase.GetIDbyIndex(1));
            PlayersDatabase.BanPlayer(PlayersDatabase.GetIDbyIndex(1));
            PlayersDatabase.DeletePlayer(PlayersDatabase.GetIDbyIndex(1));*/
        }
        private void HW1()
        {
             //1
            void CheckIfEven()
            {
                Console.Write("Enter any number: ");
                var num = Console.ReadLine();
                int numParsed;
                while (!int.TryParse(num, out numParsed))
                {
                    Console.Write("This is not a number. Try again: ");
                    num = Console.ReadLine();
                }
                if (numParsed % 2 == 0)
                    Console.WriteLine($"{numParsed} is even");
                else
                    Console.WriteLine($"{numParsed} is uneven");
            }
            CheckIfEven();
            
            //2
            var numList = new List<int>();
            for (int i = 1; i <= 10; i++)
            {
                numList.Add(i);
            }
            Console.WriteLine(string.Join(" ", numList));
            for (int i = 0; i < 10; i++)
            {
                numList[i] += 2;
            }
            Console.WriteLine(string.Join(" ", numList));

            //3
            var random = new Random();
            int randomNumber;
            int attemptsCounter;

            Console.Write("Enter your name, fighter... ");
            var playerName = Console.ReadLine();
            Console.WriteLine($"Welcome to the game, {playerName}. The rules are:\nGuess a number for the least amount of attempts" +
                              "\nIf it's more than 5, your system will be deleted\nGood luck!");
            GuessNumberGame();
            void GuessNumberGame()
            {
                randomNumber = random.Next(1, 101);
                attemptsCounter = 0;
                int convertedInput = 0;
                
                while (convertedInput != randomNumber)
                {
                    Console.Write("Guess a number: ");
                    string playerInput = Console.ReadLine();
                    if (int.TryParse(playerInput, out convertedInput))
                    {
                        attemptsCounter++;
                        
                        if (convertedInput < randomNumber)
                            Console.WriteLine("Nope. Your num is lesser.");
                        else if (convertedInput > randomNumber)
                            Console.WriteLine("Nope. Your num is greater.");
                        else
                        {
                            Console.WriteLine($"Congrats! You won. It took you {attemptsCounter} attempts");
                            break;
                        }
                    }
                    else
                        Console.WriteLine("Wrong input.\n");
                }
                
                if (attemptsCounter > 5)
                {
                    Console.WriteLine("Unfortunately, it took you more than 5 attempts... Your system will be deleted, " +
                                      "but you have a little time left. Wanna try again?");
                }
                else
                {
                    Console.WriteLine("Good game! But you're just lucky. How about one more try?");
                }

                switch (Console.ReadLine().ToLower())
                {
                    case "no":
                        Console.WriteLine("ok.");
                        break;
                    case "yes":
                    case "ok":
                        Console.WriteLine("Yay! Let's go");
                        GuessNumberGame();
                        break;
                    default:
                        Console.WriteLine("??? Whatever, i'll count it as yes");
                        GuessNumberGame();
                        break;
                }

            }
        }
        #endregion
        
    }
}