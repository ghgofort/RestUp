using System.Transactions;
using System.Collections.Generic;
using BusinessEntities;
using DataEntities;
using DataEntities.UnitOfWork;
using AutoMapper;
using System.Linq;

namespace BusinessServices
{
    public class BidServices : IBidServices
    {
        private readonly UnitOfWork _unitOfWork;
        
        /// <summary>
        /// Public constructor for the BidServices class
        /// </summary>
        /// <param name="unitOfWork"></param>
        public BidServices(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// CRUD operation for creating a new bid
        /// </summary>
        /// <param name="bidEntity"></param>
        /// <returns></returns>
        public int Createbid(BidEntity bidEntity)
        {
            using (var scope = new TransactionScope())
            {
                var bid = new Bid
                {
                    BidId = bidEntity.BidId,
                    BidAmount = bidEntity.BidAmount,
                    BidTime = bidEntity.BidTime,
                    BasketId = bidEntity.BasketId,
                    ContactInfo = bidEntity.ContactInfo,
                    FName = bidEntity.FName,
                    LName = bidEntity.LName
                };
                _unitOfWork.BidRepository.Insert(bid);
                _unitOfWork.Save();
                scope.Complete();
                return bid.BidId;
            }

        }

        /// <summary>
        /// CRUD operation to delete a bid from the database
        /// </summary>
        /// <param name="bidId"></param>
        /// <returns></returns>
        public bool Deletebid(int bidId)
        {
            var success = false;
            if (bidId > 0)
            {
                using (var scope = new TransactionScope())
                {
                    var bid = _unitOfWork.BidRepository.GetByID(bidId);
                    if (bid != null)
                    {

                        _unitOfWork.BidRepository.Delete(bid);
                        _unitOfWork.Save();
                        scope.Complete();
                        success = true;
                    }
                }
            }
            return success;
        }

        /// <summary>
        /// CRUD operation to get the Bid by its Id
        /// </summary>
        /// <param name="bidId"></param>
        /// <returns></returns>
        public BidEntity GetbidById(int bidId)
        {
            var bid = _unitOfWork.BidRepository.GetByID(bidId);
            if (bid != null)
            {
                var bidModel = Mapper.Map<Bid, BidEntity>(bid);
                return bidModel;
            }
            return null;
        }

        /// <summary>
        /// CRUD operation to get the list of all bids
        /// </summary>
        /// <returns></returns>
        public IEnumerable<BidEntity> GetbidList()
        {
            var bids = _unitOfWork.BidRepository.GetAll().ToList();
            if (bids.Any())
            {
                var bidsModel = Mapper.Map<List<Bid>, List<BidEntity>>(bids);
                return bidsModel;
            }
            return null;
        }

        /// <summary>
        /// CRUD operation to update a Bid
        /// </summary>
        /// <param name="bidId"></param>
        /// <param name="bidEntity"></param>
        /// <returns></returns>
        public bool Updatebid(int bidId, BidEntity bidEntity)
        {
            var success = false;
            if (bidEntity != null)
            {
                using (var scope = new TransactionScope())
                {
                    var bid = _unitOfWork.BidRepository.GetByID(bidId);
                    if (bid != null)
                    {
                        bid.BidId = bidEntity.BidId;
                        bid.BidAmount = bidEntity.BidAmount;
                        bid.BidTime = bidEntity.BidTime;
                        bid.BasketId = bidEntity.BasketId;
                        bid.ContactInfo = bidEntity.ContactInfo;
                        bid.FName = bidEntity.FName;
                        bid.LName = bidEntity.LName;
                        _unitOfWork.BidRepository.Update(bid);
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
