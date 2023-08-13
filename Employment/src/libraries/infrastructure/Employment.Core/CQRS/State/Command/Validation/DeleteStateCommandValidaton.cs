using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employment.Core.CQRS.State.Command.Validation;

public class DeleteStateCommandValidaton :AbstractValidator<DeleteStateCommand>
{
    public DeleteStateCommandValidaton()
    {
        RuleFor(x=>x.Id).NotEmpty().WithMessage("Id is Reqired .");
    }
}
