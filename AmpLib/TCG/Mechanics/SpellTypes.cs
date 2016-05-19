using System;
using AmpLib.TCG.Cards;

namespace AmpLib.TCG.Mechanics
{
    public class BuffSpellCard : SpellCard
    {
        public const string Type = "BUFF";
        public Tuple<int, int> Buff { get; set; }

        public override string ToString()
        {
            return $"Name: {Name}\t Cost: {Cost}\t Type: {Type}\t Buff: {Buff}\t Rarity: {Rarity}";
        }
    }

    public class DamageSpellCard : SpellCard
    {
        public const string Type = "DAMAGE";
        public int Damage { get; set; }

        public override string ToString()
        {
            return $"Name: {Name}\t Cost: {Cost}\t Type: {Type}\t Damage: {Damage}\t Rarity: {Rarity}";
        }
    }

    public class HealSpellCard : SpellCard
    {
        public const string Type = "HEAL";
        public int Heal { get; set; }

        public override string ToString()
        {
            return $"Name: {Name}\t Cost: {Cost}\t Type: {Type}\t Heal: {Heal}\t Rarity: {Rarity}";
        }
    }
}