using System.Collections.Generic;

namespace spacehive.domain
{
    public class Goods
    {
        public int GoodsId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
    }

    public class GetGoodsRequest
    {
        public string SelectedCurrency { get; set; }
    }

    public class GetGoodsResponse
    {
        public List<Goods> Goods { get; set; }
    }
}
