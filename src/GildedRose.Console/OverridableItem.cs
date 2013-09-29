namespace GildedRose.Console
{
    public abstract class OverridableItem : Item
    {
        public abstract void UpdateQuality();

        protected void DecreaseQualityBy(int decrement)
        {
            if (Quality > 0)
                Quality -= decrement;
        }

        protected void IncreaseQualityBy(int increment)
        {
            if (Quality < 50)
                Quality += increment;
        }
    }
}