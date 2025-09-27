using Common.EndPoint.API;
using Common.EndPoint.API.Result;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManagement.Application;
using TaskManagement.Infrastructure;
using TaskManagement.WebApi.Infrastructure.JwtUtil;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().ConfigureApiBehaviorOptions(option =>
{
	 option.InvalidModelStateResponseFactory = (context =>
	 {

		  var result = new ApiResult()
		  {
			   IsSuccess = false,
			   MetaData = new()
			   {
					StatusCode = AppStatusCode.BadRequest,
					Message = ModelStateUtil.GetModelStateErrors(context.ModelState)
			   }
		  };

		  return new BadRequestObjectResult(result);
	 });
	 option.SuppressModelStateInvalidFilter = true;
});;
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddSwaggerGen();

builder.Services.AddJwtAuthentication(builder.Configuration);
string dbConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.Init(dbConnectionString);
ApplicationConfiguration.RegisterApplicationDependencies(builder.Services);
builder.Services.AddTransient<CustomJwtValidation>();
var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();

// Configure the HTTP request pipeline.


app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
