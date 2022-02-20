using AutoMapper;
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
using URLShortnerAPI.Models.Dtos;

namespace URLShortnerAPI.Controllers
{
    [Route("")]
    [ApiController]
    public class UrlShortnerController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public UrlShortnerController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [Route("{urlCode}")]
        [HttpGet]
        public async Task<ActionResult<URL>> GetOriginalUrlByUrlCode(string urlCode)
        {
            var originalUrl = await _mediator.Send(new GetOriginalUrlByUrlCodeQuery(urlCode));

            var redirect = _mapper.Map<URLDto>(originalUrl);
            return Redirect(redirect.OriginalUrl);
        }

        [HttpPost]
        public async Task<ActionResult<URL>> CreateUrlShortner([FromBody] URLDto urlDto)
        {
            var urlEntity = _mapper.Map<URL>(urlDto);
            var result = await _mediator.Send(new CreateUrlShortnerCommand(urlEntity));
            return Ok(_mapper.Map<URLDto>(result));
        }
    }
}
