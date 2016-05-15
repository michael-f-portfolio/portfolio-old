using AmpLib.MessingAround.TCG.Cards;

namespace AmpLib.MessingAround.TCG.Actions
{
    public interface IEffect
    {
        /// <summary>
        /// Calculates the amount of damage a spell card has done to a 
        /// defending card.
        /// </summary>
        /// <param name="spellCard">The spell card being used to attack.</param>
        /// <param name="defender">The defending card.</param>
        /// <returns>The amount of damage caused.</returns>
        int SpellAttack(SpellCard spellCard, Card defender);
    }
}