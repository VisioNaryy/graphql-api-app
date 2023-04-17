using CommanderGQL.Domain.Data.Entities;
using CommanderGQL.Infrastructure.Data.EF.Data;
using CommanderGQL.Infrastructure.GraphQL.Resolvers;
using HotChocolate.Types;

namespace CommanderGQL.Infrastructure.GraphQL.Types;

public class CommandType : ObjectType<Command>
{
    protected override void Configure(IObjectTypeDescriptor<Command> descriptor)
    {
        descriptor.Description("Represents any executable command");
        
        descriptor
            .Field(c => c.Platform)
            .ResolveWith<CommandResolver>(c => c.GetPlatform(default!, default!))
            .UseDbContext<AppDbContext>()
            .Description("This is the available platform for this command");
    }
}