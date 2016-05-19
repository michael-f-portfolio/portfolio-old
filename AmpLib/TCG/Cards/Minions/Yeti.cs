namespace AmpLib.TCG.Cards.Minions
{
    public sealed class Yeti : MinionCard
    {
        public const int Id = 3;

        public override int Attack { get; set; }
        public override int MaxAttack { get; set; }
        public override int Health { get; set; }
        public override int MaxHealth { get; set; }

        public Yeti()
        {
            Name = "Yeti";
            Cost = 4;
            Attack = MaxAttack = 4;
            Health = MaxAttack = 5;
            Rarity = RarityEnum.White;
            IsAlive = true;
        }
    }
}