namespace AmpLib.TCG.Cards
{
    public enum RarityEnum { White = 0, Blue = 1, Purple = 2, Orange = 3, Red = 4 }

    public abstract class Card
    {
        public string Name { get; set; }
        public int Cost { get; set; }
        public RarityEnum Rarity { get; set; }
    }
}