using System.Collections.Generic;
using BusinessEntities;

namespace BusinessServices
{
    /// <summary>
    /// The contract for API calls to the BasketItem methods                                                                                           
    /// </summary>
    public interface IBasketItemServices
    {
        BasketItemEntity GetBasketItemById(int baskeItemtId);
        IEnumerable<BasketItemEntity> GetBasketItemList();
        int CreateBasketItem(BasketItemEntity basketItemEntity);
        bool UpdateBasketItem(int basketItemId, BasketItemEntity basketItemEntity);
        bool DeleteBasketItem(int basketItemId);
    }
}
