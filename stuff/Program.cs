using System;
using System.Collections.Generic;
using System.Security.Policy;
using System.Threading;
using stuff.ZOOO;

namespace stuff
{
    public class Program
    {
        public static void Main(string[] args)
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
    }
}