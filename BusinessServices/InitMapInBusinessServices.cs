using BusinessServices;
using System.Web;
using AutoMapper;
using BusinessEntities;
using DataEntities;

[assembly: PreApplicationStartMethod(typeof(InitMapInBusinessServices), "Init")]
namespace BusinessServices
{
    /// <summary>
    /// Class to initialize the Automapper associations that link the Business Entities to the Data Entities within the Business Services
    /// </summary>
    public class InitMapInBusinessServices
    {
        public static void Init()
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
