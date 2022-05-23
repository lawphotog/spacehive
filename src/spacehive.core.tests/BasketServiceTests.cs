namespace spacehive.core.tests;

using spacehive.interfaces;
using Moq;
using FluentAssertions;
using spacehive.domain;

public class BasketServiceTests
{
    private IBasketService basketService;
    private Mock<IBasketRepository> basketRepository = new();
    private Mock<IGoodsRepository> goodsRepository = new();
    private Mock<ICurrencyDataAPIClient> currencyDataAPIClient = new();

    public BasketServiceTests()
    {
        basketService = new BasketService(basketRepository.Object, 
            goodsRepository.Object, 
            currencyDataAPIClient.Object);
    }

    [Fact]
    public void GetBasket_ShouldReturnBasket()
    {
        var basket = new Basket()
        {
            BasketId = 1,
            Goods = new List<Goods>()
        };
        basketRepository.Setup(a => a.GetBasket(It.IsAny<int>()))
                            .Returns(basket);

        var request = new GetBasketRequest()
        {
            SelectedCurrency = "usd",
            BasketId = 1
        };

        basket = basketService.GetBasket(request);
        basket.BasketId.Should().Be(1);
    }
}
