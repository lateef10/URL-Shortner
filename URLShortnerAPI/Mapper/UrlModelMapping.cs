using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using URLShortnerAPI.Models;
using URLShortnerAPI.Models.Dtos;

namespace URLShortnerAPI.Mapper
{
    public class UrlModelMapping : Profile
    {
        public UrlModelMapping()
        {
            //Source -> Target ... or use ReverseMap() for both ways
            CreateMap<URLDto, URL>().ReverseMap();
        }
    }
}
