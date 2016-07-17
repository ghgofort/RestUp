using System;
using System.Transactions;
using System.Collections.Generic;
using BusinessEntities;
using DataEntities;
using DataEntities.UnitOfWork;
using AutoMapper;
using System.Linq;

namespace BusinessServices
{
    /// <summary>
    /// Class for querying the DAL for Basket specific CRUD operations
    /// </summary>
    class BasketServices : IBasketServices
    {
        private readonly UnitOfWork _unitOfWork;
        /// <summary>
        /// Public Constructor
        /// </summary>
        public BasketServices()
        {
            _unitOfWork = new UnitOfWork();
        }

        /// <summary>
        /// CRUD operation CREATE
        /// </summary>
        /// <param name="basketEntity"></param>
        /// <returns></returns>
        public int CreateBasket(BasketEntity basketEntity)
        {
            using (var scope = new TransactionScope())
            {
                var basket = new Basket
                {
                    BasketDescription = basketEntity.BasketDescription,
                    BasketName = basketEntity.BasketName,
                    BasketTheme = basketEntity.BasketTheme,
                    BasketValue = basketEntity.BasketValue,
                    Department = basketEntity.Department,
                    StartingBid = basketEntity.StartingBid
                };
                _unitOfWork.BasketRepository.Insert(basket);
                _unitOfWork.Save();
                scope.Complete();
                return basket.BasketId;
            }
        }

        /// <summary>
        /// CRUD operation DELETE
        /// </summary>
        /// <param name="basketId"></param>
        /// <returns></returns>
        public bool DeleteBasket(int basketId)
        {
            var success = false;
            if (basketId > 0)
            {
                using (var scope = new TransactionScope())
                {
                    var basket = _unitOfWork.BasketRepository.GetByID(basketId);
                    if (basket != null)
                    {

                        _unitOfWork.BasketRepository.Delete(basket);
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
        /// <param name="basketId"></param>
        /// <returns></returns>
        public BasketEntity GetBasketById(int basketId)
        {
            var basket = _unitOfWork.BasketRepository.GetByID(basketId);
            if (basket != null)
            {
                var basketModel = Mapper.Map<Basket, BasketEntity>(basket);
                return basketModel;
            }
            return null;
        }

        /// <summary>
        /// CRUD operation READ for the list of Baskets
        /// </summary>
        /// <returns></returns>
        public IEnumerable<BasketEntity> GetBasketList()
        {
            var baskets = _unitOfWork.BasketRepository.GetAll().ToList();
            if(baskets.Any())
            {
                var basketsModel = Mapper.Map<List<Basket>, List<BasketEntity>>(baskets);
                return basketsModel;
            }
            return null;

        }

        /// <summary>
        /// CRUD operation UPDATE
        /// </summary>
        /// <param name="basketId"></param>
        /// <param name="basketEntity"></param>
        /// <returns></returns>
        public bool UpdateBasket(int basketId, BasketEntity basketEntity)
        {
            var success = false;
            if (basketEntity != null)
            {
                using (var scope = new TransactionScope())
                {
                    var basket = _unitOfWork.BasketRepository.GetByID(basketId);
                    if (basket != null)
                    {
                        basket.BasketDescription = basketEntity.BasketDescription;
                        basket.BasketName = basketEntity.BasketName;
                        basket.BasketTheme = basketEntity.BasketTheme;
                        basket.BasketValue = basketEntity.BasketValue;
                        basket.Department = basketEntity.Department;
                        basket.StartingBid = basketEntity.StartingBid;
                        _unitOfWork.BasketRepository.Update(basket);
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
