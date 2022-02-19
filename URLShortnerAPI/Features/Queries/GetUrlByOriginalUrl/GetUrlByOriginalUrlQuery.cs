using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using URLShortnerAPI.Models;

namespace URLShortnerAPI.Features.Queries.GetUrlByOriginalUrl
{
    public record GetUrlByOriginalUrlQuery(string originalUrl) : IRequest<URL>
    {
    }
}
