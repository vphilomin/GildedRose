namespace GildedRose.Console
{
    public class BackstagePassItem : OverridableItem
    {
        public override void UpdateQuality()
        {
            IncreaseQualityBy(1);
            if (SellIn < 11)
                IncreaseQualityBy(1);
            if (SellIn < 6)
                IncreaseQualityBy(1);
            SellIn -= 1;
            if (SellIn < 0)
                Quality = 0;
        }
    }
}