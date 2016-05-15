using AmpLib.MessingAround.TCG.Actions;

namespace AmpLib.MessingAround.TCG.Cards
{
    public class SpellCard : Card, IAttackable, IEffect
    {
        public int UnopposedAttack(MinionCard defender)
        {
            throw new System.NotImplementedException();
        }

        public int AttackMinion(MinionCard defender)
        {
            throw new System.NotImplementedException();
        }

        public int SpellAttack(SpellCard spellCard, Card defender)
        {
            throw new System.NotImplementedException();
        }
    }
}