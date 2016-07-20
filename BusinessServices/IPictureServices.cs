using BusinessEntities;
using System.Collections.Generic;

namespace BusinessServices
{
    /// <summary>
    /// Contract for Picture Services from the API
    /// </summary>
    public interface IPictureServices
    {
        PictureEntity GetPictureById(int pictureId);
        IEnumerable<PictureEntity> GetPictureList();
        int CreateBasket(PictureEntity pictureEntity);
        bool UpdateBasket(int pictureId, PictureEntity pictureEntity);
        bool DeleteBasket(int pictureId);
    }
}
