using AmpLib.TCG.Board;
using AmpLib.TCG.Decks;

namespace AmpLib.TCG.Cards.Heros
{
    public class MageHero : Hero
    {
        public MageDeck MageDeck { get; set; }

        public MageHero(string name, int totalHealth, int totalMana) : base(name, totalHealth, totalMana)
        {
            MageDeck = new MageDeck();
        }

        public override string ToString()
        {
            return base.ToString() + MageDeck;
        }
    }
}