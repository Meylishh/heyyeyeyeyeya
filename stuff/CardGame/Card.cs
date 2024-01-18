namespace stuff
{
    public class Card
    {
        public readonly string name;
        public Card(CardName name, CardSuit suit)
        {
            this.name = $"{suit.ToString()}{name.ToString()}";
        }
    }
    public enum CardSuit
    {
        Heart,
        Spade,
        Diamond,
        Club
    }

    public enum CardName
    {
        Six = 6,
        Seven = 7,
        Eight = 8,
        Nine = 9,
        Ten = 10,
        Jack = 11,
        Queen = 12,
        King = 13,
        Ace = 14
    }
}