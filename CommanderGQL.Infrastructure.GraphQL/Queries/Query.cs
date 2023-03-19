using CommanderGQL.Common.Models;
using CommanderGQL.Infrastructure.Data.EF.Data;
using HotChocolate;
using HotChocolate.Data;
using Microsoft.EntityFrameworkCore;

namespace CommanderGQL.Infrastructure.GraphQL.Queries;

public class Query
{
    [UseDbContext(typeof(AppDbContext))]
    public async Task<IQueryable<Platform>> GetPlatforms([ScopedService] AppDbContext context)
        => context.Platforms;
    
    [UseDbContext(typeof(AppDbContext))]
    public async Task<IQueryable<Command>> GetCommands([ScopedService] AppDbContext context)
        => context.Commands;
}