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
        public static Card[] ShuffleDeck(IEnumerable<Card> toShuffle)
        {
            var rnd = new RNGCryptoServiceProvider();
            return toShuffle.OrderBy(x => GetNextInt32(rnd)).ToArray();
        }

        private static int GetNextInt32(RNGCryptoServiceProvider rnd)
        {
            var randomInt = new byte[4];
            rnd.GetBytes(randomInt);
            return Convert.ToInt32(randomInt[0]);
        }
    }
}