using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LendingLibrary.Web.Models;

namespace LendingLibrary.Web.Infrastructure.Validators
{
    public class TitleViewModelValidator : AbstractValidator<TitleViewModel>
    {
        public TitleViewModelValidator()
        {
            // todo Title validation rules here
        }
    }
}