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
    public class CreateUrlShortnerCommandHandler : IRequestHandler<CreateUrlShortnerCommand, string>
    {
        private readonly IUrlRepository _urlRepository;

        public CreateUrlShortnerCommandHandler(IUrlRepository urlRepository)
        {
            _urlRepository = urlRepository;
        }

        public async Task<string> Handle(CreateUrlShortnerCommand request, CancellationToken cancellationToken)
        {
            var result = await _urlRepository.AddAsync(request.uRL);

            return result.URLCode;
        }
    }
}
