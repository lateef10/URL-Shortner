using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using URLShortnerAPI.Models;
using URLShortnerAPI.Repositories.IRepositories;

namespace URLShortnerAPI.Features.Commands.CreateUrlShortner
{
    public class CreateUrlShortnerCommandHandler : IRequestHandler<CreateUrlShortnerCommand, URL>
    {
        private readonly IUrlRepository _urlRepository;

        public CreateUrlShortnerCommandHandler(IUrlRepository urlRepository)
        {
            _urlRepository = urlRepository;
        }

        public async Task<URL> Handle(CreateUrlShortnerCommand request, CancellationToken cancellationToken)
        {
            var result = await _urlRepository.AddUrl(request.uRL);

            return result;
        }
    }
}
