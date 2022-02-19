using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using URLShortnerAPI.Models;
using URLShortnerAPI.Repositories.IRepositories;

namespace URLShortnerAPI.Features.Queries.GetUrlByOriginalUrl
{
    public class GetUrlByOriginalUrlQueryHandler : IRequestHandler<GetUrlByOriginalUrlQuery, URL>
    {
        private readonly IUrlRepository _urlRepository;

        public GetUrlByOriginalUrlQueryHandler(IUrlRepository urlRepository)
        {
            _urlRepository = urlRepository;
        }

        public async Task<URL> Handle(GetUrlByOriginalUrlQuery request, CancellationToken cancellationToken)
        {
            return await _urlRepository.GetUrlByOriginalUrl(request.originalUrl);
        }
    }
}
