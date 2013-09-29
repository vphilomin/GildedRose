namespace GildedRose.Console
{
    public class ConjuredItem : OverridableItem
    {
        public override void UpdateQuality()
        {
            DecreaseQualityBy(2);
            SellIn -= 1;
            if (SellIn < 0)
                DecreaseQualityBy(2);
        }
    }
}