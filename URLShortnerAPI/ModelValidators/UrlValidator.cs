using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using URLShortnerAPI.Common;
using URLShortnerAPI.Models;
using URLShortnerAPI.Models.Dtos;

namespace URLShortnerAPI.ModelValidators
{
    public class UrlValidator : AbstractValidator<URLDto>
    {
        public UrlValidator()
        {

            RuleFor(x => x.OriginalUrl)
                //Stop on first failure
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty().WithMessage(Constants.ErrorMsgOriginalUrl)
                .Length(2, 500).WithMessage(Constants.ErrorMsgOriginalUrlExceedLimit)
                .Must(BeAValidURI).WithMessage("Invalid URL");

        }
        private bool BeAValidURI(string originalUrl)
        {
            return Uri.IsWellFormedUriString(originalUrl, UriKind.Absolute);
        }
    }
}
