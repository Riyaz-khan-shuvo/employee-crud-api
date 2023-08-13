using Employment.Repositories.Interface;
using Employment.Service.Models.ViewModel;
using Employment.Sheared.Models;
using FluentValidation;
using MediatR;

namespace Employment.Core.CQRS.State.Query;

public record GetStateById(int Id):IRequest<QueryResult<VMState>>;
public class GetStateByIdHandler : IRequestHandler<GetStateById, QueryResult<VMState>>
{
	private readonly ISateRepository _sateRepository;
	private readonly IValidator<GetStateById> _validator;
    public GetStateByIdHandler(ISateRepository sateRepository, IValidator<GetStateById> validator)
    {
        _sateRepository = sateRepository;
		_validator = validator;
    }
    public async Task<QueryResult<VMState>> Handle(GetStateById request, CancellationToken cancellationToken)
	{
		var validator= await _validator.ValidateAsync(request, cancellationToken);
		if (!validator.IsValid) throw new ValidationException(validator.Errors);
		var result = await _sateRepository.GetByIdAsync(request.Id);
		;
		return result switch
		{
			null => new QueryResult<VMState>(null, QueryResultTypeEnum.NotFound),
			_ => new QueryResult<VMState>(result, QueryResultTypeEnum.Success)
		};
	}
}

