using System;
using System.Collections.Generic;
using spacehive.domain;
using spacehive.interfaces;

namespace spacehive.repository
{
    public class GoodsRepository: IGoodsRepository
    {
        private readonly List<Goods> _goods;
        public GoodsRepository()
        {
            _goods = new List<Goods>()
            {
                new Goods { GoodsId = 1, Name = "Soup", Price = 0.65 },
                new Goods { GoodsId = 2, Name = "Bread", Price = 0.80 },
                new Goods { GoodsId = 3, Name = "Milk", Price = 1.15 },
                new Goods { GoodsId = 4, Name = "Apples", Price = 1.00 },
            };
        }

        public List<Goods> GetAllGoods()
        {
            return _goods;
        }
    }
}
