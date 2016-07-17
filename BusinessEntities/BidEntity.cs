using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    class BidEntity
    {
        public int BidId { get; set; }
        public int BidAmount { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string ContactInfo { get; set; }
        public int BasketId { get; set; }
        public byte[] BidTime { get; set; }
    }
}
