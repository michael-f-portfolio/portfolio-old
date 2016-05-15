using System;
using System.Diagnostics;
using AmpLib.MessingAround.TCG.Actions;

namespace AmpLib.MessingAround.TCG.Cards
{
    public abstract class MinionCard : Card, IAttackable, IDefendable
    {
        public abstract int Health { get; set; }
        public abstract int Attack { get; set; }
        public bool IsAlive { get; set; }

        public static MinionCard[] operator -(MinionCard attacker, MinionCard defender)
        {
            var defenderHealth = defender.Health - attacker.Attack;
            var attackerHealth = attacker.Health - defender.Attack;
            
            defender.Health = defenderHealth;
            attacker.Health = attackerHealth;

            return new[] {attacker, defender};
        }

        public virtual int UnopposedAttack(MinionCard defender)
        {
            throw new System.NotImplementedException();
        }

        public virtual int AttackMinion(MinionCard defender)
        {
            var results = this - defender;

            if (this.Health <= 0) this.IsAlive = false;
            if (defender.Health <= 0) defender.IsAlive = false;

            return 0;
        }

        public virtual int Defend(MinionCard attacker)
        {
            throw new System.NotImplementedException();
        }

        public override string ToString()
        {
            return $"Name: {Name}\nAttack: {Attack}\nHealth: {Health}\nIsAlive: {IsAlive}\nRarity: {Rarity}";
        }
    }
}