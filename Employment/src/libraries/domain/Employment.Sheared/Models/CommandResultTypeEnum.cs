﻿namespace Employment.Sheared.Models;

public enum CommandResultTypeEnum
{
	Success,
	Created = 201,
	InvalidInput = 400,
	UnprocessableEntity = 500,
	Conflict,
	NotFound = 404,
	UnAuthorized = 401
}
