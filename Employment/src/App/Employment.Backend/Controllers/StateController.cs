using Employment.Backend.Controllers.Common;
using Employment.Core.CQRS.Country.Command;
using Employment.Core.CQRS.Country.Query;
using Employment.Core.CQRS.Department.Query;
using Employment.Core.CQRS.State.Command;
using Employment.Core.CQRS.State.Query;
using Employment.Service.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Employment.Backend.Controllers;


public class StateController : ApiControllerBase
{
	[ProducesResponseType(200)]
	[ProducesResponseType(400)]
	[ProducesResponseType(404)]
	[ProducesResponseType(401)]
	[ProducesResponseType(403)]
	[HttpGet("{id:int}")]
	public async Task<ActionResult<VMState>> GetById(int id)
	{
		return await HandleQueryAsync(new GetStateById(id));
	}
	[ProducesResponseType(200)]
	[ProducesResponseType(400)]
	[ProducesResponseType(404)]
	[ProducesResponseType(401)]
	[ProducesResponseType(403)]
	[HttpGet]
	public async Task<ActionResult<VMState>> GetAll()
	{
		return await HandleQueryAsync(new GetStateAll());
	}
	[ProducesResponseType(200)]
	[ProducesResponseType(400)]
	[ProducesResponseType(404)]
	[ProducesResponseType(401)]
	[ProducesResponseType(403)]
	[HttpPost]
	public async Task<ActionResult<VMState>> Create([FromBody] VMState command)
	{
		return await HandleCommandAsync(new CrateStateCommand(command));
	}
	[ProducesResponseType(200)]
	[ProducesResponseType(400)]
	[ProducesResponseType(404)]
	[ProducesResponseType(401)]
	[ProducesResponseType(403)]
	[HttpPut("{id:int}")]
	public async Task<ActionResult<VMState>> Update(int id, VMState command)
	{
		return await HandleCommandAsync(new UpdateStateCommand(id, command));
	}
	[ProducesResponseType(200)]
	[ProducesResponseType(400)]
	[ProducesResponseType(404)]
	[ProducesResponseType(401)]
	[ProducesResponseType(403)]
	[HttpDelete("{id:int}")]
	public async Task<ActionResult<VMState>> Delete(int id)
	{
		return await HandleCommandAsync(new DeleteStateCommand(id));
	}
}
