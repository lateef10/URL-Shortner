using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using URLShortnerAPI.AppDbContext;
using URLShortnerAPI.Models;
using URLShortnerAPI.Repositories;
using URLShortnerAPI.Repositories.IRepositories;

namespace URLShortnerAPI.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly UrlShortnerDbContext _dbContext = null;
        private IBaseRepository<URL> _urlRepository;

        public UnitOfWork()
        {
            _dbContext = new UrlShortnerDbContext();
        }

        public IBaseRepository<URL> UrlRepository
        {
            get
            {
                if (this._urlRepository == null)
                    this._urlRepository = new BaseRepository<URL>(_dbContext);

                return _urlRepository;
            }
        }

        public void Save()
        {
            try
            {
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// protected virtual Dispose method
        /// </summary>
        /// <param name="disposed"></param>
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    Debug.WriteLine("UnitOfWork is being disposed");
                    _dbContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
