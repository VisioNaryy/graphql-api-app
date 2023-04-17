using CommanderGQL.Domain.Data.Entities;
using HotChocolate;
using HotChocolate.Types;

namespace CommanderGQL.Infrastructure.GraphQL.Subscription;

public class Subscription
{
    [Subscribe]
    [Topic]
    public async Task<Platform> OnPlatformAdded([EventMessage] Platform platform)
        => platform;
    
    [Subscribe]
    [Topic]
    public async Task<Command> OnCommandAdded([EventMessage] Command command)
        => command;
}