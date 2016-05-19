using System.Collections.Generic;
using System.Linq;

namespace AmpLib.TCG.Cards.Heros
{
    /// <summary>
    /// A Hero class which can be used to create more specific heros.
    /// </summary>
    public class Hero
    {
        public const int MaxHandSize = 10;
        public const int MaxDeckSize = 30;

        public string Name { get; set; }

        public int MaxHealth { get; set; }
        public int CurrentHealth { get; set; }

        public int MaxMana { get; set; }
        public int CurrentMana { get; set; }

        public List<Card> Hand { get; set; }
        public List<Card> Deck { get; set; }

        public override string ToString()
        {
            return
                $"Name: {Name}\nMaxHealth: {MaxHealth}, CurrentHealth: {CurrentHealth}\nMaxMana: {MaxMana}, CurrentMana: {CurrentMana}\nHand:\n{{\n{HandToString()}}}\nDeck:\n{{\n{DeckToString()}}}";
        }

        private string HandToString()
        {
            return Hand.Aggregate("", (current, card) =>  current + "\t"+card + "\n");
        }

        private string DeckToString()
        {
            return Deck.Aggregate("", (current, card) => current + "\t" + card + "\n");
        }
    }
}