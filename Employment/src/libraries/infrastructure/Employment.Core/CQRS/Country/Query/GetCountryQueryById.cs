using Employment.Repositories.Interface;
using Employment.Service.Models.ViewModel;
using Employment.Sheared.Models;
using FluentValidation;
using MediatR;

namespace Employment.Core.CQRS.Country.Query;

public record GetCountryQueryById(int Id):IRequest<QueryResult<VMCountry>>;

public class GetCountryQueryByIdHandeler : IRequestHandler<GetCountryQueryById, QueryResult<VMCountry>>
{
	private readonly ICountryRepository _countryRepository;
    private readonly IValidator<GetCountryQueryById> _validator;
    public GetCountryQueryByIdHandeler(ICountryRepository countryRepository, IValidator<GetCountryQueryById> validator)
    {
        _countryRepository = countryRepository;
        _validator = validator;
    }
    public async Task<QueryResult<VMCountry>> Handle(GetCountryQueryById request, CancellationToken cancellationToken)
	{
		var validator= await _validator.ValidateAsync(request, cancellationToken);
        if (!validator.IsValid) throw new ValidationException(validator.Errors);
        var result= await _countryRepository.GetByIdAsync(request.Id);
        ;
        return result switch
        {
            null => new QueryResult<VMCountry>(null,QueryResultTypeEnum.NotFound),
            _ => new QueryResult<VMCountry>(result,QueryResultTypeEnum.Success)
        };
	}
}
