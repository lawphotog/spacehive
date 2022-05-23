namespace spacehive.core;

using spacehive.domain;
using spacehive.interfaces;
using System.Linq;

public class BasketService: IBasketService
{
    private readonly IBasketRepository _basketRepository;
    private readonly IGoodsRepository _goodsRepository;
    private readonly ICurrencyDataAPIClient _client;
    const string USD = "usd";
    public BasketService(
        IBasketRepository basketRepository,
        IGoodsRepository goodsRepository,
        ICurrencyDataAPIClient currencyDataAPIClient)
    {
        _basketRepository = basketRepository;
        _goodsRepository = goodsRepository;
        _client = currencyDataAPIClient;
    }

    public Basket GetBasket(GetBasketRequest request)
    {
        var basket = _basketRepository.GetBasket(request.BasketId);
        if (request.SelectedCurrency.ToLower() != USD)
        {
            foreach (var item in basket.Goods)
            {
                item.Price = _client.Convert(request.SelectedCurrency, USD, item.Price);
            }
        }
        return basket;
    }

    public Exception AddBasket(AddBasketRequest request)
    {
        var basket = _basketRepository.GetBasket(request.BasketId);
        if (basket == null)
        {
            return new Exception("can't find a basket with the requested ID");
        }

        var goods = _goodsRepository.GetAllGoods()
            .Where(g => g.GoodsId == request.GoodsId)
            .FirstOrDefault();

        if (goods == null)
        {
            return new Exception("no goods with requested ID");
        }

        basket.Goods.Add(goods);

        var err = _basketRepository.UpdateBasket(basket);
        if (err != null)
        {
            return err;
        }

        return null;
    }
    public Exception RemoveBasket(RemoveBasketRequest request)
    {
        var basket = _basketRepository.GetBasket(request.BasketId);

        if (basket.Goods.Count() < 1)
        {
            return new Exception("the basket is null");
        }

        var goods = _goodsRepository.GetAllGoods()
            .Where(g => g.GoodsId == request.GoodsId)
            .FirstOrDefault();

        if (goods == null)
        {
            return new Exception("no goods with requested ID");
        }

        basket.Goods.Remove(goods);
        var err = _basketRepository.UpdateBasket(basket);
        if (err != null)
        {
            return err;
        }

        return null;
    }
}
