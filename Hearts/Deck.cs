using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hearts
{
    class Deck
    {
        public List<Card> CardDeck = new List<Card>();
        public static string[] Values = new string[13] { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
        public static string[] Suits = new string[4] { "H", "D", "C", "S", };

        public Deck()
        {
            foreach (string suit in Suits)
            {
                foreach (string value in Values)
                {
                    Card newCard = new Card(value, suit);
                    CardDeck.Add(newCard);
                }
            }
        }
    }

    class Card
    {
        public string Value { get; set; }
        public string Suit { get; set; }

        public Card(string value, string suit)
        {
            Value = value;
            Suit = suit;
        }

        public int SortSuits(Card yCard)
        {
            if (this.Value.Any(char.IsDigit) && !yCard.Value.Any(char.IsDigit)) return -1;
            if (this.Value.Any(char.IsDigit) && yCard.Value.Any(char.IsDigit)) return this.CompareDigits(yCard);
            if (!this.Value.Any(char.IsDigit) && !yCard.Value.Any(char.IsDigit)) return this.CompareLetters(yCard);
            return 1;
        }
        public int CompareDigits (Card yCard)
        {
            if (Int32.Parse(this.Value) <= Int32.Parse(yCard.Value)) return -1;
            return 1;
        }

        private int CompareLetters (Card yCard)
        {
            if (this.Value == "J" && yCard.Value != "J" ||
                this.Value == "Q" && yCard.Value != "Q" && yCard.Value != "J" ||
                this.Value == "K" && yCard.Value != "K" && yCard.Value != "Q" && yCard.Value != "J") return -1;
            return 1;
        }
    }

    #region Value and Suit Abbreviations
    // J = Jack
    // Q = Quinn
    // K = King
    // A = Ace
    // H = Hearts
    // D = Diamonds
    // C = Clubs
    // S = Spades
    #endregion

}

