using BusinessEntities;
using System.Collections.Generic;

namespace BusinessServices
{
    /// <summary>
    /// Contract For Bid API methods
    /// </summary>
    public interface IBidServices
    {
        BidEntity GetbidById(int bidId);
        IEnumerable<BidEntity> GetbidList();
        int Createbid(BidEntity bidEntity);
        bool Updatebid(int bidId, BidEntity bidEntity);
        bool Deletebid(int bidId);
    }
}
