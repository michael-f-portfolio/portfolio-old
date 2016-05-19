using System;
using System.Collections.Generic;
using System.Linq;
using AmpLib.TCG.Cards;
using AmpLib.TCG.Cards.Heros;

namespace AmpLib.TCG.Mechanics
{
    public static class Draw
    {
        /// <summary>
        /// Draws three cards.
        /// </summary>
        /// <param name="hero">The hero that will be drawing cards.</param>
        /// <returns></returns>
        public static void FirstDraw(Hero hero)
        {
            hero.Hand.AddRange(hero.Deck.GetRange(0, 3));
            hero.Deck.RemoveRange(0, 3);
        }

        /// <summary>
        /// Draw a specified amount of cards.
        /// </summary>
        /// <param name="hero">The hero to draw.</param>
        /// <param name="drawAmount">The amount to draw.</param>
        public static void DrawCards(Hero hero, int drawAmount = 1)
        {
            hero.Hand.AddRange(hero.Deck.GetRange(0, drawAmount));
            hero.Deck.RemoveRange(0, drawAmount);
        }

       
    }
}