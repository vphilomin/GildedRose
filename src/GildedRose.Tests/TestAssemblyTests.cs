using System.Collections.Generic;
using GildedRose.Console;
using NUnit.Framework;

namespace GildedRose.Tests
{
    [TestFixture]
    public class TestAssemblyTests
    {
        private static Program CreateProgram(Item item)
        {
            return new Program
                {
                    Items = new List<Item>
                        {
                            item
                        }
                };
        }

        [Test]
        public void AgedBrieIncreasesInQualityTheOlderItGets()
        {
            const int qualityBefore = 10;
            Program app = CreateProgram(new AgedBrieItem {Name = "Aged Brie", SellIn = 2, Quality = qualityBefore});

            app.UpdateQuality();

            Assert.Greater(app.Items[0].Quality, qualityBefore);
        }

        [Test]
        public void AgedBrieIncreasesInQualityTwiceAsFastAfterSellByDateIsPassed()
        {
            Program app = CreateProgram(new AgedBrieItem {Name = "Aged Brie", SellIn = 0, Quality = 10});

            app.UpdateQuality();

            Assert.AreEqual(12, app.Items[0].Quality);
        }

        [Test]
        public void BackstagePassesIncreasesInQualityAsSellInApproaches()
        {
            const int qualityBefore = 20;
            Program app = CreateProgram(new BackstagePassItem
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 15,
                    Quality = qualityBefore
                });

            app.UpdateQuality();

            Assert.Greater(app.Items[0].Quality, qualityBefore);
            Assert.AreEqual(qualityBefore + 1, app.Items[0].Quality);
        }

        [Test]
        public void BackstagePassesQualityDropsToZeroAfterConcert()
        {
            Program app = CreateProgram(new BackstagePassItem
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 0,
                    Quality = 20
                });

            app.UpdateQuality();

            Assert.AreEqual(0, app.Items[0].Quality);
        }

        [Test]
        public void BackstagePassesQualityIncreasesBy2WhenThereAre10DaysOrLess()
        {
            Program app = CreateProgram(new BackstagePassItem
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 10,
                    Quality = 20
                });

            app.UpdateQuality();

            Assert.AreEqual(22, app.Items[0].Quality);
        }

        [Test]
        public void BackstagePassesQualityIncreasesBy3WhenThereAre5DaysOrLess()
        {
            Program app = CreateProgram(new BackstagePassItem
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 5,
                    Quality = 20
                });

            app.UpdateQuality();

            Assert.AreEqual(23, app.Items[0].Quality);
        }

        [Test]
        public void ConjuredItemsDegradeTwiceAsFastAsRegularItems()
        {
            Program app = CreateProgram(new ConjuredItem {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6});

            app.UpdateQuality();

            Assert.AreEqual(4, app.Items[0].Quality);
        }

        [Test]
        public void ConjuredItemsDegradeTwiceAsFastAsRegularItemsAfterSellByDatePassed()
        {
            Program app = CreateProgram(new ConjuredItem {Name = "Conjured Mana Cake", SellIn = 0, Quality = 6});

            app.UpdateQuality();

            Assert.AreEqual(2, app.Items[0].Quality);
        }

        [Test]
        public void LegendarySulfurasNeverDecreasesInQuality()
        {
            Program app = CreateProgram(new SulfurasItem {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80});

            app.UpdateQuality();

            Assert.AreEqual(80, app.Items[0].Quality);
        }

        [Test]
        public void LegendarySulfurasNeverHasToBeSold()
        {
            Program app =
                CreateProgram(new SulfurasItem {Name = "Sulfuras, Hand of Ragnaros", SellIn = 10, Quality = 80});

            app.UpdateQuality();

            Assert.AreEqual(10, app.Items[0].SellIn);
        }

        [Test]
        public void QualityDegradesTwiceAsFastAfterSellByDateHasPassed()
        {
            Program app = CreateProgram(new RegularItem {Name = "+5 Dexterity Vest", SellIn = 0, Quality = 20});

            app.UpdateQuality();

            Assert.AreEqual(18, app.Items[0].Quality);
        }

        [Test]
        public void QualityIsLoweredAtEndOfDay()
        {
            Program app = CreateProgram(new RegularItem {Name = "+5 Dexterity Vest", SellIn = 1, Quality = 20});

            app.UpdateQuality();

            Assert.AreEqual(19, app.Items[0].Quality);
        }

        [Test]
        public void QualityOfAnItemIsNeverMoreThan50_BackstagePasses()
        {
            Program app =
                CreateProgram(new BackstagePassItem
                    {
                        Name = "Backstage passes to a TAFKAL80ETC concert",
                        SellIn = 2,
                        Quality = 50
                    });

            app.UpdateQuality();

            Assert.LessOrEqual(app.Items[0].Quality, 50);
        }

        [Test]
        public void QualityOfAnItemIsNeverMoreThan50_Brie()
        {
            Program app = CreateProgram(new AgedBrieItem {Name = "Aged Brie", SellIn = 2, Quality = 50});

            app.UpdateQuality();

            Assert.LessOrEqual(app.Items[0].Quality, 50);
        }

        [Test]
        public void QualityOfAnItemIsNeverNegative()
        {
            Program app = CreateProgram(new RegularItem {Name = "+5 Dexterity Vest", SellIn = 0, Quality = 0});

            app.UpdateQuality();

            Assert.GreaterOrEqual(app.Items[0].Quality, 0);
        }

        [Test]
        public void SellInDateIsLoweredAtEndOfDay()
        {
            Program app = CreateProgram(new RegularItem {Name = "+5 Dexterity Vest", SellIn = 1, Quality = 20});

            app.UpdateQuality();

            Assert.AreEqual(0, app.Items[0].SellIn);
        }
    }
}