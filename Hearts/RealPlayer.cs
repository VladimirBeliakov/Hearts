using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hearts
{
    class RealPlayer : Player
    {
        private string _firstInput = "";
        private string _secondInput = "";
        private string _thirdInput = "";

        public List<Card> Hand { get; set; } = new List<Card>();
        public List<Card> CardsToPass { get; set; } = new List<Card>();

        public void PassCards(Deck deck)
        {
            Console.WriteLine("Please, choose three cards to pass");

            while (true)
            {
                Console.WriteLine("Enter the first one");
                _firstInput = Console.ReadLine().ToUpper();
                if (!ProcessInput(_firstInput)) continue;
                break;
            }
            
            while (true)
            {
                Console.WriteLine("Enter the second one");
                _secondInput = Console.ReadLine().ToUpper();
                if (!ProcessInput(_secondInput)) continue;
                break;
            }

            while (true)
            {
                Console.WriteLine("Enter the third one");
                _thirdInput = Console.ReadLine().ToUpper();
                if (!ProcessInput(_thirdInput)) continue;
                break;
            }
        }

        private bool ProcessInput(string currentInput)
        {
            if (currentInput == _secondInput || currentInput == _firstInput)
            {
                Console.WriteLine("You've already chosen this card. Pick another one.");
                return false;
            }
            if (!TurnCardInputIntoObject(currentInput))
            {
                Console.WriteLine("This is an invalid input.");
                return false;
            };
            return true;
        }

        private bool TurnCardInputIntoObject(string input)
        {
            char[] charArrayForCardToPass = input.ToCharArray();
            if (!CheckCardEntered(charArrayForCardToPass))
                return false;

            Card cardToPass;

            if (charArrayForCardToPass.Length == 3)
                 cardToPass = new Card(charArrayForCardToPass[0].ToString() +
                                       charArrayForCardToPass[1].ToString(),
                                       charArrayForCardToPass[2].ToString());
            else cardToPass = new Card(charArrayForCardToPass[0].ToString(),
                                       charArrayForCardToPass[1].ToString());

            this.Hand.Remove(cardToPass);
            CardsToPass.Add(cardToPass);
            return true;
        }

        private bool CheckCardEntered(char[] charArray)
        {
            if (charArray.Length == 3)
            {
                if (Int32.Parse(charArray[0].ToString()) + 
                    Int32.Parse(charArray[1].ToString()) == 10 &&
                    Deck.Suits.Contains(charArray[2].ToString()))
                    return true;
            }
            else if (charArray.Length == 2) 
            {
                if (Int32.Parse(charArray[0].ToString()) > 1 &&
                    Int32.Parse(charArray[0].ToString()) < 10 &&
                    Deck.Suits.Contains(charArray[1].ToString()))
                    return true;
            }
            return false;
        }
    }
}
