using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hearts
{
    class GamePlay
    {
        Player realPlayer = new RealPlayer();
        Player aiPlayer_1 = new AIPlayer();
        Player aiPlayer_2 = new AIPlayer();
        Player aiPlayer_3 = new AIPlayer();

        List<Card> playingDeck = new List<Card>();

        public void PlayTheGame(Deck deck)
        {
            Shuffling(deck);
            Dealing(realPlayer, 0);
            SortRealPlayerDeck();
            Dealing(aiPlayer_1, 1);
            Dealing(aiPlayer_2, 2);
            Dealing(aiPlayer_3, 3);

            Console.WriteLine("You have the following cards:");
            foreach (Card card in realPlayer.Hand)
            {
                Console.Write(card.Value + card.Suit + " ");
            }
            Console.WriteLine();
            realPlayer.PassCards(deck);



        }

        private void Shuffling(Deck deck)
        {
            Random rnd = new Random();
            playingDeck = deck.CardDeck.OrderBy(x => rnd.Next(52)).ToList();
        }

        private void Dealing(Player player, int playerNumber)
        {
            for (int i = playerNumber; i < playingDeck.Count; i += 4)
            {
                player.Hand.Add(playingDeck[i]);
            }
        }

        private void SortRealPlayerDeck()
        {
            // Sorting by suit
            realPlayer.Hand.Sort(delegate (Card x, Card y)
            {
                if (x.Suit == "H" && y.Suit != "H" ||
                    x.Suit == "D" && y.Suit != "D" && y.Suit != "H" ||
                    x.Suit == "C" && y.Suit != "C" && y.Suit != "D" && y.Suit != "H") return -1;
                if (x.Suit == y.Suit) return 0;
                return 1;
            });
            
            // Sorting by value
            realPlayer.Hand.Sort(delegate (Card x, Card y)
            {
                if (x.Suit == y.Suit) return x.SortSuits(y);
                return 0;
            });
        }
    }
}
