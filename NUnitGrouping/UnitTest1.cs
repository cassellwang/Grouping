using FluentAssertions;
using NUnit.Framework;
using NUnitGrouping;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Tests
{
    public class Tests
    {
        private GroupingService groupingService = new GroupingService();

        private List<Order> orders = new List<Order>() {
            new Order() { Id = 1, Cost = 10, Price = 130 },
            new Order() { Id = 2, Cost = 21, Price = 150 },
            new Order() { Id = 3, Cost = 32, Price = 200 },
            new Order() { Id = 4, Cost = 43, Price = 220 },
            new Order() { Id = 5, Cost = 54, Price = 250 },
            new Order() { Id = 6, Cost = 65, Price = 260 },
            new Order() { Id = 7, Cost = 76, Price = 300 },
            new Order() { Id = 8, Cost = 87, Price = 410 },
            new Order() { Id = 9, Cost = 98, Price = 660 },
            new Order() { Id = 10, Cost = 109, Price = 730 },
        };

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ErrorGroupSize()
        {
            Action act = () => groupingService.Grouping(orders, -1, x => x.Cost).ToList();
            act.Should().Throw<System.ArgumentException>().WithMessage("size should >0");
        }

        [Test]
        public void GroupOrderCostBySize3()
        {
            var excepted = new List<int> { 63, 162, 261, 109 };
            Assert.AreEqual(excepted, groupingService.Grouping(orders, 3, x => x.Cost));
        }

        [Test]
        public void GroupOrderPriceBySize4()
        {
            var excepted = new List<int> { 700, 1220, 1390 };
            Assert.AreEqual(excepted, groupingService.Grouping(orders, 4, p => p.Price));
        }

        [Test]
        public void GroupProductCostBySize3()
        {
            List<Product> products = new List<Product>() {
            new Product() { Id = 1, Cost = 10 },
            new Product() { Id = 2, Cost = 21 },
            new Product() { Id = 3, Cost = 32 },
            new Product() { Id = 4, Cost = 43 },
            new Product() { Id = 5, Cost = 54 },
            new Product() { Id = 6, Cost = 65 },
            new Product() { Id = 7, Cost = 76 },
            new Product() { Id = 8, Cost = 87 },
            new Product() { Id = 9, Cost = 98 },
            new Product() { Id = 10, Cost = 109 },
        };

            var excepted = new List<int> { 63, 162, 261, 109 };
            Assert.AreEqual(excepted, groupingService.Grouping(products, 3, x => x.Cost));
        }
    }
}