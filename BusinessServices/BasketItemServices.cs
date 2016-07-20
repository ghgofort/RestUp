using System.Transactions;
using System.Collections.Generic;
using BusinessEntities;
using DataEntities;
using DataEntities.UnitOfWork;
using AutoMapper;
using System.Linq;

namespace BusinessServices
{
    public class BasketItemServices
    {
        private readonly UnitOfWork _unitOfWork;
        /// <summary>
        /// Public Constructor
        /// </summary>
        public BasketItemServices(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// CRUD operation CREATE
        /// </summary>
        /// <param name="basketItemEntity"></param>
        /// <returns></returns>
        public int CreateBasketItem(BasketItemEntity basketItemEntity)
        {
            using (var scope = new TransactionScope())
            {
                var basketItem = new BasketItem
                {
                    BasketItemId = basketItemEntity.BasketItemId,
                    ItemName = basketItemEntity.ItemName,
                    BasketId = basketItemEntity.BasketId,
                    BidTime = basketItemEntity.BidTime
                };
                _unitOfWork.BasketItemRepository.Insert(basketItem);
                _unitOfWork.Save();
                scope.Complete();
                return basketItem.BasketItemId;
            }
        }

        /// <summary>
        /// CRUD operation DELETE
        /// </summary>
        /// <param name="basketItemId"></param>
        /// <returns></returns>
        public bool DeleteBasketItem(int basketItemId)
        {
            var success = false;
            if (basketItemId > 0)
            {
                using (var scope = new TransactionScope())
                {
                    var basketItem = _unitOfWork.BasketItemRepository.GetByID(basketItemId);
                    if (basketItem != null)
                    {

                        _unitOfWork.BasketItemRepository.Delete(basketItem);
                        _unitOfWork.Save();
                        scope.Complete();
                        success = true;
                    }
                }
            }
            return success;
        }

        /// <summary>
        /// CRUD operation READ for one Basket
        /// </summary>
        /// <param name="basketItemId"></param>
        /// <returns></returns>
        public BasketItemEntity GetBasketItemById(int basketItemId)
        {
            var basketItem = _unitOfWork.BasketItemRepository.GetByID(basketItemId);
            if (basketItem != null)
            {
                var basketItemModel = Mapper.Map<BasketItem, BasketItemEntity>(basketItem);
                return basketItemModel;
            }
            return null;
        }

        /// <summary>
        /// CRUD operation READ for the list of Baskets
        /// </summary>
        /// <returns></returns>
        public IEnumerable<BasketItemEntity> GetBasketItemList()
        {
            var basketItems = _unitOfWork.BasketItemRepository.GetAll().ToList();
            if (basketItems.Any())
            {
                var basketItemsModel = Mapper.Map<List<BasketItem>, List<BasketItemEntity>>(basketItems);
                return basketItemsModel;
            }
            return null;

        }

        /// <summary>
        /// CRUD operation UPDATE
        /// </summary>
        /// <param name="basketItemId"></param>
        /// <param name="basketItemEntity"></param>
        /// <returns></returns>
        public bool UpdateBasketItem(int basketItemId, BasketItemEntity basketItemEntity)
        {
            var success = false;
            if (basketItemEntity != null)
            {
                using (var scope = new TransactionScope())
                {
                    var basketItem = _unitOfWork.BasketItemRepository.GetByID(basketItemId);
                    if (basketItem != null)
                    {
                        basketItem.BasketItemId = basketItemEntity.BasketItemId;
                        basketItem.ItemName = basketItemEntity.ItemName;
                        basketItem.BasketId = basketItemEntity.BasketId;
                        basketItem.BidTime = basketItemEntity.BidTime;
                        _unitOfWork.BasketItemRepository.Update(basketItem);
                        _unitOfWork.Save();
                        scope.Complete();
                        success = true;
                    }
                }
            }
            return success;
        }
    }
}
