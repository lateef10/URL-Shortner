using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using URLShortnerAPI.Features.Commands.CreateUrlShortner;
using URLShortnerAPI.Features.Queries.GetOriginalUrlByUrlCode;
using URLShortnerAPI.Models;

namespace URLShortnerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UrlShortnerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UrlShortnerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "GetOriginalUrlByCode")]
        public async Task<ActionResult<URL>> GetOriginalUrlByUrlCode(string urlCode)
        {
            var originalUrl = await _mediator.Send(new GetOriginalUrlByUrlCodeQuery(urlCode));
            return Ok(originalUrl);
        }

        [HttpPost]
        public async Task<ActionResult<string>> CreateProduct([FromBody] URL urlEntity)
        {
            var result = await _mediator.Send(new CreateUrlShortnerCommand(urlEntity));
            return Ok(result);
        }
    }
}
