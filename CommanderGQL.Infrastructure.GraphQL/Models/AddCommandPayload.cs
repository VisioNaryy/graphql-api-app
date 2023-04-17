using CommanderGQL.Domain.Data.Entities;

namespace CommanderGQL.Infrastructure.GraphQL.Models;

public record AddCommandPayload(
    Command command);