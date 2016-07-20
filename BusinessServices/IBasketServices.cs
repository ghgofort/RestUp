using BusinessEntities;
using System.Collections.Generic;

namespace BusinessServices
{
    /// <summary>
    /// Contract for Basket Services from API
    /// </summary>
    public interface IBasketServices
    {
        BasketEntity GetBasketById(int basketId);
        IEnumerable<BasketEntity> GetBasketList();
        int CreateBasket(BasketEntity basketEntity);
        bool UpdateBasket(int basketId, BasketEntity basketEntity);
        bool DeleteBasket(int basketId);
    }
}
