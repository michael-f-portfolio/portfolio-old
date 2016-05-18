using System;
using AmpLib.TCG.Mechanics;

namespace AmpLib.TCG.Cards.Spells
{
    public class ShieldsUp : BuffSpellCard
    {
        public ShieldsUp()
        {
            Name = "Shields Up!";
            Cost = 2;
            Buff = new Tuple<int, int>(0, 2);
            Rarity = RarityEnum.Blue;
        }
    }
}