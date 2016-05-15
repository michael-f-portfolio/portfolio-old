using AmpLib.MessingAround.TCG.Cards;

namespace AmpLib.MessingAround.TCG.Actions
{
    public interface IAttackable
    {
        /// <summary>
        /// Attacks a target who is not able to defend.
        /// </summary>
        /// <param name="attacker">The card being attacked.</param>
        /// <param name="defender">The defending card.</param>
        /// <returns>The amount of damage dealt.</returns>
        int UnopposedAttack(MinionCard defender);

        /// <summary>
        /// Attacks a target who is able to retaliate.
        /// </summary>
        /// <param name="attacker">The attacking card.</param>
        /// <param name="defender">The defending card.</param>
        /// <returns>The amount of damage dealt to the defender.</returns>
        int AttackMinion(MinionCard defender);
    }
}