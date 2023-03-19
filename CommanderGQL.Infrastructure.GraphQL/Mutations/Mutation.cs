using CommanderGQL.Common.Models;
using CommanderGQL.Infrastructure.Data.EF.Data;
using CommanderGQL.Infrastructure.GraphQL.Models;
using HotChocolate;
using HotChocolate.Data;

namespace CommanderGQL.Infrastructure.GraphQL.Mutations;

public class Mutation
{
    [UseDbContext(typeof(AppDbContext))]
    public async Task<AddPlatformPayload> AddPlatformAsync(
        AddPlatformInput platformInput,
        [ScopedService] AppDbContext context)
    {
        var platform = new Platform
        {
            Name = platformInput.Name
        };

        await context.Platforms.AddAsync(platform);
        await context.SaveChangesAsync();

        return new AddPlatformPayload(platform);
    }
    
    [UseDbContext(typeof(AppDbContext))]
    public async Task<AddCommandPayload?> AddCommandAsync(
        AddCommandInput commandInput,
        [ScopedService] AppDbContext context)
    {
        var (howTo, commandLine, platformId) = commandInput;
        
        var platform = await context.Platforms.FindAsync(platformId);

        if (platform is not null)
        {
            var command = new Command
            {
                HowTo = howTo,
                CommandLine = commandLine,
                Platform = platform
            };
            
            await context.Commands.AddAsync(command);
            await context.SaveChangesAsync();

            return new AddCommandPayload(command);
        }

        return default;
    }
}