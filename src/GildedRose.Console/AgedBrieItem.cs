namespace GildedRose.Console
{
    public class AgedBrieItem : OverridableItem
    {
        public override void UpdateQuality()
        {
            IncreaseQualityBy(1);
            SellIn -= 1;
            if (SellIn < 0)
                IncreaseQualityBy(1);
        }
    }
}