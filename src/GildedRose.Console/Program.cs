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
}