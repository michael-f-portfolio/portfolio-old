using System;
using AmpLib.TCG.Mechanics;
using AmpLib.TCG.Mechanics.Actions;

namespace AmpLib.TCG.Cards
{
    
    public class SpellCard : Card, ICanTarget
    {

        public virtual SpellResults TargetMinion(MinionCard target)
        {
            var card = this as DamageSpellCard;
            if (card != null)
            {
                var damageSpell = card;

                Console.WriteLine("I AM A DAMAGE SPELL = " + damageSpell.Damage);

                target.Health -= damageSpell.Damage;

                if (target.Health <= 0) target.IsAlive = false;

                return new SpellResults
                {
                    Target = target
                };
            }

            var spell = this as BuffSpellCard;
            if (spell != null)
            {
                var buffSpell = spell;

                Console.WriteLine("I AM A BUFF SPELL = " + buffSpell.Buff);

                var attackBuff = buffSpell.Buff.Item1;
                var healthBuff = buffSpell.Buff.Item2;

                target.Attack += attackBuff;
                target.MaxAttack += attackBuff;
                target.Health += healthBuff;
                target.MaxHealth += healthBuff;

                return new SpellResults
                {
                    Target = target
                };
            }

            var heal = this as HealSpellCard;
            if (heal != null)
            {
                var healSpell = heal;
                Console.WriteLine("I AM A HEAL SPELL = " + healSpell.Heal);

                var healAmount = healSpell.Heal;

                target.Health += healAmount;

                if (target.Health > target.MaxHealth) target.Health = target.MaxHealth;


                return new SpellResults
                {
                    Target = target
                };
            }

            return new SpellResults();
        }

    }

    
}