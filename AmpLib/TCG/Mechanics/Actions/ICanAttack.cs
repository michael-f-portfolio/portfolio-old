using AmpLib.TCG.Cards;

namespace AmpLib.TCG.Mechanics.Actions
{
    public interface ICanAttack
    {
        /// <summary>
        /// Attacks a target who is not able to defend.
        /// </summary>
        /// <param name="defender">The defending card.</param>
        /// <returns>The results of the two cards battling.</returns>
        BattleResults UnopposedAttack(MinionCard defender);

        /// <summary>
        /// Attacks a target who is able to retaliate.
        /// </summary>
        /// <param name="defender">The defending card.</param>
        /// <returns>The results of the two cards battling.</returns>
        BattleResults AttackMinion(MinionCard defender);
    }
}