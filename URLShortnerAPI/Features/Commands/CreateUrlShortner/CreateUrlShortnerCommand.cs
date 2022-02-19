using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using URLShortnerAPI.Models;

namespace URLShortnerAPI.Features.Commands.CreateUrlShortner
{
    public record CreateUrlShortnerCommand(URL uRL) : IRequest<URL>
    {
    }
}
