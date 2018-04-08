using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hearts
{
    class AIPlayer : Player
    {
        public List<Card> Hand { get; set; } = new List<Card>();

        public void PassCards(Deck deck)
        {

        }
    }
}
