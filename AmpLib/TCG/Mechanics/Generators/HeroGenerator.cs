using System.Collections.Generic;
using AmpLib.TCG.Cards;
using AmpLib.TCG.Cards.Heros;
using AmpLib.TCG.Decks;

namespace AmpLib.TCG.Mechanics.Generators
{
    public static class HeroGenerator
    {
        /// <summary>
        /// Generates a Mage Hero.
        /// </summary>
        /// <returns>A fully instantiated Hero(Mage).</returns>
        public static Hero GenerateMage()
        {
            return new Hero
            {
                Name = "Mage",
                MaxHealth = 30,
                CurrentHealth = 30,
                MaxMana = 10,
                CurrentMana = 1,
                Deck = DeckGenerator.GetMageDeck(),
                Hand = new List<Card>()
            };
        }
    }
}