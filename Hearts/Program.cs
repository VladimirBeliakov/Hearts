using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hearts
{
    class Program
    {
        static void Main(string[] args)
        {
            GamePlay newGame = new GamePlay();
            Deck deck = new Deck();
            newGame.PlayTheGame(deck);
        }
    }
}
