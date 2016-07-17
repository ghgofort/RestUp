#region Using Namespaces...  

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Data.Entity.Validation;
using DataEntities.GenericRepository;

#endregion

namespace DataEntities.UnitOfWork
{
    /// <summary>  
    /// Unit of Work class responsible for DB transactions  
    /// </summary>  
    public class UnitOfWork : IDisposable
    {
        #region Private member variables...  

        private SADataConn _context = null;
        private GenericRepository<BasketItem> _basketItemRepository;
        private GenericRepository<Basket> _basketRepository;
        private GenericRepository<Bid> _bidRepository;
        private GenericRepository<Picture> _pictureRepository;
        #endregion

        public UnitOfWork()
        {
            _context = new SADataConn();
        }

        #region Public Repository Creation properties...  

        /// <summary>  
        /// Get/Set Property for Basket repository.  
        /// </summary>  
        public GenericRepository<Basket> BasketRepository
        {
            get
            {
                if (this._basketRepository == null)
                    this._basketRepository = new GenericRepository<Basket>(_context);
                return _basketRepository;
            }
        }

		/// <summary>
        /// Get/Set the Property for Picture Repository
        /// </summary>
        public GenericRepository<Picture> PictureRepository
        {
            get
            {
                if (this._pictureRepository == null)
                    this._pictureRepository = new GenericRepository<Picture>(_context);
                return _pictureRepository;
            }
        }


        /// <summary>  
        /// Get/Set Property for BasketItem repository.  
        /// </summary>  
        public GenericRepository<BasketItem> BasketItemRepository
        {
            get
            {
                if (this._basketItemRepository == null)
                    this._basketItemRepository = new GenericRepository<BasketItem>(_context);
                return _basketItemRepository;
            }
        }

        /// <summary>  
        /// Get/Set Property for Bid repository.  
        /// </summary>  
        public GenericRepository<Bid> BidRepository
        {
            get
            {
                if (this._bidRepository == null)
                    this._bidRepository = new GenericRepository<Bid>(_context);
                return _bidRepository;
            }
        }
        #endregion

        #region Public member methods...  
        /// <summary>  
        /// Save method.  
        /// </summary>  
        public void Save()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {

                var outputLines = new List<string>();
                foreach (var eve in e.EntityValidationErrors)
                {
                    outputLines.Add(string.Format("{0}: Entity of type \"{1}\" in state \"{2}\" has the following validation errors:", DateTime.Now, eve.Entry.Entity.GetType().Name, eve.Entry.State));
                    foreach (var ve in eve.ValidationErrors)
                    {
                        outputLines.Add(string.Format("- Property: \"{0}\", Error: \"{1}\"", ve.PropertyName, ve.ErrorMessage));
                    }
                }
                System.IO.File.AppendAllLines(@"C:\errors.txt", outputLines);

                throw e;
            }

        }

        #endregion

        #region Implementing IDiosposable...  

        #region private dispose variable declaration...  
        private bool disposed = false;
        #endregion

        /// <summary>  
        /// Protected Virtual Dispose method  
        /// </summary>  
        /// <param name="disposing"></param>  
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    Debug.WriteLine("UnitOfWork is being disposed");
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        /// <summary>  
        /// Dispose method  
        /// </summary>  
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}