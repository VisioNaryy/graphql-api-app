using CommanderGQL.Common.Models;
using CommanderGQL.Infrastructure.Data.EF.Data;
using HotChocolate;
using HotChocolate.Data;

namespace CommanderGQL.Infrastructure.GraphQL.Queries;

public class Query
{
    [UseDbContext(typeof(AppDbContext))]
    [UseProjection]
    public async Task<IQueryable<Platform>> GetPlatforms([ScopedService] AppDbContext context)
        => context.Platforms;
}