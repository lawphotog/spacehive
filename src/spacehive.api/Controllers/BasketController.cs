namespace spacehive.api.Controllers;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using spacehive.domain;
using spacehive.interfaces;

[ApiController]
[Route("[controller]/[action]")]
public class BasketController : ControllerBase
{
    private readonly ILogger<BasketController> _logger;
    private readonly IBasketService _basketService;

    public BasketController(
        ILogger<BasketController> logger,
        IBasketService basketService)
    {
        _logger = logger;
        _basketService = basketService;
    }

    [HttpGet]
    public GetBasketResponse Get(string selectedCurrency, int basketId)
    {
        var request = new GetBasketRequest()
        {
            SelectedCurrency = selectedCurrency,
            BasketId = basketId
        };

        return new GetBasketResponse()
        {
            Basket = _basketService.GetBasket(request)
        };
    }

    [HttpPost]
    public void Add(int basketId, int goodsId)
    {
        var request = new AddBasketRequest()
        {
            BasketId = basketId,
            GoodsId = goodsId
        };

        var err = _basketService.AddBasket(request);
        if (err != null)
        {
            throw new Exception("something bad happened");
        }
    }

    [HttpPost]
    public void Remove(int basketId, int goodsId)
    {
        var request = new RemoveBasketRequest()
        {
            BasketId = basketId,
            GoodsId = goodsId
        };

        var err = _basketService.RemoveBasket(request);
        if (err != null)
        {
            throw new Exception("something bad happened");
        }
    }
}
