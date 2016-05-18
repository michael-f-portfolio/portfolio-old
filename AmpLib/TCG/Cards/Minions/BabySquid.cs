namespace AmpLib.TCG.Cards.Minions
{
    public sealed class BabySquid : MinionCard
    {
        public const int Id = 2;

        public override int Attack { get; set; }
        public override int MaxAttack { get; set; }
        public override int Health { get; set; }
        public override int MaxHealth { get; set; }

        public BabySquid()
        {
            Name = "Baby Squid";
            Attack = 2;
            MaxAttack = 2;
            Health = 1;
            MaxHealth = 1;
            Rarity = RarityEnum.White;
            IsAlive = true;
        }
    }
}