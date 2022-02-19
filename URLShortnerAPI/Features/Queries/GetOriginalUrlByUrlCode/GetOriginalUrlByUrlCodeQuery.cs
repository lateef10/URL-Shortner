using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using URLShortnerAPI.Models;

namespace URLShortnerAPI.Features.Queries.GetOriginalUrlByUrlCode
{
    public record GetOriginalUrlByUrlCodeQuery(string urlCode) : IRequest<URL>
    {
    }
}
