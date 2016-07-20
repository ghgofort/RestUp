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
    /// Class for querying the DAL for Picture entity specific CRUD operations
    /// </summary>
    class PictureServices
    {
        private readonly UnitOfWork _unitOfWork;
        /// <summary>
        /// Public Constructor
        /// </summary>
        public PictureServices(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// CRUD operation CREATE
        /// </summary>
        /// <param name="basketEntity"></param>
        /// <returns></returns>
        public int CreatePicture(PictureEntity pictureEntity)
        {
            using (var scope = new TransactionScope())
            {
                var picture = new Picture
                {
                    PictureId = pictureEntity.PictureId,
                    PictureLocation = pictureEntity.PictureLocation,
                    BasketId = pictureEntity.BasketId
                };
                _unitOfWork.PictureRepository.Insert(picture);
                _unitOfWork.Save();
                scope.Complete();
                return picture.PictureId;
            }
        }

        /// <summary>
        /// CRUD operation DELETE a picture
        /// </summary>
        /// <param name="pictureId"></param>
        /// <returns></returns>
        public bool DeletePicture(int pictureId)
        {
            var success = false;
            if (pictureId > 0)
            {
                using (var scope = new TransactionScope())
                {
                    var picture = _unitOfWork.PictureRepository.GetByID(pictureId);
                    if (picture != null)
                    {

                        _unitOfWork.PictureRepository.Delete(picture);
                        _unitOfWork.Save();
                        scope.Complete();
                        success = true;
                    }
                }
            }
            return success;
        }

        /// <summary>
        /// CRUD operation READ for one Picture
        /// </summary>
        /// <param name="pictureId"></param>
        /// <returns></returns>
        public PictureEntity GetPictureById(int pictureId)
        {
            var picture = _unitOfWork.PictureRepository.GetByID(pictureId);
            if (picture != null)
            {
                var pictureModel = Mapper.Map<Picture, PictureEntity>(picture);
                return pictureModel;
            }
            return null;
        }

        /// <summary>
        /// CRUD operation READ for the list of Pictures
        /// </summary>
        /// <returns></returns>
        public IEnumerable<PictureEntity> GetPictureList()
        {
            var pictures = _unitOfWork.PictureRepository.GetAll().ToList();
            if (pictures.Any())
            {
                var picturesModel = Mapper.Map<List<Picture>, List<PictureEntity>>(pictures);
                return picturesModel;
            }
            return null;
        }

        /// <summary>
        /// CRUD operation UPDATE
        /// </summary>
        /// <param name="pictureId"></param>
        /// <param name="pictureEntity"></param>
        /// <returns></returns>
        public bool UpdatePicture(int pictureId, PictureEntity pictureEntity)
        {
            var success = false;
            if (pictureEntity != null)
            {
                using (var scope = new TransactionScope())
                {
                    var picture = _unitOfWork.PictureRepository.GetByID(pictureId);
                    if (picture != null)
                    {
                        pictureEntity.PictureId = pictureEntity.PictureId;
                        pictureEntity.PictureLocation = pictureEntity.PictureLocation;
                        pictureEntity.BasketId = pictureEntity.BasketId;
                        _unitOfWork.PictureRepository.Update(picture);
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
