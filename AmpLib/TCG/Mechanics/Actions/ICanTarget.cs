using AmpLib.TCG.Cards;

namespace AmpLib.TCG.Mechanics.Actions
{

    public interface ICanTarget
    {
        SpellResults TargetMinion(MinionCard target);
    }
}