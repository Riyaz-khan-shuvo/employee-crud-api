using Employment.Backend.Controllers.Common;
using Employment.Core.CQRS.Country.Command;
using Employment.Core.CQRS.Country.Query;
using Employment.Core.CQRS.Department.Command;
using Employment.Core.CQRS.Department.Query;
using Employment.Service.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Employment.Backend.Controllers;


public class CountryController : ApiControllerBase
{
	[ProducesResponseType(200)]
	[ProducesResponseType(400)]
	[ProducesResponseType(404)]
	[ProducesResponseType(401)]
	[ProducesResponseType(403)]
	[HttpGet("{id:int}")]
	public async Task<ActionResult<VMCountry>> GetById(int id)
	{
		return await HandleQueryAsync(new GetCountryQueryById(id));
	}
	[ProducesResponseType(200)]
	[ProducesResponseType(400)]
	[ProducesResponseType(404)]
	[ProducesResponseType(401)]
	[ProducesResponseType(403)]
	[HttpGet]
	public async Task<ActionResult<VMCountry>> GetAll()
	{
		return await HandleQueryAsync(new GetCountoryAllQuery());
	}
	[ProducesResponseType(200)]
	[ProducesResponseType(400)]
	[ProducesResponseType(404)]
	[ProducesResponseType(401)]
	[ProducesResponseType(403)]
	[HttpPost]
	public async Task<ActionResult<VMCountry>> Create([FromBody] VMCountry command)
	{
		return await HandleCommandAsync(new CreateCountryCommand(command));
	}
	[ProducesResponseType(200)]
	[ProducesResponseType(400)]
	[ProducesResponseType(404)]
	[ProducesResponseType(401)]
	[ProducesResponseType(403)]
	[HttpPut("{id:int}")]
	public async Task<ActionResult<VMCountry>> Update(int id, VMCountry command)
	{
		return await HandleCommandAsync(new UpdateCountryCommand(id, command));
	}
	[ProducesResponseType(200)]
	[ProducesResponseType(400)]
	[ProducesResponseType(404)]
	[ProducesResponseType(401)]
	[ProducesResponseType(403)]
	[HttpDelete("{id:int}")]
	public async Task<ActionResult<VMCountry>> Delete(int id)
	{
		return await HandleCommandAsync(new DeleteCountryCommand(id));
	}
}
