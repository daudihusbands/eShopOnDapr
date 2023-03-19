

namespace NewApps.Infrastructure.Persistence.Configurations;

public class HoldingConfiguration : IEntityTypeConfiguration<Holding>
{
    public void Configure(EntityTypeBuilder<Holding> builder)
    {
        //throw new NotImplementedException();
    }
}
public class PolicyConfiguration : IEntityTypeConfiguration<Policy>
{
    public void Configure(EntityTypeBuilder<Policy> builder)
    {
        builder.OwnsOne(x => x.ApplicationInfo, cfg =>
        {
            cfg.OwnsMany(x => x.SignatureInfos);
        });

        builder.OwnsMany(x => x.SERVICE_PROGRAMS, cfg =>
        {
            cfg.OwnsMany(x => x.IDs);
            cfg.OwnsMany(x => x.OptionLinks);
            cfg.OwnsOne(x => x.Schedule);
        });
        builder.OwnsMany(x => x.WorkflowSteps, cfg =>
        {
            cfg.OwnsMany(x => x.Extensions);

        });
    }
}
