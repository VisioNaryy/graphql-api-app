using CommanderGQL.Common.Models;

namespace CommanderGQL.Infrastructure.GraphQL.Models;

public record AddCommandPayload(
    Command command);