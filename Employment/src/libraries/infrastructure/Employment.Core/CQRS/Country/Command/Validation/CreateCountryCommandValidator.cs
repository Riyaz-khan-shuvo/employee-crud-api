using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employment.Core.CQRS.Country.Command.Validation
{
	public class CreateCountryCommandValidator : AbstractValidator<CreateCountryCommand>
	{
        public CreateCountryCommandValidator()
        {
            RuleFor(c=>c.vmCountry.CountryName).NotEmpty().WithMessage("Country Name is Required");
        }
    }
}
