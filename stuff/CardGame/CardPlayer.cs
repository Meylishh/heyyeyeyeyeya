using System;
using System.Collections.Generic;

namespace stuff
{
    // Есть колода с картами. Игрок достает карты, пока не решит, что ему
    // хватит карт (может быть как выбор пользователя, так и количество
    // сколько карт надо взять). После выводиться вся информация о
    // вытянутых картах.
    // Возможные классы: Карта, Колода, Игрок.

    public class CardPlayer
    {
        public readonly string name;
        public readonly List<Card> playerCards = new List<Card>();
        public CardPlayer(string name)
        {
            this.name = name;
        }

        public void TakeCard(CardPack pack, int amountOfCards)
        {
            var newCards = new List<Card>();
            
            for (int i = 0; i < amountOfCards; i++)
            {
                if (!pack.PackIsEmpty)
                {
                    var card = pack.RemoveCard();
                    playerCards.Add(card);
                    newCards.Add(card);
                }
                else
                {
                    break;
                }
            }

            if (newCards.Count != 0)
            {
                Console.WriteLine("The cards were taken: ");
                foreach (var card in newCards)
                {
                    Console.WriteLine(card.name);
                }
            }
        }

        public void CheckAllCards()
        {
            if (playerCards.Count != 0)
            {
                Console.WriteLine($"{name}'s cards: ");
                foreach (var card in playerCards)
                {
                    Console.WriteLine(card.name);
                }
            }
            else
            {
                Console.WriteLine("No cards");
            }
        }
    }
}