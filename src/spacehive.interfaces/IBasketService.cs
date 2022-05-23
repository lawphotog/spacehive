using spacehive.domain;

namespace spacehive.interfaces
{
    public interface IBasketService
    {
        Basket GetBasket(GetBasketRequest request);
        Exception AddBasket(AddBasketRequest request);
        Exception RemoveBasket(RemoveBasketRequest request);
    }
}
