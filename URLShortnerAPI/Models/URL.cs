using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace URLShortnerAPI.Models
{
    public class URL : EntityBase
    {
        public string OriginalUrl { get; set; }
        public string URLCode { get; set; }
    }
}
