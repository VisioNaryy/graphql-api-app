using CommanderGQL.Common.Models;
using CommanderGQL.Infrastructure.Data.EF.Data;
using HotChocolate;
using Microsoft.EntityFrameworkCore;

namespace CommanderGQL.Infrastructure.GraphQL.Resolvers;

public class CommandResolver
{
    public async Task<Platform?> GetPlatform([Parent] Command command,
        [ScopedService] AppDbContext context)
        => await context.Platforms.Where(p => p.Id == command.PlatformId).FirstOrDefaultAsync();
}