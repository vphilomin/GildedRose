using System.Collections.Generic;

namespace GildedRose.Console
{
    public class Program
    {
        public IList<Item> Items;

        private static void Main(string[] args)
        {
            System.Console.WriteLine("OMGHAI!");

            var app = new Program
                {
                    Items = new List<Item>
                        {
                            new RegularItem {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                            new AgedBrieItem {Name = "Aged Brie", SellIn = 2, Quality = 0},
                            new RegularItem {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                            new SulfurasItem {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                            new BackstagePassItem
                                {
                                    Name = "Backstage passes to a TAFKAL80ETC concert",
                                    SellIn = 15,
                                    Quality = 20
                                },
                            new ConjuredItem {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
                        }
                };

            app.UpdateQuality();

            System.Console.ReadKey();
        }

        public void UpdateQuality()
        {
            foreach (Item item in Items)
            {
                ((OverridableItem) item).UpdateQuality();
            }
        }
    }

    public class Item
    {
        public string Name { get; set; }

        public int SellIn { get; set; }

        public int Quality { get; set; }
    }

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

    public class SulfurasItem : OverridableItem
    {
        public override void UpdateQuality()
        {
        }
    }

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