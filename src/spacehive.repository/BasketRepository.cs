using System.Collections.Generic;
using spacehive.domain;
using spacehive.interfaces;
using System.Linq;

namespace spacehive.repository
{
    public class BasketRepository: IBasketRepository
    {
        private List<Basket> _baskets;

        public BasketRepository()
        {
            _baskets = new List<Basket>();
        }

        public Basket GetBasket(int basketId)
        {
            var basket = _baskets.Where(b => b.BasketId == basketId).FirstOrDefault();

            if (basket == null)
            {
                basket = new Basket()
                {
                    BasketId = basketId
                };

                _baskets.Add(basket);
            }

            return basket;
        }

        public Exception UpdateBasket(Basket basket)
        {
            var found = _baskets.Where(b => b.BasketId == basket.BasketId).FirstOrDefault();

            if (found == null) 
            {
                return new Exception("basket not found");
            }

            found.Goods = basket.Goods;

            return null;
        }
    }
}
