using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using URLShortnerAPI.Models;
using URLShortnerAPI.Repositories.IRepositories;

namespace URLShortnerAPI.Features.Queries.GetOriginalUrlByUrlCode
{
    public class GetOriginalUrlByUrlCodeQueryHandler : IRequestHandler<GetOriginalUrlByUrlCodeQuery, URL>
    {
        private readonly IUrlRepository _urlRepository;

        public GetOriginalUrlByUrlCodeQueryHandler(IUrlRepository urlRepository)
        {
            _urlRepository = urlRepository;
        }
        public async Task<URL> Handle(GetOriginalUrlByUrlCodeQuery request, CancellationToken cancellationToken)
        {
            return await _urlRepository.GetOriginalUrlByUrlCode(request.urlCode);
        }
    }
}
