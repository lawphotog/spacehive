using System.Collections.Generic;
using spacehive.domain;

namespace spacehive.interfaces
{
    public interface IGoodsRepository
    {
        List<Goods> GetAllGoods();
    }
}
