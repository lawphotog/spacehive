namespace spacehive.domain.tests;

using FluentAssertions;
using spacehive.domain;

public class BasketTests
{
    [Fact]
    public void Total_TotalShouldAddUp()
    {
        var basket = new Basket();
        basket.Goods.Add(new Goods() { Price = 1 });
        basket.Goods.Add(new Goods() { Price = 0.5 });

        basket.Total.Should().Be(1.5);
    }
}
