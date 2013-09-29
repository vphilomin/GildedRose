namespace GildedRose.Console
{
    public class RegularItem : OverridableItem
    {
        public override void UpdateQuality()
        {
            DecreaseQualityBy(1);
            SellIn -= 1;
            if (SellIn < 0)
                DecreaseQualityBy(1);
        }
    }
}