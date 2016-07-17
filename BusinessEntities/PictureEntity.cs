using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    class PictureEntity
    {
        public int PictureId { get; set; }
        public string PictureLocation { get; set; }
        public int BasketId { get; set; }
        public byte[] BidTime { get; set; }
    }
}
