using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class BasketItemEntity
    {
        public int BasketItemId { get; set; }
        public string ItemName { get; set; }
        public int BasketId { get; set; }
        public byte[] BidTime { get; set; }
    }
}
