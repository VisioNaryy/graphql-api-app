using CommanderGQL.Domain.Data.Entities;

namespace CommanderGQL.Infrastructure.GraphQL.Models;

public record AddPlatformPayload(
    Platform platform);