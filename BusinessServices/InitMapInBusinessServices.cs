using BusinessServices;
using System.Web;
using AutoMapper;
using BusinessEntities;
using DataEntities;

[assembly: PreApplicationStartMethod(typeof(InitMapInBusinessServices), "Init")]
namespace BusinessServices
{
    
    class InitMapInBusinessServices
    {
        static void Init()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Basket, BasketEntity>();
                cfg.CreateMap<BasketItem, BasketItemEntity>();
                cfg.CreateMap<Picture, PictureEntity>();
                cfg.CreateMap<Bid, BidEntity>();
            });
        }
    }
}
