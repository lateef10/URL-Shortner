using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using URLShortnerAPI.Models;

namespace URLShortnerAPI.Repositories.IRepositories
{
    public interface IUrlRepository
    {
        Task<IEnumerable<URL>> GetUrlByOriginalUrl(string originalUrl);
        Task<URL> GetOriginalUrlByUrlCode(string urlCode);
        Task<URL> AddUrl(URL urlEntity);
    }
}
