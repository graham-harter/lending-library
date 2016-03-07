using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LendingLibrary.Web.Infrastructure.Validators;

namespace LendingLibrary.Web.Models
{
    [Bind(Exclude = "Image")]
    public class TitleViewModel : IValidatableObject
    {
        public int ID { get; set; }
        public string Medium { get; set; }
        public int MediumId { get; set; }
        public string Name { get; set; }
        public string Subtitle { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public Nullable<short> Year { get; set; }
        public string ImageURL { get; set; }
        public string Image { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validator = new TitleViewModelValidator();
            var result = validator.Validate(this);
            return result.Errors.Select(item => new ValidationResult(item.ErrorMessage, new[] { item.PropertyName }));
        }
    }
}