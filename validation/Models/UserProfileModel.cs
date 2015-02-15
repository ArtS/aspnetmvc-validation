using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using FluentValidation;

namespace Validation.Models
{
    [FluentValidation.Attributes.Validator(typeof(UserProfileModelValidator))]
    public class UserProfileModel
    {
        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Display(Name = "Last name")]
        public string LastName { get; set; }

        // This property holds user-selected state
        [Display(Name = "State")]
        public string State { get; set; }

        // This property holds all available states for selection
        public Dictionary<string, string> States { get; set; }

        // Property to store human-readable state name
        public string StateName { get; set; }
    }

    public class UserProfileModelValidator : AbstractValidator<UserProfileModel>
    {
        public UserProfileModelValidator()
        {
            RuleFor(m => m.FirstName).NotEmpty().WithMessage("Please enter First Name");
            RuleFor(m => m.LastName).NotEmpty();
            RuleFor(m => m.State).NotEmpty();
        }
    }
}