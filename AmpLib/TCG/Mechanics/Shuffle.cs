using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using AmpLib.TCG.Cards;

namespace AmpLib.TCG.Mechanics
{
    public static class Shuffle
    {
        // Shuffle deck using System.Security.Crptography
        // Via http://stackoverflow.com/a/108836

        /// <summary>
        /// Shuffles a deck of cards.
        /// </summary>
        /// <param name="toShuffle">The deck to be shuffled.</param>
        /// <returns>A List of Cards, shuffled.</returns>
        public static List<Card> ShuffleDeck(List<Card> toShuffle)
        {
            var rnd = new RNGCryptoServiceProvider();
            return toShuffle.OrderBy(x => GetNextInt32(rnd)).ToList();
        }

        private static int GetNextInt32(RNGCryptoServiceProvider rnd)
        {
            var randomInt = new byte[4];
            rnd.GetBytes(randomInt);
            return Convert.ToInt32(randomInt[0]);
        }
    }
}