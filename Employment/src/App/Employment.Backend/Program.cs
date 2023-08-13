using Employment.IoC.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.OpenApi.Models;
using System.Text.Json;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.MapCore(builder.Configuration);

builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddControllers().AddJsonOptions(options =>
{
	options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
	options.JsonSerializerOptions.WriteIndented = true;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
	options.SwaggerDoc("v1",
		new OpenApiInfo
		{
			Title = "Employment-Project",
			Version = "v1",
			Description = "This is a Employment Project to see how documentation can easily be generated for ASP.NET Core Web APIs using Swagger and ReDoc.",
			Contact = new OpenApiContact
			{
				Name = "Santanu Chandra",
				Email = "Srajdip920@gmail.com"
			}
		});
});


// builder.Services.AddControllers(options =>
//{
//    options.OutputFormatters.RemoveType<SystemTextJsonOutputFormatter>();
//    options.OutputFormatters.Add(new SystemTextJsonOutputFormatter(new JsonSerializerOptions(JsonSerializerDefaults.Web)
//    {
//        ReferenceHandler = ReferenceHandler.Preserve,
//    }));
//});

builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
{
	builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));
//all Ioc Configuration

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI(options =>
	options.SwaggerEndpoint("/swagger/v1/swagger.json",
	"Swagger Demo Documentation v1"));

	app.UseReDoc(options =>
	{
		options.DocumentTitle = "Swagger Demo Documentation";
		options.SpecUrl = "/swagger/v1/swagger.json";
	});
}
app.UseCors("corsapp");
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
