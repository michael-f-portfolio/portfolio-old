using System;
using System.Collections.Generic;
using System.Linq;
using AmpLib.TCG.Cards;
using AmpLib.TCG.Cards.Heros;
using AmpLib.TCG.Cards.Minions;
using AmpLib.TCG.Cards.Spells;
using AmpLib.TCG.Mechanics;

namespace AmpLib.TCG.Decks
{
    public static class DeckGenerator
    {
        /// <summary>
        /// Creates a Mage Deck and shuffles it.
        /// </summary>
        /// <returns>A List of Card, the mage deck.</returns>
        public static List<Card> GetMageDeck()
        {
            var deck = new List<Card>
            {
                new BabyDuck(), new BabyDuck(), 
                new BabySquid(), new BabySquid(), 
                new Yeti(), new Yeti(), 
                new Fireball(), new Fireball(), 
                new FlashHeal(), new FlashHeal(), 
            };

            return Shuffle.ShuffleDeck(deck);
        }

    }
}