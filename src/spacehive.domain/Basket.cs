using System.Collections.Generic;

namespace spacehive.domain
{
    public class Basket
    {
        public int BasketId { get; set; }
        public double Total {
            get
            {
                double sum = 0;
                foreach (var item in Goods)
                {
                    sum += item.Price;
                }
                return sum;
            }
        }
        public List<Goods> Goods { get; set; } = new List<Goods>();
    }

    public class GetBasketRequest
    {
        public string SelectedCurrency { get; set; }
        public int BasketId { get; set; }
    }

    public class GetBasketResponse
    {
        public Basket Basket { get; set; }
    }

    public class AddBasketRequest
    {
        public int BasketId { get; set; }
        public int GoodsId { get; set; }
    }

    public class RemoveBasketRequest
    {
        public int BasketId { get; set; }
        public int GoodsId { get; set; }
    }
}
