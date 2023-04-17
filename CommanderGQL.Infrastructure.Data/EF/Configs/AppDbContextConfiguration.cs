using CommanderGQL.Domain.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CommanderGQL.Infrastructure.Data.EF.Configs;

public class AppDbContextConfiguration : IEntityTypeConfiguration<Platform>, IEntityTypeConfiguration<Command>
{
    public void Configure(EntityTypeBuilder<Platform> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Name)
            .IsRequired();
    }

    public void Configure(EntityTypeBuilder<Command> builder)
    {

        builder.HasKey(p => p.Id);
        builder.Property(c => c.HowTo)
            .IsRequired();
        
        builder.Property(c => c.CommandLine)
            .IsRequired();
        
        builder.Property(c => c.PlatformId)
            .IsRequired();
    }
}