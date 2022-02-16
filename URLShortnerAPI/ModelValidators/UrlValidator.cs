using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using URLShortnerAPI.Common;
using URLShortnerAPI.Models;

namespace URLShortnerAPI.ModelValidators
{
    public class UrlValidator : AbstractValidator<URL>
    {
        public UrlValidator()
        {
            RuleFor(x => x.Id)
                //Stop on first failure
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.OriginalUrl)
                //Stop on first failure
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty().WithMessage(Constants.ErrorMsgOriginalUrl)
                .Length(2, 500).WithMessage(Constants.ErrorMsgOriginalUrlExceedLimit);

            RuleFor(x => x.URLCode)
                //Stop on first failure
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty().Length(2, 200);
        }
    }
}
