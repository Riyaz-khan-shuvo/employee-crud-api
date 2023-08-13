using Employment.Backend.Controllers.Common;
using Employment.Core.CQRS.Employee.Command;
using Employment.Core.CQRS.Employee.Query;
using Employment.Service.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
namespace Employment.Backend.Controllers;
public class EmployeeController : ApiControllerBase
{
	[ProducesResponseType(200)]
	[ProducesResponseType(400)]
	[ProducesResponseType(404)]
	[ProducesResponseType(401)]
	[ProducesResponseType(403)]
	[HttpGet("{id:int}")]
	public async Task<ActionResult<VMEmployee>> GetById(int id)
	{
		return await HandleQueryAsync(new GetEmployeeByIdQuery(id));
	}
	[ProducesResponseType(200)]
	[ProducesResponseType(400)]
	[ProducesResponseType(404)]
	[ProducesResponseType(401)]
	[ProducesResponseType(403)]
	[HttpGet]
	public async Task<ActionResult<VMEmployee>> GetAll()
	{
		return await HandleQueryAsync(new GetAllEmployeeQuery());
	}
	[ProducesResponseType(200)]
	[ProducesResponseType(400)]
	[ProducesResponseType(404)]
	[ProducesResponseType(401)]
	[ProducesResponseType(403)]
	[HttpPost]
	public async Task<ActionResult<VMEmployee>> Create([FromBody]  VMEmployee command)
	{
		return await HandleCommandAsync(new CreateEmployeeCommand(command));
	}
	[ProducesResponseType(200)]
	[ProducesResponseType(400)]
	[ProducesResponseType(404)]
	[ProducesResponseType(401)]
	[ProducesResponseType(403)]
	[HttpPut("{id:int}")]
	public async Task<ActionResult<VMEmployee>> Update(int id,VMEmployee command)
	{
		return await HandleCommandAsync(new UpdateEmployeeCommand(id,command));
	}
	[ProducesResponseType(200)]
	[ProducesResponseType(400)]
	[ProducesResponseType(404)]
	[ProducesResponseType(401)]
	[ProducesResponseType(403)]
	[HttpDelete("{id:int}")]
	public async Task<ActionResult<VMEmployee>> Delete(int id)
	{
		return await HandleCommandAsync(new  DeleteEmployeeCommand(id));	
	}
}
