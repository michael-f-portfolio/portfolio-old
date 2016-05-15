namespace AmpLib.MessingAround.TCG.Cards.Minions
{
    public sealed class BabyDuck : MinionCard
    {
        public const int Id = 1;

        public override int Attack { get; set; }
        public override int Health { get; set; }

        public BabyDuck()
        {
            Name = "Baby Duck";
            Attack = 1;
            Health = 5;
            Rarity = RarityEnum.White;
            IsAlive = true;
        }
    }
}   