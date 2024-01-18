using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace stuff
{
    public class CardPack
    {
        private const int maxAmount = 36;
        private int currentAmount;
        public bool PackIsEmpty { get; private set; }

        private Stack<Card> cardsInPack = new Stack<Card>(maxAmount);

        public CardPack()
        {
            PackIsEmpty = false;
            currentAmount = maxAmount;
            AddCards();
        }

        private void AddCards()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 6; j <= 14; j++)
                {
                    var card = new Card((CardName) j, (CardSuit) i);
                    cardsInPack.Push(card);
                }
            }
        }

        public void ShowAllCards()
        {
            Console.WriteLine("Cards in pack: ");
            foreach (var card in cardsInPack)
            {
                Console.WriteLine(card.name);
            }
        }
        
        public void ShuffleCards()
        {
            var shuffledList = cardsInPack.OrderBy(card => Guid.NewGuid()).ToList();
            var shuffledStack = new Stack<Card>(shuffledList.Count);
            for (int i = 0; i < shuffledList.Count; i++)
            {
                shuffledStack.Push(shuffledList[i]);
            }
            cardsInPack = shuffledStack;
        }
        
        public Card RemoveCard()
        {
            currentAmount--;
            if (currentAmount == 0)
                PackIsEmpty = true;
            return cardsInPack.Pop();
        }
    }
}