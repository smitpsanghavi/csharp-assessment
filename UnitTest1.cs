using CsvHelper;
using CsvHelper.Configuration.Attributes;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using Xunit;

namespace csharp_assessment
{
    public class CsvTests
    {
        public class PromotionRecord
        {
            /* PromotionKey,Promotion Code,Promotion,Discount,Promotion Type,Promotion Category,Start Date,End Date */

            public int PromotionKey { get; set; }
            [Name("Promotion Code")]
            public string PromotionCode { get; set; }
            public string Promotion { get; set; }
            public decimal Discount { get; set; }
            [Name("Promotion Type")]
            public string PromotionType { get; set; }
            [Name("Promotion Category")]
            public string PromotionCategory { get; set; }
            [Name("Start Date")]
            public DateTime StartDate { get; set; }
            [Name("End Date")]
            public DateTime EndDate { get; set; }
        }

        public static double? LookupPromotionDiscount(string region, DateTime date)
        {
            double? promotionDiscount = null;
            using (var reader = new StreamReader(ResourceHelper.GetResource("Promotion.csv")))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<PromotionRecord>();
                var promotion = records.FirstOrDefault(c => c.Promotion.ToLowerInvariant().Contains(region.ToLowerInvariant()) && c.StartDate <= date && date <= c.EndDate);
                promotionDiscount = promotion == null ? null as double? : Convert.ToDouble(promotion.Discount);
            }
            return promotionDiscount;
        }

        [Theory]
        [InlineData("Asia", "2007-12-01", 0.15)]
        [InlineData("Asia", "2008-10-31", null)]
        [InlineData("europe", "2008-01-01", 0.2)]
        [InlineData("europe", "2007-05-01", null)]
        [InlineData("North America", "2009-09-30", 0.1)]
        public void Test_LookupPromotionDiscount(string region, string date, double? expectedDiscount)
        {
            Assert.Equal(expectedDiscount, LookupPromotionDiscount(region, DateTime.ParseExact(date, "yyyy-MM-dd", CultureInfo.InvariantCulture)));
        }

        [Fact]
        public void Getting_28_records()
        {
            using (var reader = new StreamReader(ResourceHelper.GetResource("Promotion.csv")))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<PromotionRecord>();
                Assert.Equal(28, records.Count());
            }
        }

        [Fact]
        public void Aggregate_promotions()
        {
            using (var reader = new StreamReader(ResourceHelper.GetResource("Promotion.csv")))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                Assert.Equal(3.51m, csv.GetRecords<PromotionRecord>().Aggregate(0.0m, (acc, p) => acc + p.Discount));
            }
        }
    }

    public class JsonTests
    {
        public class Position
        {
            public int X { get; set; }
            public int Y { get; set; }
            public int Width { get; set; }
            public int Height { get; set; }
            public int Z { get; set; }
        }

        public readonly Dictionary<string, JObject> visualConfigs;

        public JsonTests()
        {
            using (var reader1 = new JsonTextReader(new StreamReader(ResourceHelper.GetResource("visualConfig.json"))))
            using (var reader2 = new JsonTextReader(new StreamReader(ResourceHelper.GetResource("visualConfig2.json"))))
            {
                visualConfigs = new Dictionary<string, JObject>
                {
                    { "1", JObject.Load(reader1) },
                    { "2", JObject.Load(reader2) },
                };
            }
        }

        public static Position GetPosition(JObject config)
        {
            if (config?["layouts"] is JArray layoutArray)
            {
                if (layoutArray.Any() && layoutArray[0]?["position"] is JObject positionObject)
                {
                    var position = positionObject.ToObject<Position>();
                    return position;
                }
            }
            return null;
        }

        public static string GetTitle(JObject config)
        {
            if (config?["singleVisual"]?["vcObjects"] is JObject vcObjects)
            {
                if (vcObjects["title"] is JArray title)
                {
                    if (title.Any())
                    {
                        var titleString = (string)title[0]?["properties"]?["text"]?["expr"]?["Literal"]?["Value"];
                        if (!string.IsNullOrEmpty(titleString))
                        {
                            var data = titleString[1..^1];
                            return data;
                        }
                    }
                }
            }
            return string.Empty;
        }

        public static string[] GetObjectNames(JObject config)
        {
            if (config?["singleVisual"]?["objects"] is JObject objects)
            {
                var keys = objects.Properties().Select(c => c.Name).ToArray();
                return keys;
            }
            return Array.Empty<string>();
        }

        [Theory]
        [InlineData("1", 0, 300, 60, 60, 41000)]
        [InlineData("2", 1233, 0, 47, 59, 37000)]
        public void Test_GetPosition(string id, int x, int y, int width, int height, int z)
        {
            var position = GetPosition(visualConfigs[id]);

            Assert.Equal(x, position.X);
            Assert.Equal(y, position.Y);
            Assert.Equal(width, position.Width);
            Assert.Equal(height, position.Height);
            Assert.Equal(z, position.Z);
        }

        [Theory]
        [InlineData("1", "Button P5")]
        [InlineData("2", "Slicers - Close Button")]
        public void Test_GetTitle(string id, string expectedTitle)
        {
            var title = GetTitle(visualConfigs[id]);

            Assert.Equal(expectedTitle, title);
        }

        public static IEnumerable<object[]> ExpectedObjectNames()
        {
            yield return new object[] { "1", new[] { "icon", "outline", "fill", "text" } };
            yield return new object[] { "2", new[] { "icon", "fill" } };
        }

        [Theory]
        [MemberData(nameof(ExpectedObjectNames))]
        public void Test_GetObjectNames(string id, string[] expectedNames)
        {
            var names = GetObjectNames(visualConfigs[id]);
            Assert.Equal(expectedNames, names);
        }
    }

    public static class ResourceHelper
    {
        public static Stream GetResource(string name) => typeof(ResourceHelper).Assembly.GetManifestResourceStream(typeof(ResourceHelper), name);
    }
}
