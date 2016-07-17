using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    class BasketEntity
    {
        public int BasketId { get; set; }
        public string BasketName { get; set; }
        public string BasketDescription { get; set; }
        public string BasketTheme { get; set; }
        public string Department { get; set; }
        public Nullable<int> BasketValue { get; set; }
        public int StartingBid { get; set; }
        public int BidIncriment { get; set; }
        public byte[] BidTime { get; set; }
    }
}
