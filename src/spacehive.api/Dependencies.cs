namespace spacehive.api;

using spacehive.core;
using spacehive.interfaces;
using spacehive.repository;

public static class Dependencies
{
    public static void Configure(IServiceCollection services)
    {
        services.AddTransient<IGoodsService, GoodsService>();
        services.AddTransient<IBasketService, BasketService>();
        services.AddSingleton<IBasketRepository, BasketRepository>();
        services.AddSingleton<IGoodsRepository, GoodsRepository>();
        services.AddTransient<ICurrencyDataAPIClient, CurrencyDataAPIClient>();
    }
}
