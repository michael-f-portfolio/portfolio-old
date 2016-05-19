using AmpLib.TCG.Mechanics;
using AmpLib.TCG.Mechanics.Actions;

namespace AmpLib.TCG.Cards
{
    public abstract class MinionCard : Card, ICanAttack, ICanDefend
    {
        public abstract int Attack { get; set; }
        public abstract int MaxAttack { get; set; }

        public abstract int Health { get; set; }
        public abstract int MaxHealth { get; set; }


        public bool IsAlive { get; set; }

        public static BattleResults operator -(MinionCard attacker, MinionCard defender)
        {
            var defenderHealth = defender.Health - attacker.Attack;
            var attackerHealth = attacker.Health - defender.Attack;
            
            defender.Health = defenderHealth;
            attacker.Health = attackerHealth;

            return new BattleResults
            {
                Attacker = attacker,
                Defender = defender
            };
        }

        public virtual BattleResults UnopposedAttack(MinionCard defender)
        {
            throw new System.NotImplementedException();
        }

        public virtual BattleResults AttackMinion(MinionCard defender)
        {
            var results = this - defender;

            if (this.Health <= 0) this.IsAlive = false;
            if (defender.Health <= 0) defender.IsAlive = false;

            return results;
        }

        public virtual int Defend(MinionCard attacker)
        {
            throw new System.NotImplementedException();
        }

        public override string ToString()
        {
            return $"Name: {Name}\tAttack: {Attack}\tHealth: {Health}\tIsAlive: {IsAlive}\tRarity: {Rarity}";
        }
    }
}