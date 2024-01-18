using FluentValidation;
using System.Reflection;
using Snap.Financials.Infrastructure;
using Snap.Financials.Endpoints;
using Snap.Financials.Endpoints.Endpoints.Contracts;

var builder = WebApplication.CreateBuilder(args);

#region Swagger

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#endregion

#region Infrastructure

builder.Services.AddUserInfrastructure();
builder.Services.AddDatabaseInfrastructure(builder.Configuration);

#endregion

#region Validation

builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

#endregion

#region Endpoints

builder.Services.AddEndpoints();

#endregion

var app = builder.Build();

#region Swagger 

app.UseSwagger();
app.UseSwaggerUI();

#endregion

#region Pipeline

app.UseHttpsRedirection();

#endregion

#region Endpoints

app.RegisterEndpoints();

#endregion


app.Run();
