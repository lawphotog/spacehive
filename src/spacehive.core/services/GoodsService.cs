namespace spacehive.core;

using System.Collections.Generic;
using spacehive.domain;
using spacehive.interfaces;

public class GoodsService: IGoodsService
{
    private readonly IGoodsRepository _goodsRepository;
    private readonly ICurrencyDataAPIClient _client;
    const string USD = "usd";
    public GoodsService(
        IGoodsRepository goodsRepository,
        ICurrencyDataAPIClient currencyDataAPIClient)
    {
        _goodsRepository = goodsRepository;
        _client = currencyDataAPIClient;
    }

    public List<Goods> GetAllGoods(GetGoodsRequest request)
    {
        var goods = _goodsRepository.GetAllGoods();

        if (request.SelectedCurrency != USD)
        {
            foreach (var item in goods)
            {
                item.Price = _client.Convert(request.SelectedCurrency, USD, item.Price);
            }
        }

        return goods;
    }
}

