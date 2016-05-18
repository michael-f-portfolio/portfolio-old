using AmpLib.TCG.Mechanics;

namespace AmpLib.TCG.Cards.Spells
{
    public class FlashHeal : HealSpellCard
    {
        public FlashHeal()
        {
            Name = "Flash Heal";
            Cost = 2;
            Heal = 5;
            Rarity = RarityEnum.White;
        }
    }
}