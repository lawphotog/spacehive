using System.Collections.Generic;
using spacehive.domain;

namespace spacehive.interfaces
{
    public interface IGoodsService
    {
        public List<Goods> GetAllGoods(GetGoodsRequest request);
    }
}
