using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using URLShortnerAPI.Models;
using URLShortnerAPI.Repositories.IRepositories;

namespace URLShortnerAPI.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IBaseRepository<URL> UrlRepository { get; }
        void Save();
    }
}
