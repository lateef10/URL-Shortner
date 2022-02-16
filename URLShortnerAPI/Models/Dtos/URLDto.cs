using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace URLShortnerAPI.Models.Dtos
{
    public class URLDto
    {
        public int Id { get; set; }
        public string OriginalUrl { get; set; }
        public string URLCode { get; set; }
    }
}
