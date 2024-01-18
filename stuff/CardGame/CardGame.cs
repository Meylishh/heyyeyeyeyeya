using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace stuff
{
    public static class CardGame
    {
        private static Dictionary<string, CardPlayer> players = new Dictionary<string, CardPlayer>();
        public static void AddPlayers()
        {
            int plrCounter = 1;
            Console.WriteLine("Enter players names. When you're done, write \"done\"");
            var input = string.Empty;
            while (input.ToLower() != "done")
            {
                Console.Write($"{plrCounter} player name: ");
                input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Wrong input");
                }
                else if (players.ContainsKey(input))
                {
                    Console.WriteLine("There is already a player with such name");
                }
                else if (input == "done")
                {
                    break;
                }
                else
                {
                    players.Add(input,new CardPlayer(input));
                    plrCounter++;

                }

            }
        }

        public static void Rounds(CardPack cardPack)
        {
            while (!cardPack.PackIsEmpty)
            {
                for (int i = 0; i < players.Count; i++)
                {
                    if (!cardPack.PackIsEmpty)
                    {
                        Console.WriteLine($"{players.ElementAt(i).Key}'s turn. How many cards you wanna take? ");
                        var input = Console.ReadLine();
                        int amount = default;
                        while (!int.TryParse(input, out amount))
                        {
                            Console.WriteLine("Wrong input. Enter a number");
                            input = Console.ReadLine();
                        }
                        var player = players.ElementAt(i).Value;
                        player.TakeCard(cardPack, amount);
                    }
                } 
                
            }
            
        }

        public static void ShowWinner()
        {
            var playersCardAmount = new Dictionary<string, int>();
            foreach (var player in players.Values)
            {
                playersCardAmount.Add(player.name, player.playerCards.Count);
            }
            var maxAmount = playersCardAmount.Values.Max();
            var winner = playersCardAmount.FirstOrDefault(x => 
                x.Value == maxAmount).Key;
            Console.WriteLine($"Player with max amount of cards: {winner}");
        }
        
    }
}