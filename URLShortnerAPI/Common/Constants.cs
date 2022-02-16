using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace URLShortnerAPI.Common
{
    public class Constants
    {
        public const string GetConnectionString = "UrlShortnerDbConnectionString";
        public const string ErrorMsgOriginalUrl = "Url must not be empty";
        public const string ErrorMsgOriginalUrlExceedLimit = "Url length must be between 2 and 500 characters";
    }
}
