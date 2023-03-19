namespace CommanderGQL.Infrastructure.GraphQL.Models;

public record AddCommandInput(
    string HowTo,
    string CommandLine,
    int PlatformId);