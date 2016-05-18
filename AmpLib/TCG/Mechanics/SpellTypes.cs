using System;
using AmpLib.TCG.Cards;

namespace AmpLib.TCG.Mechanics
{
    public class BuffSpellCard : SpellCard
    {
        public const string Type = "BUFF";
        public Tuple<int, int> Buff { get; set; }
    }

    public class DamageSpellCard : SpellCard
    {
        public const string Type = "DAMAGE";
        public int Damage { get; set; }
    }

    public class HealSpellCard : SpellCard
    {
        public const string Type = "HEAL";
        public int Heal { get; set; }
    }
}