using CommanderGQL.Common.Models;
using CommanderGQL.Infrastructure.Data.EF.Data;
using HotChocolate;

namespace CommanderGQL.Infrastructure.GraphQL.Resolvers;

public class PlatformResolver
{
    public async Task<IQueryable<Command>?> GetCommands([Parent] Platform platform,
        [ScopedService] AppDbContext context)
        => context.Commands.Where(p => p.PlatformId == platform.Id);
}