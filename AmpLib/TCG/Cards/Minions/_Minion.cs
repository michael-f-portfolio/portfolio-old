namespace AmpLib.TCG.Cards.Minions
{
    public class _Minion : MinionCard
    {
        public const int Id = -1;

        public override int Attack { get; set; }
        public override int MaxAttack { get; set; }
        public override int Health { get; set; }
        public override int MaxHealth { get; set; }
    }
}