using spacehive.domain;

namespace spacehive.interfaces
{
    public interface IBasketRepository
    {
        Basket GetBasket(int basketId);
        Exception UpdateBasket(Basket basket);
    }
}
