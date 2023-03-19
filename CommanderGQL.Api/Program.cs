using CommanderGQL.Infrastructure.Data.EF.Data;
using CommanderGQL.Infrastructure.GraphQL.Queries;
using graphql_api_app.Options;
using GraphQL.Server.Ui.Voyager;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;

// options
var connectionOptions = new ConnectionStringsOptions();
configuration.Bind(ConnectionStringsOptions.SectionName, connectionOptions);
services.AddSingleton(Options.Create(connectionOptions));

// SQl Server
services.AddPooledDbContextFactory<AppDbContext>(options =>
{
    options.UseSqlServer(connectionOptions.CommanderGQL);
});

// GraphQL
services.AddGraphQLServer()
    .AddQueryType<Query>()
    .AddProjections();

services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.MapGraphQL();

app.UseGraphQLVoyager(options: new VoyagerOptions
{
    GraphQLEndPoint = "/graphql"
});

app.Run();
