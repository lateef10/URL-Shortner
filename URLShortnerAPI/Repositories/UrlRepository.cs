using Base62;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using URLShortnerAPI.AppDbContext;
using URLShortnerAPI.Models;
using URLShortnerAPI.Repositories.IRepositories;

namespace URLShortnerAPI.Repositories
{
    public class UrlRepository : BaseRepository<URL>, IUrlRepository
    {
        public UrlRepository(UrlShortnerDbContext dbContext) : base(dbContext)
        {
        }
        /// <summary>
        /// Goal: Get original Url by original url. If its not empty then simply return the code to user
        /// </summary>
        /// <param name="originalUrl"></param>
        /// <returns></returns>
        public async Task<URL> GetUrlByOriginalUrl(string originalUrl)
        {
            var url = await _dbContext.uRLs.FirstOrDefaultAsync(p => p.OriginalUrl == originalUrl);
            return url;
        }
        /// <summary>
        /// Goal: Get the original url to redirect to
        /// </summary>
        /// <param name="urlCode"></param>
        /// <returns></returns>
        public async Task<URL> GetOriginalUrlByUrlCode(string urlCode)
        {
            try
            {
                var base62Converter = new Base62Converter();
                int decoded = Convert.ToInt32(base62Converter.Decode(urlCode));

                var url = await _dbContext.uRLs.FirstOrDefaultAsync(p => p.Id == decoded);
                return url;
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Goal: Add a new Url
        /// </summary>
        /// <param name="urlEntity"></param>
        /// <returns></returns>
        public async Task<URL> AddUrl(URL urlEntity)
        {
            try
            {
                var urlExist = await GetUrlByOriginalUrl(urlEntity.OriginalUrl);
                if (urlExist != null)
                {
                    return urlExist;
                }
                var lastRecord = await _dbContext.uRLs.OrderBy(p => p.Id).LastAsync();
                int nextId = lastRecord.Id + 1;

                var base62Converter = new Base62Converter();
                var encoded = base62Converter.Encode(nextId.ToString());
                urlEntity.URLCode = encoded;
                return await AddAsync(urlEntity);
            }
            catch
            {
                throw;
            }
        }
    }
}
