using CommanderGQL.Common.Models;
using CommanderGQL.Infrastructure.Data.EF.Data;
using CommanderGQL.Infrastructure.GraphQL.Resolvers;
using HotChocolate.Types;

namespace CommanderGQL.Infrastructure.GraphQL.Types;

public class PlatformType : ObjectType<Platform>
{
    protected override void Configure(IObjectTypeDescriptor<Platform> descriptor)
    {
        descriptor.Description("Represents any software or service that have a command line interface");

        descriptor.Field(p => p.LicenseKey).Description("Represents a purchased, valid license for the platform");

        descriptor
            .Field(p => p.Commands)
            .ResolveWith<PlatformResolver>(p => p.GetCommands(default!, default!))
            .UseDbContext<AppDbContext>()
            .Description("This is the list of available commands for this platform");
    }
}