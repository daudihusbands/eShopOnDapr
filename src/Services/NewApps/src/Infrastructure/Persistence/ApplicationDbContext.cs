

using System.Reflection;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NewApps.Application.Common.Interfaces;
using NewApps.Domain.Entities.ACORD;
using NewApps.Infrastructure.Common;
using NewApps.Infrastructure.Persistence.Interceptors;

namespace NewApps.Infrastructure.Persistence;

public class AppDataContext : DbContext, IUnitOfWork
{
    private readonly IMediator _mediator;
    private readonly AuditableEntitySaveChangesInterceptor _auditableEntitySaveChangesInterceptor;

    public AppDataContext(
        DbContextOptions<AppDataContext> options,
        IMediator mediator,
        AuditableEntitySaveChangesInterceptor auditableEntitySaveChangesInterceptor)
        : base(options)
    {
        _mediator = mediator;
        _auditableEntitySaveChangesInterceptor = auditableEntitySaveChangesInterceptor;
    }

    //public AppDataContext(DbContextOptions<AppDataContext> options, IMediator mediator) : base(options)
    //{
    //    _mediator = mediator;
    //}


    public DbSet<Holding> Holdings => Set<Holding>();
    private const string Schema_TC = "tc";
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

    //    builder.Entity<WithTC>()
    //        .ToTable(nameof(WithTC), Schema_TC)
    //;
    //    builder.Entity<HoldingTypeTC>()
    //        .HasBaseType<WithTC>()
    //        .ToTable(nameof(HoldingTypeTC), Schema_TC)
    //        ;
        base.OnModelCreating(builder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(_auditableEntitySaveChangesInterceptor);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await _mediator.DispatchDomainEvents(this);

        return await base.SaveChangesAsync(cancellationToken);
    }

    public async Task<bool> SaveDomainEntitiesAsync(CancellationToken cancellationToken = default)
    {
        // Dispatch Domain Events collection. 
        // Choices:
        // A) Right BEFORE committing data (EF SaveChanges) into the DB will make a single transaction including  
        // side effects from the domain event handlers which are using the same DbContext with "InstancePerLifetimeScope" or "scoped" lifetime
        // B) Right AFTER committing data (EF SaveChanges) into the DB will make multiple transactions. 
        // You will need to handle eventual consistency and compensatory actions in case of failures in any of the Handlers. 
        await _mediator.DispatchDomainEvents(this);

        // After executing this line all the changes (from the Command Handler and Domain Event Handlers) 
        // performed through the DbContext will be committed
        var result = await base.SaveChangesAsync();

        return true;
    }

}
