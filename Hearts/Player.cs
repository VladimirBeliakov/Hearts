using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hearts
{
    interface Player
    {
        List<Card> Hand { get; set; }
        //void PassCards();
        //void MakeMove();
        void PassCards(Deck deck);
    }
}
