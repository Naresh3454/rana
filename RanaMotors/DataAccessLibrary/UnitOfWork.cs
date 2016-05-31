using DataAccessLibrary.Models;
using DataAccessLibrary.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
    public class UnitOfWork : IDisposable
    {
        #region Private member variables...
        private CarContext _context = null;
        private GenericRepository<Car> _CarRepository;
        private GenericRepository<AdvertiseCar> _AdvertiseCarRepository;
        #endregion

        public UnitOfWork()
        {
            _context = new CarContext();
        }


        #region Public Repository Creation properties...

        /// <summary>
        /// Get/Set Property for TP_CourseSchedule repository.
        /// </summary>
        public GenericRepository<Car> CarRepository
        {
            get
            {
                if (this._CarRepository == null)
                    this._CarRepository = new GenericRepository<Car>(_context);
                return _CarRepository;
            }
        }
        public GenericRepository<AdvertiseCar> AdvertiseCarRepository
        {
            get
            {
                if (this._AdvertiseCarRepository == null)
                    this._AdvertiseCarRepository = new GenericRepository<AdvertiseCar>(_context);
                return _AdvertiseCarRepository;
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
                System.IO.File.AppendAllLines(@"D:\errors.txt", outputLines);
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
