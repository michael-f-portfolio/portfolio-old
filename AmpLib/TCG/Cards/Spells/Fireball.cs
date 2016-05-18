using AmpLib.TCG.Mechanics;

namespace AmpLib.TCG.Cards.Spells
{
    public class Fireball : DamageSpellCard
    {
        public Fireball()
        {
            Name = "Fireball";
            Cost = 4;
            Damage = 6;
            Rarity = RarityEnum.Blue;
        }
    }
}