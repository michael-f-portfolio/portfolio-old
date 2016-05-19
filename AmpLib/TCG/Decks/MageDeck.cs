using System;
using System.Linq;
using AmpLib.TCG.Cards;
using AmpLib.TCG.Cards.Minions;
using AmpLib.TCG.Cards.Spells;
using AmpLib.TCG.Mechanics;

namespace AmpLib.TCG.Decks
{
    public class MageDeck
    {
        public Card[] Deck { get; set; }

        public MageDeck()
        {
            Deck = new Card[]
            {
                new BabyDuck(), new BabyDuck(), 
                new BabySquid(), new BabySquid(), 
                new Yeti(), new Yeti(), 
                new Fireball(), new Fireball(), 
                new FlashHeal(), new FlashHeal(), 
                new ShieldsUp(), new ShieldsUp()
            };

            Deck = Shuffle.ShuffleDeck(Deck);
        }

        public override string ToString()
        {
            var str = "";

            foreach (var card in Deck)
            {
                str += card + "\n";
            }

            return str;
        }
    }
}